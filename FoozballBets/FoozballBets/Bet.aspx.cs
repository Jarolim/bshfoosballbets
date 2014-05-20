using FoozballBets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoozballBets
{
	public partial class Bet : System.Web.UI.Page
	{
		FoozballBetsEntities4 context = new FoozballBetsEntities4();
		private int matchId;

		protected void Page_PreRender(object sender, EventArgs e)
		{
			var userId = context.Users.FirstOrDefault(u => u.UserName == Page.User.Identity.Name).UserId;

			var profileBsh = context.ProfilesBSHes.FirstOrDefault(p => p.UserId == userId);

			List<string> Counts = new List<string>();

			for (int i = 0; i < profileBsh.Points + 1; i++)
			{
				Counts.Add(i.ToString());
			}

			ddlCounter.DataSource = Counts;
			ddlCounter.DataBind();
		}
		protected void Page_Load(object sender, EventArgs e)
		{
			

			this.matchId = Convert.ToInt32(Request.Params["matchId"]);

			

			
			var match = context.Matches.Find(matchId);
			labelMatch.Text = match.Team.TeamName + " versus " + match.Team1.TeamName;

			var factor = context.Factors.Where(f => f.MatchId == matchId).ToList();
			
				
			gv1X2.DataSource = factor;
			gv1X2.DataBind();
			
		}
		protected void lbBet_Click(object sender, EventArgs e)
		{
			FoozballBets.Models.Bet bet = new FoozballBets.Models.Bet();

			var userId = context.Users.FirstOrDefault(u => u.UserName == Page.User.Identity.Name).UserId;

			var profileBsh = context.ProfilesBSHes.FirstOrDefault(p => p.UserId == userId);

			var match = context.Matches.Find(matchId);

			//var factor = context.Factors.FirstOrDefault(f => f.MatchId == matchId);



			bet.BetValue = Convert.ToInt32(this.ddlCounter.SelectedValue);
			bet.BetForecast = this.ddlForecast.SelectedValue;
			bet.MatchId = matchId;
			bet.ProfileId = profileBsh.ProfileId;
			bet.BetDate = DateTime.Now;

			int betPoints = Convert.ToInt32(this.ddlCounter.SelectedValue);

			profileBsh.Points = profileBsh.Points - betPoints;

			context.Bets.Add(bet);



			//if (bet.BetForecast == match.MatchResult)
			//{
			//	if (bet.BetForecast == "1")
			//	{
			//		profileBsh.Points = profileBsh.Points + Convert.ToInt32(betPoints * factor.Win1);
			//	}
			//	if (bet.BetForecast == "X")
			//	{
			//		profileBsh.Points = profileBsh.Points + Convert.ToInt32(betPoints * factor.X);
			//	}
			//	if (bet.BetForecast == "2")
			//	{
			//		profileBsh.Points = profileBsh.Points + Convert.ToInt32(betPoints * factor.Win2);
			//	}				
			//}


			context.SaveChanges();

			Response.Redirect("Matches.aspx");
		}
	}
}