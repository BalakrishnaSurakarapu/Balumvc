using Balu.DataAcces.Data;
using Balu.DataAcces.Repository;
using Balu.DataAcces.Repository.IRepository;
using Balu.Models;
using Microsoft.AspNetCore.Mvc;

namespace Balu.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
       // private readonly ICategoryRepositiry  _categoryRepo;

        private readonly IUnitOfWork _unityofwork;
        public CategoryController(IUnitOfWork unityofwork)
        {
            _unityofwork = unityofwork;
        }
        public IActionResult Index()
        {
            List<Category> categories = _unityofwork.Category.GetAll().ToList();
            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] //custom Validations
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "the Displayordes can not exactly match the name");
            }
            if (ModelState.IsValid)
            {

                _unityofwork.Category.Add(obj);
                _unityofwork.Save();
                TempData["Success"] = "Category is Saved Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            Category data = _unityofwork.Category.Get(u => u.Id == id);
            // Category data = _db.Categories.FirstOrDefault(u => u.Id == id);
            //  Category data=_db.Categories.Where(c => c.Id==id).FirstOrDefault();
            if (data == null)
            {
                return NotFound();

            }
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {

                _unityofwork.Category.Update(obj);
                _unityofwork.Save();
                TempData["Success"] = "Category is Updated Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            Category data = _unityofwork.Category.Get(u => u.Id == id);
            // Category data = _db.Categories.FirstOrDefault(o => o.Id == id);
            // Category data1=_db.Categories.Where(l => l.Id == id).FirstOrDefault();
            if (data == null)
            {
                return NotFound();

            }
            return View(data);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? data = _unityofwork.Category.Get(u => u.Id == id);

            if (data == null)
            {
                return NotFound();
            }
            _unityofwork.Category.Reomve(data);
            _unityofwork.Save();
            TempData["Success"] = "Category is Deleted Successfully";
            return RedirectToAction("index");
        }
    }
}
