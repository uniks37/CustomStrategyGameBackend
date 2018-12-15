using CustomStrategyGameBackend.ComModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomStrategyGameBackend
{
    public partial class MainPage : System.Web.UI.Page
    {
        public string uname;
        public MainPage mainPage;
        private const string uri = "https://localhost:44347/api/Logout";

        protected void Page_Load(object sender, EventArgs e)
        {
            mainPage = new MainPage();
            mainPage.uname = Session["uname"].ToString();
        }

        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {
                TokenUname tokenUname = new TokenUname(mainPage.uname, Session["token_id"].ToString());
                MessageWrapper<TokenUname> msgInfo = new MessageWrapper<TokenUname>() { Message = tokenUname };
                string sendingLink = JsonConvert.SerializeObject(msgInfo);
                Task<HttpResponseMessage> responseTask = client.PostAsync(uri, new StringContent(sendingLink, Encoding.UTF8, "application/json"));
                Session.Abandon();
                if (Request.Cookies["GameCookie"] != null)
                {
                    Response.Cookies["GameCookie"].Expires = DateTime.Now.AddDays(-1);
                }
                Response.Redirect("LoggedOutPage.aspx");
            }
        }
    }
}