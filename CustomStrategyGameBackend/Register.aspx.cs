using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using CustomStrategyGameBackend.Facades;
using CustomStrategyGameBackend.Models;
using System.Security.Cryptography;
using System.Net.Http;
using CustomStrategyGameBackend.ComModels;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace CustomStrategyGameBackend
{
    public partial class Register : System.Web.UI.Page
    {

        private const string uri = "https://localhost:44347/api/Registration";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void regBtn_Click(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {
                string passwordHashed = Encoding.ASCII.GetString(new SHA256Managed().ComputeHash(Encoding.ASCII.GetBytes(passtxt.Text)));
                RegisterGamerInfo regInfo = new RegisterGamerInfo(unametxt.Text, passwordHashed, emailtxt.Text);
                string sendingLink = JsonConvert.SerializeObject(regInfo);
                Task<HttpResponseMessage> responseTask = client.PostAsync(uri, new StringContent(sendingLink, Encoding.UTF8, "application/json"));
                HttpResponseMessage response = responseTask.Result;
                string val = response.Content.ReadAsStringAsync().Result;
                if (response.IsSuccessStatusCode)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + val + "')", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + val + "')", true);
                }
            }
        }
    }
}