using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreApp.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository productRepository;
        public ProductController(IProductRepository _productRepository)
        {
            productRepository = _productRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List() => View(productRepository.Products);
    }
}