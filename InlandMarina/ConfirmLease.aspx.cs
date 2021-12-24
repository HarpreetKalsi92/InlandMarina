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
    public partial class ConfirmLease : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtSlipID.Text = Request.QueryString["ID"].ToString();
            txtWidth.Text = Request.QueryString["Width"].ToString();
            txtLength.Text = Request.QueryString["Length"].ToString();
            txtDockId.Text = Request.QueryString["DockID"].ToString();
        }

        //customer able to lease teh slip and redirect the client to Lease page.
        protected void btnLease_Click(object sender, EventArgs e)
        {
            Customer cust = (Customer)Session["Customer"];
            Debug.WriteLine("ID:"+ cust.ID + "\nName: " + cust.FirstName + " " + cust.LastName + 
                "\nPhone: " + cust.Phone + "\nCity: " + cust.City + "\nUsername: " + cust.UserName);

            LeaseDB.AddSlip(Convert.ToInt32(txtSlipID.Text), cust.ID);

            Response.Redirect("Lease.aspx");
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Lease.aspx");
        }
    }
}