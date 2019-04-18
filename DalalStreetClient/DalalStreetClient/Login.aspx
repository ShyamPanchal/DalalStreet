<%@ Page Title="Login" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DalalStreetClient.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 232px;
        }
        .auto-style3 {
            width: 140px;
        }
        .auto-style4 {
            width: 448px;
        }
        .auto-style5 {
            width: 140px;
            height: 43px;
        }
        .auto-style6 {
            width: 232px;
            height: 43px;
        }
        .auto-style7 {
            width: 448px;
            height: 43px;
        }
        .auto-style8 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Login</h1>
	<div class="w3-bar w3-white w3-center w3-medium">
		<p>
            <asp:CustomValidator ID="CustomValidatorDuplicated" ValidationGroup="login" runat="server" ErrorMessage="The user is already in the Game!" ControlToValidate="textboxUserName" ForeColor="Red" OnServerValidate="VerifyUser" Display="Dynamic" ></asp:CustomValidator>
            <asp:CustomValidator ID="CustomValidatorValid" ValidationGroup="login" runat="server" ErrorMessage="There is no game Available!" ControlToValidate="textboxUserName" ForeColor="Red" OnServerValidate="VerifyGame" Display="Dynamic" ></asp:CustomValidator>
            <asp:RequiredFieldValidator ValidationGroup="login" ID="RequiredFieldValidatorUserName" runat="server" ErrorMessage="User Name Required" ControlToValidate="textboxUserName" ForeColor="Red" Display="Dynamic" ></asp:RequiredFieldValidator>
			<asp:TextBox ID="textboxUserName" runat="server" ValidationGroup="login" CssClass="w3-input w3-border w3-round" placeholder="Username"></asp:TextBox>			 
            </p>
			 <hr/>
		<p>
			<asp:Button ID="buttonLogin" runat="server" ValidationGroup="login" OnClick="buttonEnter_Click" Text="Enter" CssClass="w3-button w3-red w3-padding w3-round" />

		</p>

	</div>
</asp:Content>
