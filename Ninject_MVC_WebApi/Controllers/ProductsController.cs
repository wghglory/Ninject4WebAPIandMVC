using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ninject_Model.Abstract;
using Ninject_Model.Model;

namespace Ninject_MVC_WebApi.Controllers
{
    public class ProductsController : ApiController
    {
        private IProductRepository repository;

        public ProductsController(IProductRepository repository)
        {
            this.repository = repository;
        }
        // GET api/Products
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return repository.Products;
        }

        // GET api/Products/5
        [HttpGet]
        public Product Get(int id)
        {
            return repository.Products.FirstOrDefault(p => p.ProductId == id);
        }
    }
}
