using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.ComponentModel;
/// <summary>
/// DB access class related to Dock.
/// Written by Darren Uong
/// Last Edited 24.07.19
/// </summary>
namespace DBAccess
{
    [DataObject(true)]
    public static class DockDB
    {

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Dock> GetDocks()
        {
            List<Dock> docks = new List<Dock>();
            Dock dock;

            SqlConnection connection = MarinaDB.GetConnection();
            string selectQuery = "SELECT * FROM Dock";

            SqlCommand cmd = new SqlCommand(selectQuery, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    dock = new Dock();
                    dock.ID = Convert.ToInt32(reader["ID"]);
                    dock.Name = reader["Name"].ToString();
                    dock.ElectricalService = Convert.ToBoolean(reader["ElectricalService"]);
                    dock.WaterService = Convert.ToBoolean(reader["WaterService"]);
                    docks.Add(dock);
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

            return docks;
        }
    }
}
