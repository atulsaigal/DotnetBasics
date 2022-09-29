using NetFrameworkWithADONet.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetFrameworkWithADONet.Controllers
{
    public class EmployeeController : Controller
    {

        Atul_SaigalEntities db = new Atul_SaigalEntities();

        // GET: Employee
        public ActionResult EmpView(EMPTable model)
        {
            return View(model);
        }
        public ActionResult EmpList()
        {

            var res = db.EMPTables.ToList();
            return View(res);
        }

        public ActionResult Delete(int id)
        {
            var res = db.EMPTables.Where(x => x.EmpID == id).First();
            db.EMPTables.Remove(res);
            db.SaveChanges();

            var list = db.EMPTables.ToList();

            return View("EmpList", list);
        }


        [HttpPost]
        public ActionResult AddEmpView(EMPTable model)
        {
            EMPTable  ET =new EMPTable();

            if (ModelState.IsValid)
            {
                ET.EmpID = model.EmpID;
                ET.EmpName = model.EmpName;
                ET.EmpLastname = model.EmpLastname;
                ET.EmailId = model.EmailId;
                ET.Password = model.Password;
                ET.City = model.City;
                ET.ContactNo = model.ContactNo;



                if (model.EmpID >= 0)
                {
                    db.EMPTables.Add(ET);
                    db.SaveChanges();
                }
                else
                {
                    
                    db.Entry(ET).State = EntityState.Modified;
                    db.SaveChangesAsync();
                }
                ModelState.Clear();
            }
            
            return RedirectToAction("EmpList");
        }





    }
}