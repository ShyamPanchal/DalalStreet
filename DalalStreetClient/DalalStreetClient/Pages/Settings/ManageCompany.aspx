<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ManageCompany.aspx.cs" Inherits="DalalStreetClient.Pages.Settings.ManageCompany" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="w3-bar w3-white w3-center w3-medium">        
         <h1>Company</h1>
            <div class="w3-half w3-padding w3-left-align">
			    <h5>Name:</h5>
			    <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" ValidationGroup="Manage" runat="server" ErrorMessage="Required!" ControlToValidate="textboxName" ForeColor="Red"></asp:RequiredFieldValidator> 
			    <asp:TextBox ID="textboxName" runat="server" ValidationGroup="Manage" CssClass="w3-input w3-border w3-round"></asp:TextBox>
		    </div>
            <div class="w3-left-align w3-padding">            
			    <h5>Category: &nbsp;</h5>
                <div class="w3-padding w3-large w3-left-align">
			        <asp:DropDownList ID="DropDownListCompanyCategory" runat="server"></asp:DropDownList>
		        </div>		
		    </div>
		    </div>
            <div class="w3-half w3-padding w3-left-align">
			    <h5>Total Stock:</h5>
                <asp:RangeValidator ID="RangeValidator1" runat="server" ValidationGroup="Manage" MinimumValue="0" ControlToValidate="textboxTotalStock" ErrorMessage="Must be between More than 0!" ForeColor="Red"></asp:RangeValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Manage" runat="server" ErrorMessage="Required!" ControlToValidate="textboxTotalStock" ForeColor="Red"></asp:RequiredFieldValidator> 
			    <asp:TextBox ID="textboxTotalStock" runat="server" ValidationGroup="Manage" CssClass="w3-input w3-border w3-round"></asp:TextBox>
		    </div>
            <div class="w3-half w3-padding w3-left-align">
			    <h5>Stock Value:</h5>
                <asp:RangeValidator ID="RangeValidator2" runat="server" ValidationGroup="Manage" MinimumValue="0" ControlToValidate="textboxStockValue" ErrorMessage="Must be between More than 0!" ForeColor="Red"></asp:RangeValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Manage" runat="server" ErrorMessage="Required!" ControlToValidate="textboxStockValue" ForeColor="Red"></asp:RequiredFieldValidator> 
			    <asp:TextBox ID="textboxStockValue" runat="server" ValidationGroup="Manage" CssClass="w3-input w3-border w3-round"></asp:TextBox>
		    </div>
            <div class="w3-padding w3-left-align w3-large">
			    <asp:Button ID="buttonSave" runat="server" ValidationGroup="Manage" OnClick="buttonSave_Click" Text="Save" CssClass="w3-button w3-black w3-padding w3-round w3-margin-top" />
			    <asp:Button ID="buttonCancel" runat="server" ValidationGroup="none" OnClick="buttonCancel_Click" Text="Cancel" CssClass="w3-button w3-black w3-padding w3-round w3-margin-top" />
		    </div>
            <asp:HiddenField ID="HiddenFieldId" runat="server" />
        </div>
</asp:Content>
