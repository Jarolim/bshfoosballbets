using FoozballBets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoozballBets
{
	public partial class Profile : System.Web.UI.Page
	{
		FoozballBetsEntities4 context = new FoozballBetsEntities4();

		protected void Page_Load(object sender, EventArgs e)
		{
			if (Page.User.Identity.IsAuthenticated == false)
			{
				Response.Redirect("~/Account/Login.aspx");
			}
			//labelName.Text = context.ProfilesBSHes;

			var userId = context.Users.FirstOrDefault(u => u.UserName == Page.User.Identity.Name).UserId;

			var profileBsh = context.ProfilesBSHes.FirstOrDefault(p => p.UserId == userId);

			labelName.Text = profileBsh.Name;
			labelUsername.Text = profileBsh.Name;
			labelPoints.Text = profileBsh.Points.ToString();
			imageProfilePic.ImageUrl = profileBsh.ProfilePicPath;
		}
	}
}