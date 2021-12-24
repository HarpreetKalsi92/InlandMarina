using System;

namespace InlandMarina
{
    /// <summary>
    /// Logout Page logic
    /// Author: James Defant
    /// Date: July 23 2019
    /// </summary>
    public partial class Logout : System.Web.UI.Page
    {
        // Clear the session and redirect to Home page
        protected void Page_Load(object sender, EventArgs e)
        {        
            Session["Customer"] = null;
            Response.Redirect("~/Home.aspx");
        }
    }
}