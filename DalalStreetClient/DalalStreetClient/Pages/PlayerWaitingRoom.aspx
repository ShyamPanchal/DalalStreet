<%@ Page Title="Waiting Room" Async="true" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PlayerWaitingRoom.aspx.cs" Inherits="DalalStreetClient.Pages.PlayerWaitingRoom" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="w3-bar w3-white w3-center w3-medium">
        <h1>Waiting Room</h1>
		<div id="tablePlayers" runat="server" CssClass="w3-center">
            <p>
                <asp:ScriptManager ID="ScriptManager" runat="server" />
                <asp:Timer ID="TimerToRefresh" OnTick="Timer_Tick" runat="server" Interval="2000"></asp:Timer>
                <asp:UpdatePanel ID="PlayerTablePanel" runat="server" UpdateMode="Conditional">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="TimerToRefresh" />
                    </Triggers>
                    <ContentTemplate>
                        <asp:table id="PlayersTable" runat="server" GridLines="Horizontal" HorizontalAlign="Center" Width="75%" CssClass="w3-table w3-centered w3-bordered w3-hoverable w3-text-black w3-white w3-round-large">
                   
                        </asp:table>
                        <!--div>
                            Times updated <asp:Label ID="Update_Times" runat="server"></asp:Label>
                        </div-->
                    </ContentTemplate>
                </asp:UpdatePanel>
            </p>
        </div>

	</div>
</asp:Content>
