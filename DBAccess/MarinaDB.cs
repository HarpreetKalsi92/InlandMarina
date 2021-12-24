using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Data;

namespace DBAccess
{
    /// <summary>
    /// Marina SQL database access logic
    /// Author: James Defant
    /// Date: July 23 2019
    /// </summary>
    public static class MarinaDB
    {
        private static string _connectionString = "";

        /// <summary>
        /// Get a connection object to the Marina database
        /// </summary>
        /// <returns></returns>
        public static SqlConnection GetConnection()
        {
            string connectionString = @"Data Source=localhost\sait; Initial Catalog = Marina; Integrated Security = True";
            return new SqlConnection(connectionString);
        }



        /// <summary>
        /// Test whether or not the server supplied in the parameter will connect to the database
        /// </summary>
        /// <param name="server"></param>
        /// <param name="connString">The full connection string returned in an out param</param>
        /// <returns>Does it connect?</returns>
        private static bool TestConnection(string server)
        {
            try
            {
                // Build string
                StringBuilder sb = new StringBuilder();
                sb.Append(@"Data Source = localhost\");
                sb.Append(server);
                sb.Append(@"; Initial Catalog = Marina; Integrated Security = True");

                // Create the connection
                SqlConnection conn = new SqlConnection(sb.ToString());

                // Open the connection
                conn.Open();

                // Test the connection
                if((conn.State & ConnectionState.Open) > 0)
                {
                    _connectionString = sb.ToString();
                    conn.Close();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
