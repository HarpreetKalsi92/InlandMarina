using System;
using DBAccess;

namespace InlandMarina
{
    /// <summary>
    /// Login Page logic
    /// Author: James Defant
    /// Date: July 23 2019
    /// </summary>
    public partial class Login : System.Web.UI.Page
    {
        // Called on page load
        protected void Page_Load(object sender, EventArgs e)
        {
            // Hide error message
            uxError.Visible = false;
        }

        //-------------------------
        // NEEDS VALIDATION
        //-------------------------
        // Called when Login button clicked
        protected void uxLogin_Click(object sender, EventArgs e)
        {
            bool validates = true;

            // Validate input!!
            if (validates)
            {
                string validUserName = uxUserName.Text.Trim();
                string validPassword = uxPassword.Text.Trim();

                // Check the user password
                if (CustomerDB.ValidateCustomer(uxUserName.Text.Trim(), validPassword) == true)
                {
                    // Success - set the session with a Customer object
                    Session["Customer"] = CustomerDB.GetCustomer(validUserName);
                    Response.Redirect("~/Lease.aspx");
                }
                else if (CustomerDB.ValidateCustomer(uxUserName.Text.Trim(), validPassword) == false)
                {
                    // No user found - show error msg
                    uxError.Text = "No user found";
                    uxError.Visible = true;
                }
                else if (CustomerDB.CheckUserNameExists(uxUserName.Text.Trim()))
                {
                    // User found - show error msg
                    uxError.Text = "Username found - incorrect password";
                    uxError.Visible = true;
                }
            }
        }
    }
}