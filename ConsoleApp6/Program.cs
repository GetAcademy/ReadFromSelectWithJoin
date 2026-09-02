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

