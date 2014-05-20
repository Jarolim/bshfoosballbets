using FoozballBets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoozballBets
{
	public partial class _Default : Page
	{
		FoozballBetsEntities4 context = new FoozballBetsEntities4();

		protected void Page_Load(object sender, EventArgs e)
		{
			var profiles = context.ProfilesBSHes.OrderByDescending(p => p.Points).ToList();

			lvCurrentPoll.DataSource = profiles;
			lvCurrentPoll.DataBind();
		}
	}
}