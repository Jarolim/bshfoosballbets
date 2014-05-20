using FoozballBets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoozballBets.Admin
{
	public partial class AdminPanel : System.Web.UI.Page
	{
		FoozballBetsEntities4 context = new FoozballBetsEntities4();

		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void lbTournamentEnd_Click(object sender, EventArgs e)
		{
			var teams = context.Teams.OrderByDescending(t => t.TeamWins);

			var teamWithMostWins = teams.FirstOrDefault();

			var bets = context.TeamBets.Where(b => b.TeamId == teamWithMostWins.TeamId);

			var factor = teamWithMostWins.TeamFactor;

			foreach (var bet in bets)
			{
				if (bet.TeamId == teamWithMostWins.TeamId)
				{			
					bet.ProfilesBSH.Points = bet.ProfilesBSH.Points + Convert.ToInt32(bet.BetValue * factor);					
				}
			}

			context.SaveChanges();
			Response.Redirect("~/Admin/AdminPanel.aspx");
		}
	}
}