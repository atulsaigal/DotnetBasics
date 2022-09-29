using NetCoreWebAppWithMVC.Models;
using System.Data;
using System.Data.SqlClient;

namespace NetCoreWebAppWithMVC.CommonHelper
{
    //public class DBUserMasterConnect
    //{

    //    SqlConnection con = null;
    //    SqlCommand cmd = null;

    //    public DBUserMasterConnect()
    //    {
    //        //con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString);
    //        con = new SqlConnection(Configuration["DefaultConnection:ConnectionString"]);
    //        con.Open();
    //    }

    //    public int InsertUserData(Records U)
    //    {
    //        if (U.Id == 0)
    //        {
    //            using (con)
    //            {
    //                cmd = new SqlCommand("SP_CreateNewAccount", con);
    //                cmd.CommandType = CommandType.StoredProcedure;
    //                cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = U.Id;
    //                cmd.Parameters.AddWithValue("@CreatedAt", SqlDbType.VarChar).Value = DateTime.Now.ToString("dd/MM/yyyy | hh:mm:ss tt");
    //                cmd.Parameters.AddWithValue("@EditedAt", SqlDbType.VarChar).Value = null;
    //                cmd.Parameters.AddWithValue("@DeletedAt", SqlDbType.VarChar).Value = null;
    //                cmd.Parameters.AddWithValue("@FirstName", SqlDbType.VarChar).Value = U.FirstName;
    //                cmd.Parameters.AddWithValue("@LastName", SqlDbType.VarChar).Value = U.LastName;
    //                cmd.Parameters.AddWithValue("@ContactNo", SqlDbType.VarChar).Value = U.ContactNo;
    //                cmd.Parameters.AddWithValue("@EmailId", SqlDbType.VarChar).Value = U.EmailId;
    //                cmd.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = U.Password;
    //                cmd.Parameters.AddWithValue("@Gender", SqlDbType.Char).Value = U.Gender;
    //                cmd.Parameters.AddWithValue("@Status", SqlDbType.Char).Value = U.Status;
    //                cmd.ExecuteNonQuery();
    //                con.Close();
    //            }
    //        }
    //        return 1;



    //    }



    //}
   
}
