using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace DBAccess
{
    /// <summary>
    /// Author: Jaswinder Sangha
    /// Date: July 23 2019
    /// </summary>
    [DataObject(true)]


    public static class LeaseDB
    {
        [DataObjectMethod(DataObjectMethodType.Select)]

        // public static List<Slip> GetCurrentLeases(int CustomerID)
        public static List<Slip> GetCurrentLeases(int CustomerID)
        {
            List<Slip> lstSlip = new List<Slip>();//creates empty list

            Slip s = null;
            SqlConnection connection = MarinaDB.GetConnection();

            string sql = "Select * from Slip where ID IN( " +
                                                        "Select slipID from Lease where CustomerID = @CustomerID)";

            SqlCommand cmd = new SqlCommand(sql, connection);
              cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.Default);//read all rows
                while (reader.Read())
                {
                    s = new Slip();
                    s.ID = Convert.ToInt32(reader["ID"].ToString());
                    s.Width = Convert.ToInt32(reader["Width"].ToString());
                    s.Length = Convert.ToInt32(reader["Length"].ToString());
                    s.DockID = Convert.ToInt32(reader["DockID"].ToString());
                    lstSlip.Add(s);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return lstSlip; //return the list of products
        }

        [DataObjectMethod(DataObjectMethodType.Select)]

        public static List<Dock> GetAvailableDocks()
        {

            List<Dock> lstDock = new List<Dock>();//creates empty list

            Dock d = null;
            SqlConnection connection = MarinaDB.GetConnection();
            string availDock = "SELECT ID, Name, WaterService, ElectricalService FROM Dock where ID IN " +
                "(select DockID from Slip where Slip.ID Not in (select SlipID from Lease))";


            SqlCommand cmd = new SqlCommand(availDock, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.Default);//read all rows
                while (reader.Read())
                {
                    d = new Dock();
                    d.ID = Convert.ToInt32(reader["ID"].ToString());
                    d.Name = reader["Name"].ToString();
                    d.WaterService = Convert.ToBoolean(reader["WaterService"].ToString());
                    d.ElectricalService = Convert.ToBoolean(reader["ElectricalService"].ToString());

                    lstDock.Add(d);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return lstDock; //return the list of products
        }

        [DataObjectMethod(DataObjectMethodType.Select)]

        public static List<Slip> GetAvailableSlips(int DockID)
        {

            List<Slip> lstSlip = new List<Slip>();//creates empty list

            Slip s = null;
            SqlConnection connection = MarinaDB.GetConnection();

            string availSlip = "select * from Slip where DockID = @DockID and " +
                                "Slip.ID Not in (select SlipID from Lease)";

            SqlCommand cmd = new SqlCommand(availSlip, connection);
            cmd.Parameters.AddWithValue("DockID", DockID);
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.Default);//read all rows
                while (reader.Read())
                {
                    s = new Slip();
                    s.ID = Convert.ToInt32(reader["ID"].ToString());
                    s.Width = Convert.ToInt32(reader["Width"].ToString());
                    s.Length = Convert.ToInt32(reader["Length"].ToString());
                    s.DockID = Convert.ToInt32(reader["DockID"].ToString());
                    lstSlip.Add(s);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return lstSlip; //return the list of products
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]

        public static void DeleteSlip(int SlipID)
        {
            SqlConnection con = MarinaDB.GetConnection();
            string sql = "DELETE from Slip " +
                          "where ID = @SlipID"; //write code for optimistic concurrency
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("ID", SlipID);
            try
            {
                con.Open();
                int count = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]

        public static void AddSlip(int id, int customerid)
        {
            using (SqlConnection connection = MarinaDB.GetConnection())
            {
                string insertQuery = "insert into Lease ([SlipID], [CustomerID]) values (@id, @customerid);";


                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@customerid", customerid);

                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        //string selectQuery = "SELECT IDENT_CURRENT('Customer') FROM Customer";
                        //SqlCommand selectCmd = new SqlCommand(selectQuery, connection);
                        //int customerID = Convert.ToInt32(selectCmd.ExecuteScalar());
                     //   return customerID;
                        //   return customerID;

                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
    }
}
