<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="GameAdmin.aspx.cs" Inherits="DalalStreetClient.Pages.GameAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="w3-bar w3-white w3-center w3-medium">        
         <h1>Players</h1>
		<div id="tablePlayers" runat="server" CssClass="w3-center">
           <p></p>
             <p>
			    <asp:Button ID="buttonStop" runat="server" ValidationGroup="stop" OnClick="buttonStop_Click" Text="Stop Game" CssClass="w3-button w3-red w3-padding w3-round" />
		    </p>
        </div>
	</div>
</asp:Content>
