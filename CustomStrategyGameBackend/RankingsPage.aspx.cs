using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomStrategyGameBackend
{
    public partial class RankingsPage : System.Web.UI.Page
    {
        public string uname;
        public RankingsPage rankingPage;

        protected void Page_Load(object sender, EventArgs e)
        {
            rankingPage = new RankingsPage
            {
                uname = Session["uname"].ToString()
            };
        }
    }
}