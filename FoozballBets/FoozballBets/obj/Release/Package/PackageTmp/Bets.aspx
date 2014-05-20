<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Bets.aspx.cs" Inherits="FoozballBets.Bets" %>

<asp:Content ID="BetsContent" ContentPlaceHolderID="MainContent" runat="server">

	<asp:ListView ID="lvBets" runat="server" ItemType="FoozballBets.Models.Bet" OnItemDataBound="lvBets_ItemDataBound" OnItemInserting="lvBets_ItemInserting">
		<ItemTemplate>
			<div><%# Item.Match.Team.TeamName %> versus <%# Item.Match.Team1.TeamName %> 
				Bet Value: <%# Item.BetValue %>
				Bet Forecast: <%# Item.BetForecast %> 
				Bet Date: <%#Item.BetDate %>
				<%--Expected win : <asp:Label ID="expectedWinValue" Text="Expected Win" runat="server" />
				Bet: <asp:Label ID="wonOrLost" Text="Won or Lost" runat="server" />--%>
			</div>
		</ItemTemplate>
	</asp:ListView>

</asp:Content>
