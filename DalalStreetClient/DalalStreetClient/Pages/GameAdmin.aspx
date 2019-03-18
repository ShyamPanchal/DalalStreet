<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="GameAdmin.aspx.cs" Inherits="DalalStreetClient.Pages.GameAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="w3-bar w3-white w3-center w3-medium">        
         <h1>Ranking Players</h1>
		<div id="tablePlayers" runat="server" CssClass="w3-center">
           <p>
               <asp:ScriptManager ID="ScriptManager" runat="server" />
                <asp:Timer ID="TimerToRefresh" OnTick="Timer_Tick" runat="server" Interval="2000"></asp:Timer>
                <asp:UpdatePanel ID="PlayerTablePanel" runat="server" UpdateMode="Conditional">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="TimerToRefresh" />
                    </Triggers>
                    <ContentTemplate>
                        <asp:table id="PlayersTable" runat="server" GridLines="Horizontal" HorizontalAlign="Center" Width="75%" CssClass="w3-table w3-centered w3-bordered w3-hoverable w3-text-black w3-white w3-round-large">
                   
                        </asp:table>
                    </ContentTemplate>
                </asp:UpdatePanel>
           </p>
             <p>
			    <asp:Button ID="buttonStop" runat="server" ValidationGroup="stop" OnClick="buttonStop_Click" Text="Stop Game" CssClass="w3-button w3-red w3-padding w3-round" />
		    </p>
        </div>
	</div>
</asp:Content>
