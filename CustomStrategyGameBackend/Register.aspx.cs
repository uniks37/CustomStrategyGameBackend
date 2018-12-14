using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using CustomStrategyGameBackend.Facades;
using CustomStrategyGameBackend.Models;

namespace CustomStrategyGameBackend
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void regBtn_Click(object sender, EventArgs e)
        {
            //int i = RegisterFacade.RegisterGamer(unametxt.Text, emailtxt.Text, Encrypt.EncryptString(passtxt.Text, "enigma"));
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert( '" + 200 + " status')");
        }
    }
}