using ClinicManagementSystem.Database.DatabaseMedicine;
using ClinicManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementSystem.Controllers
{
    public class Medicine : Controller
    {
        DataMed DM = new DataMed();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MedicineADD()
        {
            return View();
        }

        public IActionResult MedicineManagement()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddMedicine([FromBody] MedicineReg model)
        {
            {
                DM.AddMed(model);
            }
            return Json(View(model));
        }

        [HttpGet]


        [HttpGet]
        public JsonResult GetMed(string orderby, string whereclause)
        {
            List<MedicineReg> ULst = new List<MedicineReg>();
            ULst = DM.GetMedicineData(orderby, whereclause);
            return Json(new { data = ULst });
        }

        [HttpPost]
        public JsonResult DeleteMedicine([FromBody] MedicineReg UM)
        {
            DM.DeleteRecord(UM);
            return Json(new { data = UM });
        }




    }
}
