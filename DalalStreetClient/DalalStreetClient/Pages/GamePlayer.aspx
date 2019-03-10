<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="GamePlayer.aspx.cs" Inherits="DalalStreetClient.Pages.GamePlayer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="w3-bar w3-white w3-center w3-medium">

        <asp:ScriptManager ID="ScriptManager" runat="server" />
        <asp:Timer ID="TimerToRefresh" OnTick="Timer_Tick" runat="server" Interval="5000"></asp:Timer>
        <asp:UpdatePanel ID="GamePanel" runat="server" UpdateMode="Conditional">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="TimerToRefresh" />
            </Triggers>
            <ContentTemplate>
		        <div id="tableStocks" runat="server" CssClass="w3-center" style="width: 60%">
           
                </div>
                <div id="tableNews" runat="server" CssClass="w3-center" style="width: 40%">
           
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
	</div>
</asp:Content>
