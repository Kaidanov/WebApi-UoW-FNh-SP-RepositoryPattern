using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitOfWork.Domain.Entities;
using UnitOfWork.Domain.Services;
using UnitOfWork.Web.Helpers;
using UnitOfWork.Web.Models.Home;

namespace UnitOfWork.Web.Controllers
{
    public class HomeController : BaseController
    {
        private IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult Index()
        {
            var viewModel = new IndexViewModel();
            viewModel.Products = _productService.GetAllProducts();
            // ensure there are products for the example
            if (!viewModel.Products.Any())
            {
                _productService.Create(new Product { Name = "Product 1" });
                _productService.Create(new Product { Name = "Product 2" });
                _productService.Create(new Product { Name = "Product 3" });
            }       

            return View(viewModel);
        }
    }
}
