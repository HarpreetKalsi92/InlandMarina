using System;

namespace InlandMarina
{
    /// <summary>
    /// Master Page logic
    /// Author: James Defant
    /// Date: July 23 2019
    /// </summary>
    public partial class InlandMarina : System.Web.UI.MasterPage
    {
        // Called on page load
        protected void Page_Load(object sender, EventArgs e)
        {
            // If user logged in...
            if (Session["Customer"] != null)
            {
                // ..display logout link
                link_login.Text = "Logout";
                link_login.NavigateUrl = "~/Logout.aspx";
            }
            else
            {
                // ..otherwise display login link
                link_login.Text = "Login";
                link_login.NavigateUrl = "~/Login.aspx";
            }
        }
    }
}