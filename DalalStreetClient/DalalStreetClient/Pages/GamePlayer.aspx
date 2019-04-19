<%@ Page Title="" Async="true" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="GamePlayer.aspx.cs" Inherits="DalalStreetClient.Pages.GamePlayer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
    table{
        border: 1px solid grey;
		margin: auto;
    }
    td{
        border:1px solid grey;
		padding-left: 10px;
		padding-right: 10px;
    }
    td.buttonCell{
        padding-left: 0;
        padding-right: 0;
    }
    button{
        background-color: #42f4c2;
        border-radius: 5px;
    }
    button:hover{
        cursor:pointer;
        background-color: #00d398;
    }
	.noChange{
		color: grey;
    }
	.increased{
		color: #02a800;
	}
	.decreased{
		color: #ff3030;
	}
    #ContentPlaceHolder1_tableStocks{
        float: left;
        max-height: 700px;
        overflow-y: auto;
    }
    #ContentPlaceHolder1_tableNews{
        float: right;
        max-height: 700px;
        overflow-y: auto;
    }
    #ContentPlaceHolder1_tableNews table{
        min-width: 500px;
        
    }
    #ContentPlaceHolder1_tableAction{
        position: fixed;
        top:0;
        left:0;
        width: 100vw;
        height: 100vh;
        background-color: rgba(196, 196, 196, 0.47);
    }
    #actionArea{
        background-color:white;
        position:relative;
        top:15%;
        width:800px;
        margin:auto;
    }
    #trendGraph{
        display: inline-block;
        vertical-align:middle;
    }
    #functions{
        margin: auto auto auto 30px;
        display: inline-block;
        vertical-align:middle;
    }
    #functions button{
        margin: 20px 10px auto 10px;
    }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js" type="text/javascript"></script>
    <script src="https://cdn.jsdelivr.net/npm/chart.js@2.8.0/dist/Chart.min.js" type="text/javascript"></script>
    <script type = "text/javascript">
        var stockData = {
                'companies': {
                    'Appple' : {'StockValue': 188.47, 'StockOwned': 30, 'Id': 1 },
                    'Samsung' : {'StockValue': 172.23, 'StockOwned': 50, 'Id': 1  },
                    'KFC' : {'StockValue': 145.56, 'StockOwned': 0, 'Id': 1  },
                    'McDonald': {'StockValue': 138.12, 'StockOwned': 10, 'Id': 1  },
                    'LG' : {'StockValue': 142.11, 'StockOwned': 0, 'Id': 1   },
                    'Popeyes' : {'StockValue': 166.45, 'StockOwned': 0, 'Id': 1  },
                    'Huawei' : {'StockValue': 178.01, 'StockOwned': 0, 'Id': 1  },
                    'Google': {'StockValue': 192.97, 'StockOwned': 40, 'Id': 1   },
                    'Razer' : {'StockValue': 138.23, 'StockOwned': 0, 'Id': 1   },
                    'Burger King' : {'StockValue': 122.15, 'StockOwned': 0, 'Id': 1  },
                },
                'events': [], 
                'player': {'balance': 1000}
            };
        var interval;
        var currentStockData = {};
        var currentData = {};

        window.onload = function () {
            var newsTable = document.createElement("table");
            newsTable.id = "newsTable";
            var newsRow = newsTable.insertRow(0);
            var newsCell0 = newsRow.insertCell(0);
            newsCell0.innerHTML = "News";
            document.getElementById("ContentPlaceHolder1_tableNews").appendChild(newsTable);

            BuildGameArea();

            $("#ContentPlaceHolder1_tableAction").click(function (e) {
                $(this).css("display", "none");
            }).children().click(function(e) {
              return false;
            });
            

            setInterval(function () {
                BuildGameArea();
            }, 1000);
        }
        function GetStockData() {
            //$.ajax({
            //    type: "POST",
            //    url: "AjaxScripts/GetStockData.aspx/GetStock",
            //    data: '',
            //    contentType: "application/json; charset=utf-8",
            //    dataType: "json",
            //    success: function(response) {
            //        console.log(response);            
            var stock = {
                'companies': {},
                'events': [], 
                'player': {}            
            };
            var stockContent = document.getElementById("ContentPlaceHolder1_StocksFromServer").value;
            var newsContent = document.getElementById("ContentPlaceHolder1_NewsFromServer").value;
            var userContent = document.getElementById("ContentPlaceHolder1_UserInfoFromServer").value;
            //console.log(stockContent);
            //console.log(newsContent);
            //console.log(userContent);
            stock.companies = JSON.parse('{' + stockContent + '}');
            stock.events = JSON.parse(newsContent);
            stock.player = JSON.parse('{' + userContent+ '}');
            //console.log("Get Stocks  " + JSON.stringify(stock));
            return stock;
            //    },
            //    failure: function(response) {
            //        console.log(response.d);
            //    }
            //});
            
        }

        function GetPlayerInfo() {
            var stock = document.getElementById("ContentPlaceHolder1_UserInfo").value;
            return stock;            
        }

        function BuildGameArea() {
            document.getElementById("ContentPlaceHolder1_tableStocks").innerHTML = "";
            var stockTable = document.createElement("table");
            stockTable.id = "stocksTable";
            var row = stockTable.insertRow(0);
            var cell0 = row.insertCell(0);
            cell0.innerHTML = "Company";
            var cell1 = row.insertCell(1);
            cell1.innerHTML = "Variation";
            var cell2 = row.insertCell(2);
            cell2.innerHTML = "Value";
            var cell3 = row.insertCell(3);
            cell3.innerHTML = "Stock Owned";
            var cell4 = row.insertCell(4);
            cell4.innerHTML = "Action";
            document.getElementById("ContentPlaceHolder1_tableStocks").appendChild(stockTable);
      
            var newStockData = GetStockData();
            document.getElementById("balance").innerHTML = newStockData.player.balance;
            currentStockData = newStockData;
            var companyNames = Object.keys(newStockData.companies);

            for (var i = 0; i < companyNames.length; i++) {
                var newRow = stockTable.insertRow(i + 1);
                var newCell0 = newRow.insertCell(0);
                newCell0.innerHTML = companyNames[i];
                var newCell1 = newRow.insertCell(1);
                
                if (companyNames[i] in currentData) {
                    var variation = newStockData.companies[companyNames[i]].StockValue - currentData[companyNames[i]][currentData[companyNames[i]].length - 1];
                    if (variation > 0) {
                        newCell1.innerHTML = "<span class='increased'>+ $" + variation.toFixed(2) + "</span>";
                    }
                    else if (variation < 0) {
                        newCell1.innerHTML = "<span class='decreased'>- $" + Math.abs(variation).toFixed(2) + "</span>";
                    }
                    else {
                        newCell1.innerHTML = "<span class='noChange'>+ $" + variation.toFixed(2) + "</span>";
                    }
                    currentData[companyNames[i]].push(newStockData.companies[companyNames[i]].StockValue);
                }
                else {
                    currentData[companyNames[i]] = [newStockData.companies[companyNames[i]].StockValue];
                    newCell1.innerHTML = "<span class='noChange'>+ $0.00</span>";
                }
                var newCell2 = newRow.insertCell(2);
                newStockData.companies[companyNames[i]]
                newCell2.innerHTML = "$" + newStockData.companies[companyNames[i]].StockValue.toFixed(2);
                var newCell3 = newRow.insertCell(3);
                newCell3.innerHTML = newStockData.companies[companyNames[i]].StockOwned;
                var newCell4 = newRow.insertCell(4);
                newCell4.className = "buttonCell";
                newCell4.innerHTML = "<button type='button' class='w3-button w3-red w3-padding w3-round' onclick=\"OpenBuySellWindow('" + companyNames[i] +"', '"+ newStockData.companies[companyNames[i]].Id + "')\">Buy/Sell</button>";



            }
               
            var newsTable = document.getElementById("newsTable");
            for(var i = newsTable.rows.length - 1; i > 5; i--)
            {
                    newsTable.deleteRow(i);
            }

            if (newStockData.events.length > 0) {
                for (var i = 0; i < newStockData.events.length; i++) {
                    var newsNewRow = newsTable.insertRow(1);
                    var newsNewCell0 = newsNewRow.insertCell(0);
                    newsNewCell0.innerHTML = newStockData.events[i];
                }
            }            
        }

        function OpenBuySellWindow(companyName, id) {
            document.getElementById("ContentPlaceHolder1_tableAction").style.display = "";
            var data = {
                labels: [],
                datasets: [{
                    data: [],
                    label: companyName,
                    borderColor: "#3e95cd",
                    pointRadius: 0,
                    pointStyle: "line",
                    fill: false
                }]
            };
            for (var i = 0; i < currentData[companyName].length - 1; i++) {
                data.labels.push(i);
                data.datasets[0].data.push(currentData[companyName][i]);
            }
           
            var ctx = document.getElementById('myChart').getContext('2d');
            var myChart = new Chart(ctx, {
                type: 'line',
                data: data,
                options: {
                    title: {
                        display: true,
                        text: 'Stock Trend for Company: ' + companyName
                    },
                    responsive: false
                }
            });
            //console.log(id + " " + companyName);            
            document.getElementById("ContentPlaceHolder1_HiddenCompanyId").value = id;//currentData[companyName][currentData[companyName].length - 1];
            document.getElementById("currentCompany").innerHTML = companyName;
            document.getElementById("ownedStock").innerHTML = currentStockData.companies[companyName].StockOwned;
            document.getElementById("stockValue").innerHTML = currentStockData.companies[companyName].StockValue;
        }

        function BuyStock() {
            var quantity = document.getElementById("quantityToPurchase").value;
            var companyName = document.getElementById("currentCompany").innerHTML;
            var companyId = document.getElementById("companyId").innerHTML;
        }

        function SellStock() {
            var quantity = document.getElementById("quantityToPurchase").value;
            var companyName = document.getElementById("currentCompany").innerHTML;
            var companyId = document.getElementById("companyId").innerHTML;
        }
    </script>
    <h1>Game</h1>

                <div id="userMoney" runat="server" CssClass="w3-center" style="width: 100%; max-height:200px; margin-bottom:50px; margin-top:50px">
                    <div style="align-self:flex-end">Total $ <span id="balance"></span></div>
                 </div>
                 <div id="tableStocks" runat="server" CssClass="w3-center" style="width: 50%; max-height:200px;">
           
                 </div>
                 <div id="tableNews" runat="server" CssClass="w3-center" style="width: 50%; max-height:200px;">
           
                 </div>
                 <div id="tableAction" runat="server" CssClass="w3-center" style="display:none">
                     <div id="actionArea">
                         <div id="trendGraph">
                           <canvas id="myChart" width="400" height="400"></canvas>
                       </div>
                       <div id="functions">
                           <div><b>
                               <asp:HiddenField runat="server" id="HiddenCompanyId"/>
                               <span id="currentCompany"></span></b></div>
                           <div>Owned: <span id="ownedStock"></span></div>
                           <div>Value: <span id="stockValue"></span></div>
                           <div>Quantity: <input runat="server" type="number" id="quantityToPurchase" /></div>
                           <asp:Button ID="buttonBuy" UseSubmitBehavior="false" runat="server" CssClass="w3-button w3-red w3-padding w3-round" OnClick="BuyStocks" Text="Buy"/> 
                           <asp:Button ID="buttonSell" UseSubmitBehavior="false" runat="server" OnClick="SellStocks" CssClass="w3-button w3-red w3-padding w3-round" style="color:red" Text="Sell"/>
                           <div runat="server" visible="false" style="color:red" id="errorMessage">Try again!</div>
                       </div>
                     </div>
           
                 </div> 
    <asp:ScriptManager ID="ScriptManager" runat="server" />
        <asp:Timer ID="TimerToRefresh" OnTick="Timer_Tick" runat="server" Interval="2000"></asp:Timer>
        <asp:UpdatePanel ID="GamePanel" runat="server" UpdateMode="Conditional">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="TimerToRefresh" />
            </Triggers>
        <ContentTemplate>    
            <asp:HiddenField runat="server" id="StocksFromServer"/>
            <asp:HiddenField runat="server" id="NewsFromServer"/>
            <asp:HiddenField runat="server" id="UserInfoFromServer"/>
            <asp:HiddenField runat="server" id="PlayerBalance"/>
        </ContentTemplate>
</asp:UpdatePanel>
   <%-- <div class="w3-bar w3-white w3-center w3-medium">

        <asp:ScriptManager ID="ScriptManager" runat="server" />
        <asp:Timer ID="TimerToRefresh" OnTick="Timer_Tick" runat="server" Interval="5000"></asp:Timer>
        <asp:UpdatePanel ID="GamePanel" runat="server" UpdateMode="Conditional">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="TimerToRefresh" />
            </Triggers>
            <ContentTemplate>
		        <div id="tableStocks" runat="server" CssClass="w3-center" style="width: 60%">
           
                </div>
                <div id="tableNews" runat="server" CssClass="w3-center" style="width: 40%">
           
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
	</div>--%>
</asp:Content>
