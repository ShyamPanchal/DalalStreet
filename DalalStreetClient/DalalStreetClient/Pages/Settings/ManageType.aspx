<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ManageType.aspx.cs" Inherits="DalalStreetClient.Pages.Settings.ManageType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="w3-bar w3-white w3-center w3-medium">        
         <h1>Event / News Type</h1>
            <div class="w3-half w3-padding w3-left-align">
			    <h5>Type String:</h5>
			    <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" ValidationGroup="Manage" runat="server" ErrorMessage="Required!" ControlToValidate="textboxTypeString" ForeColor="Red"></asp:RequiredFieldValidator> 
			    <asp:TextBox ID="textboxTypeString" runat="server" ValidationGroup="Manage" CssClass="w3-input w3-border w3-round"></asp:TextBox>
		    </div>
            <div class="w3-half w3-padding w3-left-align">
			    <h5>Likelyhood:</h5>
                <asp:RangeValidator ID="RangeValidator1" runat="server" ValidationGroup="Manage" MinimumValue="0" MaximumValue="100" ControlToValidate="textboxLikelyhood" ErrorMessage="Must be between 0 and 100!" ForeColor="Red"></asp:RangeValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Manage" runat="server" ErrorMessage="Required!" ControlToValidate="textboxLikelyhood" ForeColor="Red"></asp:RequiredFieldValidator> 
			    <asp:TextBox ID="textboxLikelyhood" runat="server" ValidationGroup="Manage" CssClass="w3-input w3-border w3-round"></asp:TextBox>
		    </div>
            <div class="w3-half w3-padding w3-left-align">
			    <h5>Effect On Self:</h5>
                <asp:RangeValidator ID="RangeValidator2" runat="server" ValidationGroup="Manage" MinimumValue="-1" MaximumValue="1" ControlToValidate="textboxEffectOnSelf" ErrorMessage="Must be between -100 and 100!" ForeColor="Red"></asp:RangeValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Manage" runat="server" ErrorMessage="Required!" ControlToValidate="textboxEffectOnSelf" ForeColor="Red"></asp:RequiredFieldValidator> 
			    <asp:TextBox ID="textboxEffectOnSelf" runat="server" ValidationGroup="Manage" CssClass="w3-input w3-border w3-round"></asp:TextBox>
		    </div>
            <div class="w3-half w3-padding w3-left-align">
			    <h5>Effect On Others:</h5>
                <asp:RangeValidator ID="RangeValidator3" runat="server" ValidationGroup="Manage" MinimumValue="-1" MaximumValue="1" ControlToValidate="textboxEffectOnOthers" ErrorMessage="Must be between -100 and 100!" ForeColor="Red"></asp:RangeValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="Manage" runat="server" ErrorMessage="Required!" ControlToValidate="textboxEffectOnOthers" ForeColor="Red"></asp:RequiredFieldValidator> 
			    <asp:TextBox ID="textboxEffectOnOthers" runat="server" ValidationGroup="Manage" CssClass="w3-input w3-border w3-round"></asp:TextBox>
		    </div>

            <div class="w3-padding w3-left-align w3-large">
			    <asp:Button ID="buttonSave" runat="server" ValidationGroup="Manage" OnClick="buttonSave_Click" Text="Save" CssClass="w3-button w3-black w3-padding w3-round w3-margin-top" />
			    <asp:Button ID="buttonCancel" runat="server" ValidationGroup="none" OnClick="buttonCancel_Click" Text="Cancel" CssClass="w3-button w3-black w3-padding w3-round w3-margin-top" />
		    </div>
            <asp:HiddenField ID="HiddenFieldId" runat="server" />
        </div>
</asp:Content>
