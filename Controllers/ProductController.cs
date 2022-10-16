using Microsoft.AspNetCore.Mvc;
using ProductManager.Models;
using ProductManager.Services;

 
namespace ProductManager.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            List<Product> products = _productService.GetProducts();
            return View(products);
        }
        public IActionResult Create()
        {
             List<Category> categories = _productService.GetCategories();
            return View(categories);
        }
        public IActionResult Update(int id)
        {
            var product = _productService.GetProductById(id);
            ViewBag.categories = _productService.GetCategories();
            return View(product);
        }
        public IActionResult Save(Product product)
        {
            var checkProduct = _productService.GetProductById(product.Id);
            if(checkProduct != null){
                _productService.UpdateProduct(product);
            }else{
                _productService.CreateProduct(product);   
            }       
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            
            _productService.DeleteProduct(id);
            return RedirectToAction("Index");
        }

    }
}
