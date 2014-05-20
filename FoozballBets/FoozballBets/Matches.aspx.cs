using FoozballBets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace FoozballBets
{
	public partial class Matches : System.Web.UI.Page
	{
		FoozballBetsEntities4 context = new FoozballBetsEntities4();

		List<int> selectedCheckboxes = new List<int>();

		protected void Page_PreRender(object sender, EventArgs e)
		{
			thisUser.Text = Page.User.Identity.Name;
			if (Page.User.Identity.IsAuthenticated == false)
			{
				Response.Redirect("~/Account/Login.aspx");
			}

			var matches = context.Matches.ToList();
			
			


			rptrMatches.DataSource = matches;
			rptrMatches.DataBind();

			
			//div1.Style.Add("width", "50px");

			//Control ctrl = rptrMatches.FindControl("div3");		

			////rptrMatches.FindControl("div3").Attributes.Add("class", "id" + i);

			////HtmlGenericControl divControl = rptrMatches.FindControl("div3") as HtmlGenericControl;
			////divControl.Style.Add("width", "100px");
		}

		protected void rptrMatches_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			foreach (RepeaterItem item in rptrMatches.Items)
			{
				HtmlGenericControl b1 = (HtmlGenericControl)e.Item.FindControl("betContainer");
				CheckBox c1 = (CheckBox)item.FindControl("betHide");
				if (c1.Checked)
				{
					b1.Visible = false;
				}
			}
			//if (Page.User.Identity.Name == "Administrator")
			//{
				HtmlGenericControl a1 = (HtmlGenericControl)e.Item.FindControl("MatchContainer");
				//HtmlGenericControl b1 = (HtmlGenericControl)e.Item.FindControl("betContainer");
					//a1.HRef = "Admin/ChangeResult.aspx?matchId=<%# Item.MatchId %>";
					a1.Visible = true;
				//CheckBox c1 = (CheckBox)e.Item.FindControl("betHide");
				//	if (c1.Checked)
				//	{
				//		b1.Visible = false;
				//	}
			//}		
		}

		protected void rptrMatches_ItemCreated(object sender, RepeaterItemEventArgs e)
		{
			if (Page.User.Identity.Name == "Administrator")
			{
				//foreach (var item in rptrMatches.Items)
				//{

				//	HtmlAnchor a1 = (HtmlAnchor)e.Item.FindControl("btnChangeResult");
				//	a1.HRef = "Admin/ChangeResult.aspx?matchId=<%# Item.MatchId %>";
				//	a1.Visible = true;
				//}				
			}	
		}


	}
}