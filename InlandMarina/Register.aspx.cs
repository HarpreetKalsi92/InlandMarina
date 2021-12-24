using System;
using DBAccess;

namespace InlandMarina
{
    /// <summary>
    /// Register Page logic
    /// Author: James Defant
    /// Date: July 23 2019
    /// </summary>
    public partial class Register : System.Web.UI.Page
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
        protected void uxRegister_Click(object sender, EventArgs e)
        {
            bool validates = true;

            // Validate input!!
            if (validates)
            {
                string validFirstName = uxFirstName.Text.Trim();
                string validLastName = uxLastName.Text.Trim();
                string validPhone = uxPhone.Text.Trim();
                string validCity = uxCity.Text.Trim();
                string validUserName = uxUserName.Text.Trim();
                string validPassword = uxPassword.Text.Trim();

                // Check if username already exists in database...
                if(CustomerDB.CheckUserNameExists(validUserName))
                {
                    // ...if so, exit with error
                    uxError.Text = "Username already exists";
                    uxError.Visible = true;
                    return;
                }

                // Build a Customer object
                Customer newCust = new Customer()
                {
                    FirstName = validFirstName,
                    LastName = validLastName,
                    Phone = validPhone,
                    City = validCity,
                    UserName = validUserName,
                    Password = validPassword                    
                };

                // Check the user password
                if(CustomerDB.AddCustomer(newCust) > 0)
                {
                    // Successfully added - redirect to lease page
                    newCust = CustomerDB.GetCustomer(newCust.UserName);

                    Session["Customer"] = newCust;
                    Response.Redirect("~/Lease.aspx");
                }
                else
                {
                    // INSERT failed
                    uxError.Text = "Problem inserting user into database";
                    uxError.Visible = true;
                }
            }
        }

        /// <summary>
        /// Clear all text fields
        /// </summary>
        protected void uxClear_Click(object sender, EventArgs e)
        {
            uxFirstName.Text = "";
            uxLastName.Text = "";
            uxPhone.Text = "";
            uxCity.Text = "";
            uxUserName.Text = "";
            uxPassword.Text = "";
            uxPasswordConfirm.Text = "";

            // Focus on first name input
            uxFirstName.Focus();
        }
    }
}