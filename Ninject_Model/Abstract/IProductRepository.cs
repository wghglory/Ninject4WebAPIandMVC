using System.Linq;
using Ninject_Model.Model;

namespace Ninject_Model.Abstract
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }

        IQueryable<Product> GetProducts();

        Product GetProduct(int productId);

        bool AddProduct(Product product);

        bool UpdateProduct(Product product);

        bool DeleteProduct(int productId);
    }
}
