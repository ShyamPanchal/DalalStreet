<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ManageCategory.aspx.cs" Inherits="DalalStreetClient.Pages.Settings.ManageCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w3-small">
	<h3 runat="server" id ="CompanyName">Company Category</h3>
        <div class="w3-center w3-row-padding">
            <div class="w3-center w3-row-padding w3-margin-top">
			    <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" ValidationGroup="Manage" runat="server" ErrorMessage="Required!" ControlToValidate="textboxName" ForeColor="Red"></asp:RequiredFieldValidator> 
			    <asp:Label runat="server" CssClass="w3-half w3-medium w3-right-align">Name:</asp:Label>
			    <asp:TextBox ID="textboxName" runat="server" Width="20%" ValidationGroup="Manage" CssClass="w3-left-align w3-half w3-input w3-border w3-round w3-medium"></asp:TextBox>
		    </div>
            <div class="w3-center w3-row-padding w3-margin-top">
			    <asp:Button ID="buttonSave" runat="server" ValidationGroup="Manage" OnClick="buttonSave_Click" Text="Save" CssClass="w3-button w3-red w3-padding w3-round w3-center" />
			    <asp:Button ID="buttonCancel" runat="server" ValidationGroup="none" OnClick="buttonCancel_Click" Text="Cancel" CssClass="w3-button w3-red w3-padding w3-round w3-center" />
		    </div>
            <asp:HiddenField ID="HiddenFieldId" runat="server" />
        </div>
    </div>
</asp:Content>
