using DapperTutorial.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;

namespace DapperTutorial.Dal
{
    public class ProductDal
    {
        public static async Task<bool> AddProduct(Product product) {
            bool success = false;
            try
            {
                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DapperTutorialConnectionString"].ToString()))
                {                    
                    var affectedRows = await connection.ExecuteAsync("sp_Product",
                        new { ProductId = product.ProductId, ProductName = product.ProductName, Price = product.Price, Active = product.Active, Mode = 1 },
                        commandType: CommandType.StoredProcedure);                    
                }
            }
            catch (Exception ex)
            {
                success = false;
            }
            return success;

        }
        public static async Task<List<Product>> GetProducts(string ProductName)
        {
            List<Product> products = new List<Product>();
            try
            {
                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DapperTutorialConnectionString"].ToString()))
                {
                    products = (await connection.QueryAsync<Product>("sp_ProductGet",
                        new {  ProductName = ProductName},
                        commandType: CommandType.StoredProcedure)).ToList();
                }
            }
            catch (Exception ex)
            {                
            }
            return products;
        }
    }
}
