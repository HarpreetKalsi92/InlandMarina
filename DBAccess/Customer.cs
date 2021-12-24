namespace DBAccess
{
    /// <summary>
    /// Model to hold data for one Customer from Marina database
    /// Author: James Defant
    /// Date: July 23 2019
    /// </summary>
    public class Customer
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
