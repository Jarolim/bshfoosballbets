using FoozballBets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoozballBets
{
	public partial class Bets : System.Web.UI.Page
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

			//Label expectedWinValue = (Label)this.lvBets.FindControl("expectedWinValue");

			//expectedWinValue.Text = "";
			//var ex = ((Label)FindControlRecursive(this, "expectedWinValue"));
			//var wo = ((Label)FindControlRecursive(this, "wonOrLost"));
			//ex.Text = "omg";
			//wo.Text = "wonOrLost";

			var bets = context.Bets.Where(b => b.ProfileId == profileBsh.ProfileId);

			this.lvBets.DataSource = bets.ToList();
			lvBets.DataBind();

		}

		public Control FindControlRecursive(Control control, string id)
		{
			if (control == null) return null;
			//try to find the control at the current level
			Control ctrl = control.FindControl(id);

			if (ctrl == null)
			{
				//search the children
				foreach (Control child in control.Controls)
				{
					ctrl = FindControlRecursive(child, id);

					if (ctrl != null) break;
				}
			}
			return ctrl;
		}


		protected void lvBets_ItemDataBound(object sender, ListViewItemEventArgs e)
		{
			
		}

		protected void lvBets_ItemInserting(object sender, ListViewInsertEventArgs e)
		{
			if (e.Item.ItemType == ListViewItemType.DataItem)
			{
				var userId = context.Users.FirstOrDefault(u => u.UserName == Page.User.Identity.Name).UserId;
				var profileBsh = context.ProfilesBSHes.FirstOrDefault(p => p.UserId == userId);

				var expectedWinValue = e.Item.FindControl("expectedWinValue") as Label;
				var wonOrLost = e.Item.FindControl("wonOrLost") as Label;

				var bets = context.Bets.Where(b => b.ProfileId == profileBsh.ProfileId);

				foreach (var bet in bets)
				{
					var matchId = bet.MatchId;
					var factor = context.Factors.FirstOrDefault(f => f.MatchId == matchId);

					if (bet.BetForecast == "1")
					{
						expectedWinValue.Text = Convert.ToInt32(bet.BetValue * factor.Win1).ToString();
						wonOrLost.Text = "cd";
					}

					if (bet.BetForecast == "X")
					{
						expectedWinValue.Text = Convert.ToInt32(bet.BetValue * factor.X).ToString();
						wonOrLost.Text = "cd";
					}

					if (bet.BetForecast == "2")
					{
						expectedWinValue.Text = Convert.ToInt32(bet.BetValue * factor.Win2).ToString();
						wonOrLost.Text = "cd";
					}
				}
			}
		}
	}
}