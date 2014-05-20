using FoozballBets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoozballBets.Admin
{
	public partial class ChangeResult : System.Web.UI.Page
	{
		FoozballBetsEntities4 context = new FoozballBetsEntities4();
		private int matchId;

		protected void Page_Load(object sender, EventArgs e)
		{
			this.matchId = Convert.ToInt32(Request.Params["matchId"]);
		}

		protected void Page_PreRender(object sender, EventArgs e)
		{
			Match match = context.Matches.Find(matchId);

			this.tbMatchResult.Text = match.MatchResult;
		}

		protected void lbSaveMatchResult_Click(object sender, EventArgs e)
		{
			Match match = context.Matches.Find(matchId);

			match.MatchResult = tbMatchResult.Text;

			var bets = context.Bets.Where(b => b.MatchId == match.MatchId);

			var factor = context.Factors.FirstOrDefault(f => f.MatchId == matchId);

			foreach (var bet in bets)
			{
				if (bet.BetForecast == match.MatchResult)
				{
					if (bet.BetForecast == "1")
					{
						bet.ProfilesBSH.Points = bet.ProfilesBSH.Points + Convert.ToInt32(bet.BetValue * factor.Win1);
					}
					if (bet.BetForecast == "X")
					{
						bet.ProfilesBSH.Points = bet.ProfilesBSH.Points + Convert.ToInt32(bet.BetValue * factor.X);
					}
					if (bet.BetForecast == "2")
					{
						bet.ProfilesBSH.Points = bet.ProfilesBSH.Points + Convert.ToInt32(bet.BetValue * factor.Win2);
					}
				}
			}

			if (match.MatchResult == "1")
			{
				match.Team.TeamWins++;
				match.Team1.TeamLoses++;
			}

			if (match.MatchResult == "X")
			{
				match.Team.TeamDraws++;
				match.Team1.TeamDraws++;
			}

			if (match.MatchResult == "2")
			{
				match.Team1.TeamWins++;
				match.Team.TeamLoses++;
			}

			context.SaveChanges();
			Response.Redirect("~/Matches.aspx");
		}
	}
}