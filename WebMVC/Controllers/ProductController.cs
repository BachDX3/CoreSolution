using Application.Models;
using Application.Services;
using Application.Services.Implements;
using AutoMapper;
using Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{
    
    public class ProductController : Controller
    {
        private readonly IProductService _productServices;
        private readonly IMapper _mapper;
        //private readonly ILogger<ProductController> _logger;
        public ProductController(IProductService productServices, IMapper mapper, ILogger<ProductController> logger)
        {
            _productServices = productServices;
            _mapper = mapper;
           // _logger = logger;
        }

        // GET: ProductController
      //  [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var products = _productServices.FindAll().ToList();
            //var products = _productServices.GetAllProduct();
            return View(products);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(string id)
        {
            var product = _productServices.GetProducBytId(id);
            return View(product);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var productObj = new Product
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = collection["Name"],  // Sử dụng chỉ mục để lấy giá trị từ form
                    Price = decimal.TryParse(collection["Price"], out decimal price) ? price : 0,  // Chuyển đổi sang decimal
                    Description = collection["Description"],
                    DeleteFlag =  0, //Int32.Parse(collection["DeleteFlag"]),
                    //DeleteFlag = bool.TryParse(collection["DeleteFlag"], out bool deleteFlag) ? deleteFlag : false,  // Chuyển đổi sang bool
                    UpdatedDate = DateTime.Now,
                    CreatedDate = DateTime.Now
                };
                _productServices.Create(productObj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(string id)
        {
            var productObj = _productServices.GetProducBytId(id);
            return View(productObj);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, ProductModel productModel)
        {
            try
            {
                var productObj = _productServices.GetProducBytId(id);
                if (productObj == null)
                {
                    return NotFound("Product not found.");
                }
                productObj.Name = productModel.Name;
                productObj.Price =  productModel.Price;
                productObj.Description = productModel.Description;
                _productServices.Update(productObj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public IActionResult Delete(string id)
        {
            if(!ModelState.IsValid)
            {
                return NotFound();
            }
            Product productObj = _productServices.GetProducBytId(id);
            return View(productObj);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return NotFound("Product not found.");
                }
                var product = _productServices.GetProducBytId(id);

                _productServices.Delete(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
