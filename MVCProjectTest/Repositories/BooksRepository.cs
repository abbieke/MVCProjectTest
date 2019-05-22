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
    public class BooksRepository
    {
        private static string connString;
        private SqlConnection conn;
        public BooksRepository()
        {
            if (string.IsNullOrEmpty(connString))
            {
                connString = ConfigurationManager.ConnectionStrings["bsmobile"].ConnectionString;
            }

            //conn = new SqlConnection(connString);
        }

        public List<Book> SelectBooks()
        {
            List<Book> books;
            using (conn = new SqlConnection(connString))
            {
                string sql = "Select * From Books As b INNER JOIN Author As a ON b.AuthorID = a.AuthorID Inner Join Category AS c ON b.CategoryID = c.CategoryID"; 
                books = conn.Query<Book>(sql).ToList();
            }
            return books;
        }

        public List<Book> SelectTopBooks()
        {
            List<Book> books;
            using (conn = new SqlConnection(connString))
            {
                string sql = "Select TOP 4 * From Books As b INNER JOIN Author As a ON b.AuthorID = a.AuthorID Inner Join Category AS c ON b.CategoryID = c.CategoryID ORDER BY b.InStock";
                books = conn.Query<Book>(sql).ToList();
            }
            return books;
        }
    }
}