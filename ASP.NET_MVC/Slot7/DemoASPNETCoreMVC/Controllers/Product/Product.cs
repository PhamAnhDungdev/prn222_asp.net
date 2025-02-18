using DemoASPNETCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoASPNETCoreMVC.Controllers.Product
{
    public class Product : Controller
    {
        private readonly MyStockContext _myStockContext;
        private readonly ILogger<Product> _logger;

        public Product(MyStockContext myStockContext, ILogger<Product> logger)
        {
            _myStockContext = myStockContext;
            _logger = logger;
        }

        public ActionResult GetProductList()
        {
            var products = _myStockContext.Products.ToList(); // Chuyển sang dạng List để trả về View

            // Kiểm tra nếu không có sản phẩm
            if (!products.Any())
            {
                ViewBag.Message = "Không có sản phẩm nào!";
            }

            return View("Product", products); //Chỉ định rõ tên View, Nếu không nó sẽ redirect về Views/GetViews
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = _myStockContext.Products.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _myStockContext.Add(product);
                _myStockContext.SaveChanges();
                return RedirectToAction(nameof(Product));
            }
            return View(product);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = _myStockContext.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        public ActionResult Delete(int? id)
        {
            var product = _myStockContext.Products.Find(id);
            //if (product == null)
            //{
            return View(product);
            //}
            //else
            //{
            //    _myStockContext.Products.Remove(product);
            //    _myStockContext.SaveChanges();
            //    return RedirectToAction(nameof(GetProductList));
            //}


        }
    }
}
