using LibraryNoDB.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryNoDB.Controllers
{
    public class ProductsController : Controller
    {
		private readonly ProductRepository _productRepository;

        public ProductsController()
        {
            _productRepository = new ProductRepository();

            if(!_productRepository.GetAll().Any())
            {
                _productRepository.Add(new() { Id = 1, BookName = "Book 1", BookAuthor = "Author 1", BookEdition = 1, BookPrice = 1, BookStock = 1, BookPublishDate = DateTime.Now });
                _productRepository.Add(new() { Id = 2, BookName = "Book 2", BookAuthor = "Author 2", BookEdition = 2, BookPrice = 2, BookStock = 2, BookPublishDate = DateTime.Now });
                _productRepository.Add(new() { Id = 3, BookName = "Book 3", BookAuthor = "Author 3", BookEdition = 3, BookPrice = 3, BookStock = 3, BookPublishDate = DateTime.Now });
            }
        }

		public IActionResult Index()
        {
            var products = _productRepository.GetAll();
            return View(products);
        }

        public IActionResult Remove(int id)
        {
            _productRepository.Remove(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add(Product product)
        {
            //_productRepository.Add(product);
            return View();
        }

        [HttpPost]
        public IActionResult SaveProduct(Product product)
        {
            TempData["status"] = "Book added successfully.";
            int newId = _productRepository.GetAll().Count > 0 ? _productRepository.GetAll().Max(p => p.Id) + 1 : 1;
            product.Id = newId;
            _productRepository.Add(product);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = _productRepository.GetAll().FirstOrDefault(p => p.Id == id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Update(Product product)
        {
            _productRepository.Update(product);
            return RedirectToAction("Index");
        }
    }
}
