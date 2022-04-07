using Dapper;
using MySql.Data.MySqlClient;
using System.Data;

namespace BestBuyBlazorDemoWebApp.Data
{
    public class ProductRepo
    {
        private readonly IConfiguration _config;
        public ProductRepo(IConfiguration config)
        {
            _config = config;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            using IDbConnection db = new MySqlConnection(_config.GetConnectionString("bestbuy"));
            db.Open();
            var products = db.Query<Product>("SELECT * FROM products;");
            return products;
        }
    }
}
