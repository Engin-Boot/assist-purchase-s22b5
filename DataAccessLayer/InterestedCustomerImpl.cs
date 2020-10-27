using DataModel;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Net;
using System.Text;

namespace DataAccessLayer
{
   public class InterestedCustomerImpl : IInterestedCustomer
    {
        public HttpStatusCode InterestedCustomer(CustomerDetails customer)
        {

            var con = GetConnection();
            con.Open();
            var cmd = new SQLiteCommand(con)
            {
                CommandText =
                       @"INSERT INTO Customer(productName,email,phoneNumber) 
                                    VALUES
                                    ('" + customer.ProductName + "','" + customer.Email + "','" + customer.PhoneNumber+ "')"
            };
            cmd.ExecuteNonQuery();
            return HttpStatusCode.OK;
        }
        public IEnumerable<CustomerDetails> GetAllInterestedCustomers()
        {

            var con = GetConnection();
            con.Open();
            List<CustomerDetails> list = new List<CustomerDetails>();


            var stm = @"SELECT * FROM customer ";
            using var cmd1 = new SQLiteCommand(stm, con);
            using var rdr = cmd1.ExecuteReader();




            while (rdr.Read())
            {
                
                CustomerDetails customerInfo = new CustomerDetails
                {
                    ProductName = rdr.GetString(0),
                    Email = rdr.GetString(1),
                    PhoneNumber = rdr.GetString(2),
                   
                };
                list.Add(customerInfo);
            }
            con.Close();
            return list;
        }
        private static SQLiteConnection GetConnection()
        {
            var path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var cs = $@"URI=file:{Path.GetFullPath(Path.Combine(path!, @"..\..\..\"))}AssistPurchase.db";
            var con = new SQLiteConnection(cs);
            return con;
        }

    }
}
