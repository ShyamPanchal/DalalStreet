<%@ Page Title="Waiting Room" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AdminWaitingRoom.aspx.cs" Inherits="DalalStreetClient.Pages.AdminWaitingRoom" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Waiting Room</h1>
		<div id="tablePlayers" runat="server" CssClass="w3-center">
            <p>
                <asp:ScriptManager ID="ScriptManager" runat="server" />
                <asp:Timer ID="TimerToRefresh" OnTick="Timer_Tick" runat="server" Interval="5000"></asp:Timer>
                <asp:UpdatePanel ID="PlayerTablePanel" runat="server" UpdateMode="Conditional">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="TimerToRefresh" />
                    </Triggers>
                    <ContentTemplate>
                        <asp:table id="PlayersTable" runat="server" GridLines="Horizontal" HorizontalAlign="Center" Width="75%" CssClass="w3-table w3-centered w3-bordered w3-hoverable w3-text-black w3-white w3-round-large">
                   
                        </asp:table>
                        <div>
                            Times updated <asp:Label ID="Update_Times" runat="server"></asp:Label>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </p>
        </div>
</asp:Content>
