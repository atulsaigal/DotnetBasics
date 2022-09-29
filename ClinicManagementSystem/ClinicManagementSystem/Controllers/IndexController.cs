using ClinicManagementSystem.DataConnection;
using ClinicManagementSystem.DbUserMaster;
using ClinicManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace ClinicManagementSystem.Controllers
{
    public class IndexController : Controller
    {

       

        DataMaster UD = new DataMaster();
        
       
        public IActionResult AdminUserLogin()
        {
            return View();
        }

        public IActionResult RegisterForm()
        {
            return View();
        }

        public IActionResult UserManagement()
        {
            return View();
        }
        public IActionResult DesignView()
        {
            return View();
        }


        [HttpPost]
        public JsonResult RegisterForm([FromBody] UserManagement model)
        {
            
            {
                UD.AddData(model);
                
            }

            
            return Json (View(model));

        }


        [HttpGet]
        public JsonResult GetAllUserData(string orderby,string whereclause)
        {
            List<UserManagement> ULst = new List<UserManagement>();

            ULst = UD.GetUserData(orderby,whereclause);

            return Json(new { data = ULst });

        }

        
        [HttpPost]
        public JsonResult UpdateUserStatus([FromBody]UserManagement UM)
        {
            UD.UpdateStatus(UM);

            return Json (new {data = UM});

        }


        [HttpPost]
        public JsonResult LoginUser([FromBody] UserManagement model)
        {

            
            UD.LoginData(model);

            return Json(View(model));

        }



    }
}
