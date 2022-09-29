using ClinicManagementSystem.Database.DatabasePrescription;
using ClinicManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementSystem.Controllers
{
    public class Prescription : Controller
    {
        PrescriptionDatacs PD = new PrescriptionDatacs();

        public IActionResult AddPrescription()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddPrescription([FromBody] PrescriptionData model)
        {
            {
                PD.AddPprescription(model);

            }
            return Json(View(model));
        }

    }
}
