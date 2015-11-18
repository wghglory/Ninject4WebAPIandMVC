using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject_Model.Abstract;

namespace Ninject_MVC_WebApi.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;

        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Index()
        {
            return View(repository.Products);
        }
    }
}