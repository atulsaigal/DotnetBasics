using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NetCoreWebAppWithMVC.CommonHelper;
using NetCoreWebAppWithMVC.Models;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
//using System.Web.Mvc;

namespace NetCoreWebAppWithMVC.Controllers
{
    public class HomeController : Controller
    {

        private readonly IConfiguration _configuration;

        SqlConnection con = null;
        SqlCommand cmd = null;
        public HomeController(IConfiguration _configuration)
        {
            this._configuration = _configuration;
           


         
            con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            con.Open();
        }



        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CreateNewAccount()
        {
            return View();
        }





        //[HttpPost]
        //public JsonResult CreateNewAccount(int Id, string FirstName, string LastName, string ContactNo, string EmailId, string Password, char Gender)
        //{
        //    int flag = 0;
        //    Records U = new Records();
        //    {
        //        U.Id = Id;
        //        U.FirstName = FirstName;
        //        U.LastName = LastName;
        //        U.ContactNo = ContactNo;
        //        U.EmailId = EmailId;
        //        U.Gender = Gender;
        //        U.Password = Password;
        //        U.Status = 'Y';
        //    };

        //    flag = DUMC.InsertUserData(U);

        //    if (flag == 1)
        //    {
        //        var result = new { Success = "Success", Message = "Data Inserted Successfully..!!" };
        //        return Json(result, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        var result = new { Success = "False", Message = "Error Message" };
        //        return Json(result, JsonRequestBehavior.AllowGet);
        //    }
        //}

        [HttpPost]

        public IActionResult CreateNewAccountADO(Records records)
        {
            //string constr = SqlConnection(_configuration.GetConnectionString("DevConnection"));
            int flag = 0;
           
            using (con)
            {
                // var query = "INSERT INTO ADODataTable(FirstName,LastName,ContactNo,EmailId,Password,Gender,Status) VALUES(@FirstName,@LastName,@ContactNo,@EmailId,@Password,@Gender,@Status)";
               
                
               
                cmd.CommandText = "INSERT INTO ADODataTable(FirstName,LastName,ContactNo,EmailId,Password,Gender,Status) VALUES(@FirstName,@LastName,@ContactNo,@EmailId,@Password,@Gender,@Status)";

                cmd.Parameters.AddWithValue("@Id", records.Id);
                //cmd.Parameters.AddWithValue("@CreatedAt", SqlDbType.VarChar).Value = DateTime.Now.ToString("dd/MM/yyyy | hh:mm:ss tt");
                //cmd.Parameters.AddWithValue("@EditedAt", SqlDbType.VarChar).Value = null;
                //cmd.Parameters.AddWithValue("@DeletedAt", SqlDbType.VarChar).Value = null;
                cmd.Parameters.AddWithValue("@FirstName", records.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", records.LastName);
                    cmd.Parameters.AddWithValue("@ContactNo", records.ContactNo);
                    cmd.Parameters.AddWithValue("@EmailId", records.EmailId);
                    cmd.Parameters.AddWithValue("@Password", records.Password);
                    cmd.Parameters.AddWithValue("@Gender", records.Gender);
                    cmd.Parameters.AddWithValue("@Status", records.Status);
                    cmd.ExecuteNonQuery();
                    con.Close();
                
            }

            if (flag == 1)
            {
                var result = new { Success = "Success", Message = "Data Inserted Successfully..!!" };
                return Json(result);
            }

            else
            {
                var result = new { Success = "False", Message = "Error Message" };
                return Json(result);
            }
            
        } 





            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

            public IActionResult Error()
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        
    }
}