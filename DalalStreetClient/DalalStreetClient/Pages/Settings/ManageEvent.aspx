<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ManageEvent.aspx.cs" Inherits="DalalStreetClient.Pages.Settings.ManageEvent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="w3-bar w3-white w3-center w3-medium">        
         <h1>Events / News</h1>
            <div class="w3-left-align w3-padding">            
			    <h5>Company: &nbsp;</h5>
                <div class="w3-padding w3-large w3-left-align">
			        <asp:DropDownList ID="DropDownListCompany" runat="server"></asp:DropDownList>
		        </div>		
		    </div>
            <div class="w3-left-align w3-padding">            
			    <h5>Event Type: &nbsp;</h5>
                <div class="w3-padding w3-large w3-left-align">
			        <asp:DropDownList ID="DropDownListEventType" runat="server"></asp:DropDownList>
		        </div>		
		    </div>
            <div class="w3-padding w3-left-align w3-large">
			    <asp:Button ID="buttonSave" runat="server" ValidationGroup="Manage" OnClick="buttonSave_Click" Text="Save" CssClass="w3-button w3-black w3-padding w3-round w3-margin-top" />
			    <asp:Button ID="buttonCancel" runat="server" ValidationGroup="none" OnClick="buttonCancel_Click" Text="Cancel" CssClass="w3-button w3-black w3-padding w3-round w3-margin-top" />
		    </div>
            <asp:HiddenField ID="HiddenFieldId" runat="server" />
        </div>
</asp:Content>
