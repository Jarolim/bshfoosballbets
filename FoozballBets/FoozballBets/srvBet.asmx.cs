using FoozballBets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace FoozballBets
{
	/// <summary>
	/// Summary description for srvBet
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	// [System.Web.Script.Services.ScriptService]
	public class srvBet : System.Web.Services.WebService
	{
		FoozballBetsEntities4 context = new FoozballBetsEntities4();

		[WebMethod]
		public void CloseBets(int matchID, bool check)
		{
			var thisMatch = context.Matches.Find(matchID);
			if (check)
			{
				thisMatch.IsPlayed = true;
			}
			else
			{
				thisMatch.IsPlayed = false;
			}
			
			context.SaveChanges();
		}
	}
}