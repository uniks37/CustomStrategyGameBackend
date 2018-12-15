using CustomStrategyGameBackend.ComModels;
using CustomStrategyGameBackend.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;

namespace CustomStrategyGameBackend
{
    public partial class DefaultPage : System.Web.UI.Page
    {
        private const string uri = "https://localhost:44347/api/Login";
        private bool remMeChecked = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            TokenLoginAsync();
        }

        private async Task TokenLoginAsync()
        {
            using (var client = new HttpClient())
            {
                HttpCookie myCookie = Request.Cookies["GameCookie"];

                // Read the cookie information and display it.
                if (!IsPostBack && myCookie != null)
                {
                    TokenUname tokenUname = JsonConvert.DeserializeObject<TokenUname>(myCookie.Value.ToString());
                    MessageWrapper<TokenUname> msgInfo = new MessageWrapper<TokenUname>() { Message = tokenUname };
                    HttpResponseMessage responseTask = await client.PostAsync(uri, new StringContent(Encrypt.EncryptString(JsonConvert.SerializeObject(msgInfo), "enigma"), Encoding.UTF8, "application/json"));
                    HttpResponseMessage response = responseTask;
                    if (response.IsSuccessStatusCode)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + response.IsSuccessStatusCode + "')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + response.IsSuccessStatusCode + "')", true);
                    }
                }
            }
        }

        protected void remMe_CheckedChanged(object sender, EventArgs e)
        {
            remMeChecked = !remMeChecked;
        }

        protected void signinBtn_Click(object sender, EventArgs e)
        {
            asyncLoginAsync();
        }

        private void asyncLoginAsync()
        {

            using (var client = new HttpClient())
            {
                string passwordHashed = Encoding.ASCII.GetString(new SHA256Managed().ComputeHash(Encoding.ASCII.GetBytes(passtxt.Text)));
                LoginGamerInfo lgInfo = new LoginGamerInfo(unametxt.Text, passwordHashed, remMeChecked);
                MessageWrapper<LoginGamerInfo> msgInfo = new MessageWrapper<LoginGamerInfo>() { Message = lgInfo };
                string sendingLink = JsonConvert.SerializeObject(msgInfo);
                Task<HttpResponseMessage> responseTask = client.PostAsync(uri, new StringContent(Encrypt.EncryptString(sendingLink, "enigma"), Encoding.UTF8, "application/text"));
                HttpResponseMessage response = responseTask.Result;
                string val = response.Content.ReadAsStringAsync().Result;
                if (response.IsSuccessStatusCode)
                {
                    HttpCookie myCookie = new HttpCookie("GameCookie")
                    {
                        Value = val
                    };
                    Response.Cookies.Add(myCookie);
                    Session["uname"] = JsonConvert.DeserializeObject<TokenUname>(val).Uname;
                    Session["token_id"] = JsonConvert.DeserializeObject<TokenUname>(val).Token_Id;
                    Response.Redirect("MainPage.aspx");
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + val + "')", true);
                }
            }

        }
    }
}