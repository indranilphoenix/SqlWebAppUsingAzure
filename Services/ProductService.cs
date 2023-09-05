using WebAppWithSqldb.Models;
using System.Data.SqlClient;

namespace WebAppWithSqldb.Services
{
    public class ProductService : IProductService
    {
        //private static string db_source = "indranilsqlsrv.database.windows.net";
        //private static string db_user = "indranil";
        //private static string db_password = "Indra@0409";
        //private static string db_database = "productDB";

        //private SqlConnection GetConnection()
        //{

        //    var _builder = new SqlConnectionStringBuilder();
        //    _builder.DataSource = db_source;
        //    _builder.UserID = db_user;
        //    _builder.Password = db_password;
        //    _builder.InitialCatalog = db_database;
        //    return new SqlConnection(_builder.ConnectionString);
        //}
        //public List<Product> GetProducts()
        //{
        //    List<Product> _product_lst = new List<Product>();
        //    string _statement = "SELECT ProductID,ProductName,Quantity from Products";
        //    SqlConnection _connection = GetConnection();

        //    _connection.Open();

        //    SqlCommand _sqlcommand = new SqlCommand(_statement, _connection);

        //    using (SqlDataReader _reader = _sqlcommand.ExecuteReader())
        //    {
        //        while (_reader.Read())
        //        {
        //            Product _product = new Product()
        //            {
        //                ProductID = _reader.GetInt32(0),
        //                ProductName = _reader.GetString(1),
        //                Quantity = _reader.GetInt32(2)
        //            };

        //            _product_lst.Add(_product);
        //        }
        //    }
        //    _connection.Close();
        //    return _product_lst;
        //}

        private readonly IConfiguration _configuration;
        public ProductService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        private SqlConnection GetConnection()
        {

            return new SqlConnection(_configuration.GetConnectionString("SQLConnection"));
        }
        public List<Product> GetProducts()
        {
            List<Product> _product_lst = new List<Product>();
            string _statement = "SELECT ProductID,ProductName,Quantity from Products";
            SqlConnection _connection = GetConnection();

            _connection.Open();

            SqlCommand _sqlcommand = new SqlCommand(_statement, _connection);

            using (SqlDataReader _reader = _sqlcommand.ExecuteReader())
            {
                while (_reader.Read())
                {
                    Product _product = new Product()
                    {
                        ProductID = _reader.GetInt32(0),
                        ProductName = _reader.GetString(1),
                        Quantity = _reader.GetInt32(2)
                    };

                    _product_lst.Add(_product);
                }
            }
            _connection.Close();
            return _product_lst;
        }

    }
}
