<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="GameSettings.aspx.cs" Inherits="DalalStreetClient.Pages.GameSettings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h1>Settings</h1>
		<div id="tablesSettings" runat="server" CssClass="w3-center">
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
