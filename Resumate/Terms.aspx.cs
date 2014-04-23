using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserLayer;

public partial class Terms : System.Web.UI.Page
{
    user thisUser = new user();
    protected void Page_Load(object sender, EventArgs e)
    {
        // GET CUSTOMIZED GREETING
        layout_welcomeCenter.InnerHtml = thisUser.GetGreeting(false);
    }
}