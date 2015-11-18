using System.Collections.Generic;
using System.Linq;
using Ninject_Model.Abstract;
using Ninject_Model.Model;

namespace Ninject_Model.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> list;
        public IQueryable<Product> Products
        {
            get { return GetProducts(); }
        }

        public IQueryable<Product> GetProducts()
        {
            list = new List<Product>
            {
                new Product {ProductId = 1,Name = "苹果",Category = "水果" ,Price = 1},
                new Product {ProductId = 2,Name = "鼠标",Category = "电脑配件" ,Price = 50},
                new Product {ProductId = 3,Name = "洗发水",Category = "日用品" ,Price = 20}
            };
            return list.AsQueryable();
        }

        public Product GetProduct(int productId)
        {
            return Products.FirstOrDefault(p => p.ProductId == productId);
        }

        public bool AddProduct(Product product)
        {
            if (product != null)
            {
                list.Add(product);
                return true;
            }
            return false;
        }

        public bool UpdateProduct(Product product)
        {
            if (product != null)
            {
                if (DeleteProduct(product.ProductId))
                {
                    AddProduct(product);
                    return true;
                }
            }
            return false;
        }

        public bool DeleteProduct(int productId)
        {
            var product = GetProduct(productId);
            if (product != null)
            {
                list.Remove(product);
                return true;
            }
            return false;
        }
    }
}
