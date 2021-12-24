using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DBAccess
{
    /// <summary>
    /// Class for getting data from the the Customers table in the Marina database
    /// Author: James Defant
    /// Date: July 22 2019
    /// </summary>
    public static class CustomerDB
    {
        /// <summary>
        /// Return list of all customers in database
        /// </summary>
        /// <returns>List of Customers</returns>
        public static List<Customer> GetCustomers()
        {
            // Initilaize variables
            List<Customer> customerList = new List<Customer>();
            Customer cust = null;

            // Scope the connection
            using (SqlConnection connection = MarinaDB.GetConnection())
            {
                // build the query
                string selectQuery = "SELECT ID, " +
                                            "FirstName, " +
                                            "LastName, " +
                                            "Phone, " +
                                            "City " +
                                     "FROM Customer";

                // Scope the command object
                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    // Open the connection
                    connection.Open();

                    // Scope the reader object
                    using (SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        // Read all the data
                        while (reader.Read())
                        {
                            // Create object from database row
                            cust = new Customer()
                            {
                                ID = (int)reader["ID"],
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Phone = reader["Phone"].ToString(),
                                City = reader["City"].ToString()
                            };

                            // Add object to list
                            customerList.Add(cust);
                        }
                    }
                }
            }
            // return list
            return customerList;
        }

        /// <summary>
        /// Return single Customer object by way of UserName parameter
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>Single Customer</returns>
        public static Customer GetCustomer(string userName)
        {
            Customer cust = null;

            // Scope the connection
            using (SqlConnection connection = MarinaDB.GetConnection())
            {
                // build the query
                string selectQuery = "SELECT ID, " +
                                            "FirstName, " +
                                            "LastName, " +
                                            "Phone, " +
                                            "City," +
                                            "UserName " +
                                     "FROM Customer " +
                                     "WHERE UserName = @userName";

                // Scope the Command object
                using(SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    // Insert the parameter into the query
                    cmd.Parameters.AddWithValue("@userName", userName);

                    // Open the connection
                    connection.Open();

                    // Scope the Reader object
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // If there are any rows with this username...
                        if (reader.Read())
                        {
                            // Build a Customer object
                            cust = new Customer()
                            {
                                ID = (int)reader["ID"],
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Phone = reader["Phone"].ToString(),
                                City = reader["City"].ToString(),
                                UserName = reader["UserName"].ToString()
                            };
                        }
                    }
                }
            }
            // Return the Customer object
            return cust;
        }

        /// <summary>
        /// Validate whether or not customer username and (hashed) password match database
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>Does the customer's info match the database?</returns>
        public static bool ValidateCustomer(string username, string password)
        {
            // Build a hash out of the password
            string hash = GetHash(password.Trim());

            // Scope the connection
            using (SqlConnection connection = MarinaDB.GetConnection())
            {
                // Build the query
                string selectQuery = "SELECT UserName, " +
                                            "Password " +
                                     "FROM Customer " +
                                     "WHERE UserName = @username " +
                                        "AND Password = @password";

                // Scope the command
                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    // Add the parameters to the query
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", hash);

                    // Open the connection
                    connection.Open();

                    // Scope the reader
                    using (SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        // If there is a matching username/password
                        if (reader.Read())
                        {
                            // ..return success
                            return true;
                        }
                    }
                }
            }

            // ..else return failure
            return false;
        }

        /// <summary>
        /// Check the database for an existing username
        /// </summary>
        /// <param name="username"></param>
        /// <returns>Does it exist?</returns>
        public static bool CheckUserNameExists(string username)
        {
            // Scope the connection
            using (SqlConnection connection = MarinaDB.GetConnection())
            {
                // Build the query
                string selectQuery = "SELECT UserName " +
                                     "FROM Customer " +
                                     "WHERE UserName = @username";

                // Scope the command 
                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    // Add the parameter to the query
                    cmd.Parameters.AddWithValue("@username", username);

                    // Open the connection
                    connection.Open();

                    // Scope the reader
                    using (SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        // If there are any users with this name, return true...
                        if (reader.Read())
                        {
                            return true;
                        }
                    }
                }
            }
            // ...otherwise return false
            return false;
        }

        /// <summary>
        /// Add a new customer to the database
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>Was the INSERT successful?</returns>
        public static int AddCustomer(Customer customer)
        {
            // Hash the password parameter
            string hash = GetHash(customer.Password);

            // Scope the connection object
            using (SqlConnection connection = MarinaDB.GetConnection())
            {
                // Build the query
                string insertQuery = "INSERT INTO Customer (FirstName, LastName, Phone, City, UserName, Password) " +
                                        "VALUES(@FirstName, @LastName, @Phone, @City, @UserName, @Password)";
                // Scope the command object
                using(SqlCommand cmd = new SqlCommand(insertQuery, connection))
                {
                    // Add the parameters to the query
                    cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                    cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                    cmd.Parameters.AddWithValue("@City", customer.City);
                    cmd.Parameters.AddWithValue("@UserName", customer.UserName);
                    cmd.Parameters.AddWithValue("@Password", hash);

                    // Attempt to insert the Customer into the database
                    try
                    {
                        // Open the connection
                        connection.Open();

                        // Execute the query
                        cmd.ExecuteNonQuery();

                        // Check if the Customer was inserted...
                        string selectQuery = "SELECT IDENT_CURRENT('Customer') FROM Customer";
                        SqlCommand selectCmd = new SqlCommand(selectQuery, connection);

                        // ...and return the new row's ID
                        int customerID = Convert.ToInt32(selectCmd.ExecuteScalar());

                        return customerID;

                    }
                    catch(SqlException ex)  // Catch any exceptions
                    {
                        throw ex;
                    }
                    finally
                    {
                        // Close the connection
                        connection.Close();
                    }
                }
            }
        }

        /// <summary>
        /// Creates a hashed string to store in the database
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string GetHash(string input)
        {

            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(input));

            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }

            return hash.ToString();
        }
    }
}
