using FoozballBets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoozballBets
{
	public partial class Teams : System.Web.UI.Page
	{
		FoozballBetsEntities4 context = new FoozballBetsEntities4();

		protected void Page_PreRender(object sender, EventArgs e)
		{
			if (Page.User.Identity.IsAuthenticated == false)
			{
				Response.Redirect("~/Account/Login.aspx");
			}

			var userId = context.Users.FirstOrDefault(u => u.UserName == Page.User.Identity.Name).UserId;

			var profileBsh = context.ProfilesBSHes.FirstOrDefault(p => p.UserId == userId);

			List<string> Counts = new List<string>();

			for (int i = 0; i < profileBsh.Points + 1; i++)
			{
				Counts.Add(i.ToString());
			}

			ddlCounter.DataSource = Counts;
			ddlCounter.DataBind();

			var teams = context.Teams.ToList();

			rptrTeams.DataSource = teams;
			ddlTeams.DataSource = teams;

			ddlTeams.DataBind();
			rptrTeams.DataBind();
		}

		protected void lbBet_Click(object sender, EventArgs e)
		{
			TeamBet teamBet = new TeamBet();

			var userId = context.Users.FirstOrDefault(u => u.UserName == Page.User.Identity.Name).UserId;

			var profileBsh = context.ProfilesBSHes.FirstOrDefault(p => p.UserId == userId);

			int teamId = Convert.ToInt32(this.ddlTeams.SelectedValue);

			var team = context.Teams.FirstOrDefault(t => t.TeamId == teamId); 

			var factor = team.TeamFactor;



			teamBet.BetValue = Convert.ToInt32(this.ddlCounter.SelectedValue);

			teamBet.TeamId = teamId;
			teamBet.ProfileId = profileBsh.ProfileId;
			teamBet.BetDate = DateTime.Now;

			int betPoints = Convert.ToInt32(this.ddlCounter.SelectedValue);


			profileBsh.Points = profileBsh.Points - betPoints;

			context.TeamBets.Add(teamBet);

			context.SaveChanges();

			Response.Redirect("Teams.aspx");
		}
	}
}