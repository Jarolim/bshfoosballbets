using FoozballBets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoozballBets
{
	public partial class MyTeamBets : System.Web.UI.Page
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

			var bets = context.TeamBets.Where(b => b.ProfileId == profileBsh.ProfileId);

			this.lvBets.DataSource = bets.ToList();
			lvBets.DataBind();

		}
	}
}