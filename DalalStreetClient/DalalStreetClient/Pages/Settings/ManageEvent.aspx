<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ManageEvent.aspx.cs" Inherits="DalalStreetClient.Pages.Settings.ManageEvent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="w3-small">     
            <h3 runat="server" id ="Event">Event/News</h3>
            <div class="w3-center w3-row-padding">                
			    <asp:Label runat="server" CssClass="w3-half w3-medium w3-right-align">Company: &nbsp;</asp:Label>
			    <asp:DropDownList ID="DropDownListCompany" Width="20%" CssClass="w3-left-align w3-half w3-round w3-medium" runat="server"></asp:DropDownList>
		    </div>
            <div class="w3-center w3-row-padding">          
			    <asp:Label runat="server" CssClass="w3-half w3-medium w3-right-align">Event Type: &nbsp;</asp:Label>
			    <asp:DropDownList ID="DropDownListEventType" Width="20%" CssClass="w3-left-align w3-half w3-round w3-medium" runat="server"></asp:DropDownList>	
		    </div>
            <div class="w3-center w3-row-padding w3-margin-top">
			    <asp:Button ID="buttonSave" runat="server" ValidationGroup="Manage" OnClick="buttonSave_Click" Text="Save" CssClass="w3-button w3-red w3-padding w3-round" />
			    <asp:Button ID="buttonCancel" runat="server" ValidationGroup="none" OnClick="buttonCancel_Click" Text="Cancel" CssClass="w3-button w3-red w3-padding w3-round" />
		    </div>
            <asp:HiddenField ID="HiddenFieldId" runat="server" />
        </div>
</asp:Content>
