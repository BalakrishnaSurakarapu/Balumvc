using Balu.DataAcces.Data;
using Balu.DataAcces.Repository;
using Balu.DataAcces.Repository.IRepository;
using Balu.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Balu.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
       // private AplicationDbcontext _db;
        public EmployeeController(IUnitOfWork unitOfWork) { 
        _unitOfWork = unitOfWork;
        }
       
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Index()
        {
            List<Employee> employees = _unitOfWork.Employee.GetAll().ToList();
            return View(employees);
        }

        [HttpPost]
        public IActionResult Create(Employee obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Employee.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Employee is saved Successfully";
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
            Employee employeesfromDb = _unitOfWork.Employee.Get(a => a.EmployeeId == id);
            if (employeesfromDb == null)
            {
                return NotFound();
            }
            return View(employeesfromDb);
        }
        [HttpPost]
        public IActionResult Edit(Employee obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Employee.Update(obj);
                _unitOfWork.Save();
                TempData["Success"] = "Employee is Updated Successfully";
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
            Employee employeesfromDb = _unitOfWork.Employee.Get(u => u.EmployeeId == id);     //get data
                                                                                    //Category categoryfromdb1 = _db.Categories.FirstOrDefault(u=>u.Id==id); //get data
                                                                                    //Category categoryfromdb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault(); //get data
            if (employeesfromDb == null)
            {
                return NotFound();
            }
            return View(employeesfromDb);

        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Employee? Obj = _unitOfWork.Employee.Get(u => u.EmployeeId == id);
            if (Obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Employee.Reomve(Obj);
            _unitOfWork.Save();
            TempData["Success"] = "Employee is Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
