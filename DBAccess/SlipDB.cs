using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data.SqlClient;
/// <summary>
/// DB access class related to Slip class
/// Written by Darren Uong
/// Last edited: 24.07.19
/// </summary>
namespace DBAccess
{
    [DataObject(true)]
    public static class SlipDB
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Slip> GetAvailableSlips(int DockID)
        {
            //Create empty list of Slip
            List<Slip> slips = new List<Slip>();

            //Grab sql connection
            SqlConnection connection = MarinaDB.GetConnection();
            //Create select query
            string selectQuery = "SELECT * FROM Slip WHERE ID NOT IN(SELECT SlipID FROM Lease) AND DockID = @DockID";
            SqlCommand cmd = new SqlCommand(selectQuery, connection);
            cmd.Parameters.AddWithValue("@DockID", DockID);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                slips.Clear();

                while (reader.Read())
                {
                    Slip slip = new Slip();

                    slip.ID = Convert.ToInt32(reader["ID"]);
                    slip.Width = Convert.ToInt32(reader["Width"]);
                    slip.Length = Convert.ToInt32(reader["Length"]);
                    slip.DockID = Convert.ToInt32(reader["DockID"]);
                    slips.Add(slip);
                }
                reader.Close();
            }
            catch (Exception ex)  //error   
            {
                throw ex;
            }
            finally  //executes always
            {
                connection.Close();
            }


            return slips;
        }

    }
}