using Dapper;
using MvcProjectTest.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcProjectTest.Repositories
{
    public class CustomersRepository
    {
        private static string connString;
        private readonly SqlConnection conn;
        public CustomersRepository()
        {
            if (string.IsNullOrEmpty(connString))
            {
                connString = ConfigurationManager.ConnectionStrings["bsmobile"].ConnectionString;
            }

            conn = new SqlConnection(connString);
        }

        public void InsertCustomer(Customer cust)
        {
            using (conn)
            {
                string sql = "INSERT INTO Customers(CustomerName, CustomerAccount, CustomerPassword, CustomerEmail, CustomerPhone, CustomerAddress, CustomerBirth) VALUES ( @CustomerName, @CustomerAccount, @CustomerPassword, @CustomerEmail, @CustomerPhone, @CustomerAddress, @CustomerBirth)";
                conn.Execute(sql, new { cust.CustomerName,cust.CustomerAccount, cust.CustomerPassword, cust.CustomerEmail, cust.CustomerPhone, cust.CustomerAddress, cust.CustomerBirth });
            }
        }
    }
}