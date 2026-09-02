using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using Microsoft.Data.SqlClient;
using ReadFromSelectWithJoin.DTOs;

namespace ReadFromSelectWithJoin
{
    internal class DbDemo
    {
        public static async Task Run()
        {
            var connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SimpleShop;Integrated Security=True";
            var sql = """
                          SELECT
                          o.Id AS OrderId,
                          o.CreatedUtc,
                          o.TotalAmount,

                          c.Id AS CustomerId,
                          c.Name AS CustomerName,
                          c.Email AS CustomerEmail

                      FROM Orders o

                      JOIN Customers c
                          ON c.Id = o.CustomerId;
                      """;


            var conn = new SqlConnection(connStr);

            var ordersWithCustomers = await conn.QueryAsync<OrderWithCustomer>(sql);
            foreach (var order in ordersWithCustomers)
            {
                Console.WriteLine(order.OrderId + " " + order.CreatedUtc + " " + order.TotalAmount
                                  + " " + order.CustomerId + " " + order.CustomerName + " " + order.CustomerEmail);
            }

            /*
               var customers = await conn.QueryAsync<Customer>("SELECT * FROM Customers");
               foreach (var customer in customers)
               {
                   Console.WriteLine(customer.Id + " " + customer.Name + " " + customer.Email);
               }
            */
        }
    }
}
