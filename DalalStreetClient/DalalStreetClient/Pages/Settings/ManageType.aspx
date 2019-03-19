<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ManageType.aspx.cs" Inherits="DalalStreetClient.Pages.Settings.ManageType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="w3-small">     
            <h3 runat="server" id ="Event">Event/News Type</h3>
            <div class="w3-center w3-row-padding">       
			    <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" ValidationGroup="Manage" runat="server" ErrorMessage="Required!" ControlToValidate="textboxTypeString" ForeColor="Red"></asp:RequiredFieldValidator> 
			    <asp:Label runat="server" CssClass="w3-half w3-medium w3-right-align">Type String:</asp:Label>
			    <asp:TextBox ID="textboxTypeString" runat="server" ValidationGroup="Manage" Width="20%" CssClass="w3-left-align w3-half w3-input w3-border w3-round w3-medium"></asp:TextBox>
		    </div>
            <div class="w3-center w3-row-padding">
                <asp:RangeValidator ID="RangeValidator1" runat="server" ValidationGroup="Manage" MinimumValue="0" MaximumValue="100" ControlToValidate="textboxLikelyhood" ErrorMessage="Must be between 0 and 100!" ForeColor="Red"></asp:RangeValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Manage" runat="server" ErrorMessage="Required!" ControlToValidate="textboxLikelyhood" ForeColor="Red"></asp:RequiredFieldValidator> 
			    <asp:Label runat="server" CssClass="w3-half w3-medium w3-right-align">Likelyhood:</asp:Label>
			    <asp:TextBox ID="textboxLikelyhood" runat="server" ValidationGroup="Manage" Width="20%" CssClass="spinner w3-left-align w3-half w3-input w3-border w3-round w3-medium"></asp:TextBox>
		    </div>
            <div class="w3-center w3-row-padding">
                <asp:RangeValidator ID="RangeValidator2" runat="server" ValidationGroup="Manage" MinimumValue="0" MaximumValue="1" ControlToValidate="textboxEffectOnSelf" ErrorMessage="Must be between -100 and 100!" ForeColor="Red"></asp:RangeValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Manage" runat="server" ErrorMessage="Required!" ControlToValidate="textboxEffectOnSelf" ForeColor="Red"></asp:RequiredFieldValidator> 
			    <asp:Label runat="server" CssClass="w3-half w3-medium w3-right-align">Effect On Self:</asp:Label>
			    <asp:TextBox ID="textboxEffectOnSelf" runat="server" ValidationGroup="Manage" Width="20%" CssClass="w3-left-align w3-half w3-input w3-border w3-round w3-medium"></asp:TextBox>
		    </div>
            <div class="w3-center w3-row-padding">
                <asp:RangeValidator ID="RangeValidator3" runat="server" ValidationGroup="Manage" MinimumValue="0" MaximumValue="1" ControlToValidate="textboxEffectOnOthers" ErrorMessage="Must be between -100 and 100!" ForeColor="Red"></asp:RangeValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="Manage" runat="server" ErrorMessage="Required!" ControlToValidate="textboxEffectOnOthers" ForeColor="Red"></asp:RequiredFieldValidator> 
			    <asp:Label runat="server" CssClass="w3-half w3-medium w3-right-align">Effect On Others:</asp:Label>
			    <asp:TextBox ID="textboxEffectOnOthers" runat="server" ValidationGroup="Manage" Width="20%" CssClass="w3-left-align w3-half w3-input w3-border w3-round w3-medium"></asp:TextBox>
		    </div>
            <div class="w3-center w3-row-padding w3-margin-top">
			    <asp:Button ID="buttonSave" runat="server" ValidationGroup="Manage" OnClick="buttonSave_Click" Text="Save" CssClass="w3-button w3-red w3-padding w3-round" />
			    <asp:Button ID="buttonCancel" runat="server" ValidationGroup="none" OnClick="buttonCancel_Click" Text="Cancel" CssClass="w3-button w3-red w3-padding w3-round" />
		    </div>
            <asp:HiddenField ID="HiddenFieldId" runat="server" />
        </div>
</asp:Content>
