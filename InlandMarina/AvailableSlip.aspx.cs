using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using DBAccess;
using System.Collections.Generic;
using System;

namespace InlandMarina
{
    /// <summary>
    /// AvailableSlip c# page
    /// WRitten by Darren Uong
    /// Last edited: 25.07.19
    /// </summary>
    public partial class AvailableSlip : System.Web.UI.Page
    {
        List<Slip> test = new List<Slip>();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void gvDocks_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            //Set parameter value when SELECT button is clicked
            SlipDataSource.SelectParameters["DockID"].DefaultValue = gvDocks.Rows[e.NewSelectedIndex].Cells[0].Text;
        }

        protected void gvDocks_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
    }
}