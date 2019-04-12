<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ManageCompany.aspx.cs" Inherits="DalalStreetClient.Pages.Settings.ManageCompany" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w3-small">     
    <h3 runat="server" id ="CompanyName">Company</h3>
        <div class="w3-center w3-row-padding">
            <div class="w3-center w3-row-padding ">
			    <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" ValidationGroup="Manage" runat="server" ErrorMessage="Required!" ControlToValidate="textboxName" ForeColor="Red"></asp:RequiredFieldValidator> 
			    <asp:Label runat="server" CssClass="w3-half w3-medium w3-right-align">Name:</asp:Label>
			    <asp:TextBox ID="textboxName" runat="server" Width="20%" ValidationGroup="Manage" CssClass="w3-left-align w3-half w3-input w3-border w3-round w3-medium"></asp:TextBox>
		    </div>
            <div class="w3-center w3-row-padding ">
			    <asp:Label runat="server" CssClass="w3-half w3-medium w3-right-align">Category: &nbsp;</asp:Label>
			    <asp:DropDownList DataValueField="Name" CssClass="w3-left-align w3-half w3-round w3-medium" ID="DropDownListCompanyCategory" Width="20%" runat="server"></asp:DropDownList>	
		    </div>
            <div class="w3-center w3-row-padding ">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Manage" runat="server" ErrorMessage="Required!" ControlToValidate="textboxTotalStock" ForeColor="Red"></asp:RequiredFieldValidator> 
			    <asp:Label runat="server" CssClass="w3-half w3-medium w3-right-align">Total Stock:</asp:Label>
			    <asp:TextBox ID="textboxTotalStock" runat="server" Width="20%" ValidationGroup="Manage" CssClass="w3-left-align w3-half w3-input w3-border w3-round w3-medium"></asp:TextBox>
		    </div>
            <div class="w3-center w3-row-padding ">                
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Manage" runat="server" ErrorMessage="Required!" ControlToValidate="textboxStockValue" ForeColor="Red"></asp:RequiredFieldValidator>                 
			    <asp:Label runat="server" CssClass="w3-half w3-medium w3-right-align">Stock Value:</asp:Label>
			    <asp:TextBox ID="textboxStockValue" runat="server" ValidationGroup="Manage"  Width="20%" CssClass="w3-left-align w3-half w3-input w3-border w3-round w3-medium"></asp:TextBox>
                
		    </div>
            <div class="w3-center w3-row-padding w3-margin-top">
			    <asp:Button ID="buttonSave" runat="server" ValidationGroup="Manage" OnClick="buttonSave_Click" Text="Save" CssClass="w3-button w3-red w3-padding w3-round w3-margin-top" />
			    <asp:Button ID="buttonCancel" runat="server" ValidationGroup="none" OnClick="buttonCancel_Click" Text="Cancel" CssClass="w3-button w3-red w3-padding w3-round w3-margin-top" />
		    </div>
            <asp:HiddenField ID="HiddenFieldId" runat="server" />
        </div>
    </div>
</asp:Content>
