<%@ Page Title="" Async="true" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="GameSettings.aspx.cs" Inherits="DalalStreetClient.Pages.GameSettings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h1>Settings</h1>
        <div id="APIUrl" runat="server" CssClass="w3-center">            
            <asp:CustomValidator ID="CustomValidatorWorking" ValidationGroup="checkAPI" runat="server" ErrorMessage="Working!" ControlToValidate="textboxAPUIrl" ForeColor="Green" OnServerValidate="VerifyAPIWorking" Display="Dynamic" ></asp:CustomValidator>
            <asp:CustomValidator ID="CustomValidatorValid" ValidationGroup="checkAPI" runat="server" ErrorMessage="Failed!" ControlToValidate="textboxAPUIrl" ForeColor="Red" OnServerValidate="VerifyAPI" Display="Dynamic" ></asp:CustomValidator>
             <div class="w3-center w3-row-padding w3-right-align">
                <asp:RequiredFieldValidator ValidationGroup="checkAPI" ID="RequiredFieldValidatorUserName" runat="server" ErrorMessage="URL Required!" ControlToValidate="textboxAPUIrl" ForeColor="Red" Display="Dynamic" ></asp:RequiredFieldValidator>
                 <asp:Label runat="server" CssClass="w3-half w3-medium w3-right-align">URL:</asp:Label>
			    <asp:TextBox ID="textboxAPUIrl" Width="20%" runat="server" ValidationGroup="checkAPI" CssClass="w3-half w3-input w3-border w3-round w3-left-align"  placeholder="API URL"></asp:TextBox>			 
            </div>
             <div class="w3-center w3-row-padding w3-margin-top"> 
			    <asp:Button ID="buttonCheck" runat="server" ValidationGroup="checkAPI" OnClick="buttonCheckAPI_Click" Text="Check" CssClass="w3-button w3-red w3-padding w3-round" />
                <asp:Button ID="buttonUpdate" runat="server" ValidationGroup="checkAPI" OnClick="buttonUpdateAPI_Click" Text="Update" CssClass="w3-button w3-red w3-padding w3-round" />
            </div>
            <br/>
        </div>
		<div id="tablesSettings" runat="server" CssClass="w3-center">
            <div class="w3-center w3-row-padding w3-margin-top"> 
			    <asp:Button ID="buttonReset" runat="server" OnClick="buttonReset_click" Text="Reset Data" CssClass="w3-button w3-red w3-padding w3-round" />                
            </div>
            <div id="companyNames" runat="server" CssClass="w3-center">
                <h3>New Company Name</h3>
                <asp:table id="CompanyNameTable" runat="server" GridLines="Horizontal" HorizontalAlign="Center" Width="75%" CssClass="w3-table w3-centered w3-bordered w3-hoverable w3-text-black w3-white w3-round-large">
                </asp:table>
            </div>
            <div id="companyCategory" runat="server" CssClass="w3-center">
                <h3>Company Category</h3>
                <asp:table id="CompanyCategoryTable"  runat="server" GridLines="Horizontal" HorizontalAlign="Center" Width="75%" CssClass="w3-table w3-centered w3-bordered w3-hoverable w3-text-black w3-white w3-round-large">
                </asp:table>
            </div>
            <div id="company" runat="server" CssClass="w3-center">
                <h3>Company</h3>
                <asp:table id="CompanyTable" runat="server" GridLines="Horizontal" HorizontalAlign="Center" Width="75%" CssClass="w3-table w3-centered w3-bordered w3-hoverable w3-text-black w3-white w3-round-large">
                </asp:table>
            </div>

            <div id="eventType" runat="server" CssClass="w3-center">
                <h3>Event Types</h3>
                <asp:table id="EventTypeTable"  runat="server" GridLines="Horizontal" HorizontalAlign="Center" Width="75%" CssClass="w3-table w3-centered w3-bordered w3-hoverable w3-text-black w3-white w3-round-large">
                </asp:table>
            </div>
            <div id="news" runat="server" CssClass="w3-center">
                <h3>News / Events</h3>
                <asp:table id="NewsEventsTable" runat="server" GridLines="Horizontal" HorizontalAlign="Center" Width="75%" CssClass="w3-table w3-centered w3-bordered w3-hoverable w3-text-black w3-white w3-round-large">
                </asp:table>
            </div>
        </div>
</asp:Content>
