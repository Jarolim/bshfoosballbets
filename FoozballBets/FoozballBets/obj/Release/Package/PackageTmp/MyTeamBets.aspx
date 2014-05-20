<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyTeamBets.aspx.cs" Inherits="FoozballBets.MyTeamBets" %>

<asp:Content ID="MyTeamBetsContent" ContentPlaceHolderID="MainContent" runat="server">

	<asp:ListView ID="lvBets" runat="server" ItemType="FoozballBets.Models.TeamBet">
		<ItemTemplate>
			<div>Team To Win: <%# Item.Team.TeamName%> 
				Bet Value: <%# Item.BetValue %>
				Bet Date: <%# Item.BetDate %> 
			</div>
		</ItemTemplate>
	</asp:ListView>


</asp:Content>
