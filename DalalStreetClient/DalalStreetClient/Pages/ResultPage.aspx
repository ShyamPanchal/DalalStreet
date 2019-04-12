<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ResultPage.aspx.cs" Inherits="DalalStreetClient.Pages.ResultPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="w3-bar w3-white w3-center w3-medium">
        <h1>Game Outcomes</h1>
<div id="tablePlayers" runat="server" CssClass="w3-center">
           <p>
            <asp:table id="PlayersTable" runat="server" GridLines="Horizontal" HorizontalAlign="Center" Width="75%" CssClass="w3-table w3-centered w3-bordered w3-hoverable w3-text-black w3-white w3-round-large">
                   
            </asp:table>
           </p>
             <p>
			    <asp:Button ID="buttonReset" runat="server" ValidationGroup="stop" OnClick="buttonReset_Click" Text="New Game" CssClass="w3-button w3-red w3-padding w3-round" />
		    </p>
        </div>
    </div>
</asp:Content>
