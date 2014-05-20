<%@ Page Title="Teams" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Teams.aspx.cs" Inherits="FoozballBets.Teams" %>

<asp:Content ID="TeamsContent" ContentPlaceHolderID="MainContent" runat="server">

	<asp:Repeater ID="rptrTeams" runat="server" ItemType="FoozballBets.Models.Team">
		<ItemTemplate>
			<li>
				<span>Team: <%#: Item.TeamName %></span> <span>Factor: <%#: Item.TeamFactor %></span>             
			</li>
		</ItemTemplate>
	</asp:Repeater>

	<br />
	<br />
	<br />

	<h4>Bet for the team that is going to win the whole tournament</h4>

	<asp:DropDownList ID="ddlTeams" runat="server" DataTextField="TeamName" DataValueField="TeamId"></asp:DropDownList>
	
	<br />


	Points: <asp:DropDownList ID="ddlCounter" runat="server">
		
	</asp:DropDownList>
	
	<%--<asp:TextBox ID="tbBet" runat="server" />--%>

	<br />

	<asp:LinkButton ID="lbBet" Text="Bet" runat="server" OnClick="lbBet_Click" />
</asp:Content>
