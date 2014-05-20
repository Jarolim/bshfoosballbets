<%@ Page Title="Matches" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Matches.aspx.cs" Inherits="FoozballBets.Matches" %>

<asp:Content ID="MatchesContent" ContentPlaceHolderID="MainContent" runat="server">
	<script type="text/javascript">
		$(document).ready(function () {
			debugger;
			var checkUser = $("#MainContent_thisUser").text();
			
			if (checkUser != "Administrator") {
				$(".btnIsPlayed").hide();
				$(".toHide").hide();
			}
			else {
				$(".btnIsPlayed").show();
				$(".toHide").show();
			}
		});
		</script>

	<asp:Label  ID="thisUser" runat="server" />
	<asp:Repeater ID="rptrMatches" runat="server" ItemType="FoozballBets.Models.Match" DataMember="MatchId" OnItemCreated="rptrMatches_ItemCreated" OnItemDataBound="rptrMatches_ItemDataBound">
		<ItemTemplate>
			<li>
				<%#: Item.Team.TeamName %> <strong><em>versus</em></strong> <%#: Item.Team1.TeamName %> <%#: Item.MatchResult %>

				<asp:GridView runat="server"
					AutoGenerateColumns="false"
					ItemType="FoozballBets.Models.Factor"
					DataSource="<%# Item.Factors %>">
					<Columns>
						<asp:BoundField DataField="Win1" HeaderText="1" />
						<asp:BoundField DataField="X" HeaderText="X" />
						<asp:BoundField DataField="Win2" HeaderText="2" />
						<%--	<%# Item.Win1 %>
								<%# Item.X %>
								<%# Item.Win2 %>--%>
					</Columns>
				</asp:GridView>
				<div class="matches_buttons">
					<div id="MatchContainer" runat="server" visible="false" class="buttons_toCheck">
						<a href='Admin/ChangeResult.aspx?matchId=<%# DataBinder.Eval(Container.DataItem, "MatchId") %>' id="btnChangeResult" class="toHide" visible="true">Change Result</a>
						<asp:CheckBox ID="betHide" Text="" CssClass="toHide" runat="server"/>						
						<%--<asp:Button ID="ButtonHideDiv" Text="ButtonHideDiv" runat="server" CommandArgument="<%#Item.MatchId%>" OnCommand="ButtonHideDiv_Click" />--%>
				<label class="btnIsPlayed">IsPlayed: </label> <input type="button" name="name" id="<%#Item.MatchId%>" class="btnIsPlayed" Value="<%#Item.IsPlayed%>" onclick="return false;" />											
					</div>
					<div id="div<%#Item.MatchId %>">
						<a href="Bet.aspx?matchId= <%#Item.MatchId %>" class="matches_button">Bet</a>
					</div>
				</div>
				<hr />
					<script type="text/javascript">

						$(function () {
							$(".buttons_toCheck").each(function () {
								$(".btnIsPlayed").each(function () {
									var btn = $(this);
									if ($(this).val() == "True") {										
										$("#div" + btn.attr("id")).hide();																
									}
								});
							});					
						});

						var checkAdd = true;
						if ($("#<%#Item.MatchId%>").val() == "False")
						{
							checkAdd = false;							
						}

						$("#<%#Item.MatchId%>").on("click", function () {
						    var userId = <%#Item.MatchId%>
								$.ajax({
									url: "/srvBet.asmx/CloseBets",
									type: "POST",
									data:
										{										
											matchID: userId,
											check: checkAdd,
										},
									success: function (data) {
																
										if (checkAdd) {
											$("#<%#Item.MatchId%>").val("True");
											checkAdd = !checkAdd;
										}
										else
										{
											$("#<%#Item.MatchId%>").val("False");
											checkAdd = !checkAdd;
										}										
									}
								});

							});


						</script>

				<%--<div id="div<%#: Item.MatchId %>" style="width: 648px; height: 259px; background-color: red;">
				</div>
				<script>

					$("#div<%#: Item.MatchId %>").css('width', '<%#: Item.MatchId %>');
					$("#div<%#: Item.MatchId %>").attr('runat', 'server');

				</script>--%>
			</li>
		</ItemTemplate>
	</asp:Repeater>
	<%--<div id="div1" runat="server" style="width: 648px; height: 259px; background-color: red;">
	</div>--%>
</asp:Content>
