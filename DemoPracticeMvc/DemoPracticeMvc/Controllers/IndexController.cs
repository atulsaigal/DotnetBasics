using DemoPracticeMvc.Commonhelper;
using DemoPracticeMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoPracticeMvc.Controllers
{
    public class IndexController : Controller
    {
        DbUserMaster DUMC = new DbUserMaster();
        // GET: Index
        public ActionResult CreateNewAccount()
        {
            return View();
        }

        public ActionResult UserRecords()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CreateNewAccount(int Id, string FirstName, string LastName, string ContactNo, string EmailId, string Password, char Gender)
        {
            int flag = 0;
            UserModel U= new UserModel();
            {
                U.Id = Id;
                U.FirstName = FirstName;
                U.LastName = LastName;
                U.ContactNo = ContactNo;
                U.EmailId = EmailId;
                U.Gender = Gender;
                U.Password = Password;
                U.Status = 'Y';
            };

            flag = DUMC.InsertData(U);

            if (flag == 1)
            {
                var result = new { Success = "Success", Message = "Data Inserted Successfully..!!" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var result = new { Success = "False", Message = "Error Message" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]

        public JsonResult GetAllUserData(string OrderBy, string WhereClause)
        {
            List<UserModel> Ul = new List<UserModel>();
            Ul = DUMC.GetUserData(OrderBy, WhereClause);

            return Json(new { data = Ul }, JsonRequestBehavior.AllowGet);

        }


        [HttpPost]
        public JsonResult UpdateUserStatus(int Id, char Status)
        {
            int flag = 0;
            UserModel U = new UserModel();
            {
                U.Id = Id;
                U.Status = Status;
            };

            flag = DUMC.UpdateData(U);
            if (flag == 1)
            {
                var result = new { Success = "Success", Message = "Status Updated Successfully..!!" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var result = new { Success = "False", Message = "Error Message" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }





    }
}