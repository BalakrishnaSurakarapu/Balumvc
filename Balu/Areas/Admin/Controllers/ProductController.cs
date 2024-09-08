
using Balu.DataAcces.Repository;
using Balu.Models;
using Microsoft.AspNetCore.Mvc;
using Balu.DataAcces.Repository.IRepository;
using Balu.DataAcces.Data;

namespace Balu.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unityofwork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unityofwork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Product> productList = _unityofwork.Product.GetAll().ToList();
            //  List<Product> productList = _db.Products.ToList();
            return View(productList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product obj)
        {
            //if (obj.ISBN == obj.Price.ToString())
            //{
            //    ModelState.AddModelError("name", "the Displayordes can not exactly match the name");
            //}
            if (ModelState.IsValid)
            {

                _unityofwork.Product.Add(obj);
                _unityofwork.Save();
                TempData["Success"] = "Product is Saved Successfully";
                return RedirectToAction("Index");
            }

            return View();
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            Product productsfromdb = _unityofwork.Product.Get(a => a.Id == id);
           // Product productsfromdb = _db.Product.Find(id);//get data
           //Category categoryfromdb1 = _db.Categories.FirstOrDefault(u=>u.Id==id); //get data
           //Category categoryfromdb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault(); //get data
            if (productsfromdb == null)
            {
                return NotFound();
            }
            return View(productsfromdb);
        }
               
        public IActionResult Edit(Product obj)
        {
            if (ModelState.IsValid)
            {
                _unityofwork.Product.Update(obj);
                _unityofwork.Save();
                TempData["Success"] = "Product is Updated Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            Product productsfromdb = _unityofwork.Product.Get(u => u.Id == id);     //get data
                                                                                    //Category categoryfromdb1 = _db.Categories.FirstOrDefault(u=>u.Id==id); //get data
                                                                                    //Category categoryfromdb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault(); //get data
            if (productsfromdb == null)
            {
                return NotFound();
            }
            return View(productsfromdb);

        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Product? Obj = _unityofwork.Product.Get(u => u.Id == id);
            if (Obj == null)
            {
                return NotFound();
            }
            _unityofwork.Product.Reomve(Obj);
            _unityofwork.Save();
            TempData["Success"] = "Product is Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
