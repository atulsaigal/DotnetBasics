using ClinicManagementSystem.Database.DatabasePatient;
using ClinicManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementSystem.Controllers
{
    public class PatientReg : Controller
    {

        DataPatient UD = new DataPatient();

        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PatientRegisteration()
        {
            return View();
        }

        public IActionResult PatientAdd()
        {
            return View();
        }

        [HttpPost]
        public JsonResult PatientAdd1([FromBody] PatientRegisteration model)
        {
            {
                UD.AddPatient(model);

            }
            return Json(View(model));
        }

    [HttpGet]
    public JsonResult GetAllPatientData(string orderby, string whereclause)
    {
        List<PatientRegisteration> ULst = new List<PatientRegisteration>();

        ULst = UD.GetPatientData(orderby, whereclause);

        return Json(new { data = ULst });
    }

        [HttpPost]
        public JsonResult DeleteRecord([FromBody] PatientRegisteration UM)
        {
            UD.DeleteRecord(UM);

            return Json(new { data = UM });

        }




    }
}
