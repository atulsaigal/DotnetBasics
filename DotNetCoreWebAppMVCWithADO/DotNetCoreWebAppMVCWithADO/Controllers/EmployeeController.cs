using DotNetCoreWebAppMVCWithADO.CommonHelper;
using DotNetCoreWebAppMVCWithADO.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreWebAppMVCWithADO.Controllers
{
    public class EmployeeController : Controller
    {

        DbUserMasterConnect Dumc = new DbUserMasterConnect();

        public IActionResult Index()
        {
            List<EmployeeModel> M = new List<EmployeeModel>();
            M=Dumc.GetEmployees().ToList();

             
            return View(M);
        }

        public IActionResult Create()
        {
            return View();
        }


        public IActionResult Delete()
        {
            return View();
        }


        public IActionResult Details()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] EmployeeModel employee)
        {
            if (ModelState.IsValid)
            {
                Dumc.AddEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employee = Dumc.GetEmployeeData(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] EmployeeModel employee)
        {
            if (id != employee.ID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                Dumc.UpdateEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employee = Dumc.GetEmployeeData(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employee = Dumc.GetEmployeeData(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            Dumc.DeleteEmployee(id);
            return RedirectToAction("Index");
        }









    }
}
