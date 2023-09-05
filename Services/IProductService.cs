using WebAppWithSqldb.Models;

namespace WebAppWithSqldb.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
    }
}
