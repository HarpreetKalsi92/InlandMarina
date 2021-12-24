using DBAccess;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InlandMarina
{ 
    /// <summary>
   /// Author: Jaswinder Sangha
   /// Date: July 23 2019
   /// </summary>
    public partial class Lease : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {        
            if (Session["Customer"] != null)
            {
                // Get Customer object from Session
                Customer cust = (Customer)Session["Customer"];
                Debug.WriteLine("Customer UserName: " + cust.UserName + "\nID: " + cust.ID);

                // Pass ID to DataSource method
                ObjectDataSource4.SelectParameters["CustomerID"].DefaultValue = cust.ID.ToString();
            }
            else
            {
                // If no Session set, redirect to Home
                Response.Redirect("~/Register.aspx");
            }
        }
        //Once client select the slip, redirect to ConfirmLease page
        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gr = GridView2.SelectedRow;
            Response.Redirect("ConfirmLease.aspx?ID=" + gr.Cells[0].Text + "&Width=" + gr.Cells[1].Text + "&Length=" + gr.Cells[2].Text + "&DockID=" + gr.Cells[3].Text);
        }
    }
}