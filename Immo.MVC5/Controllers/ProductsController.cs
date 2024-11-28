using Immo.MVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Immo.MVC5.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            var products = GetProducts();
            return View(products);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(400, "Invallid Request");
            }
            var product = GetProducts().FirstOrDefault(x => x.Id == id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [NonAction]
        public IEnumerable<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product { Id = 1, ProductName="Laptop", Price= 500000.5M, Quantity=100 },
                new Product() { Id = 2, ProductName="Water Bottle", Price= 850, Quantity=252 },
                new Product() { Id = 3, ProductName="Watch", Price= 7599.99M, Quantity=15 },
                new Product() { Id = 4, ProductName="Mobile Phone", Price= 19999.99M, Quantity=50 },
             };
        }
    }
}