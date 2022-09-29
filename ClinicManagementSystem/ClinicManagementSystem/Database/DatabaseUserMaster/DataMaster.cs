using ClinicManagementSystem.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ClinicManagementSystem.DbUserMaster
{
    public class DataMaster
    {
        string connectionString = "Server=192.168.1.250\\SQL2019INT; Database=CMS_14; User Id=atul; Password=atul; Trusted_Connection=false; MultipleActiveResultSets=true";

        SqlConnection con = null;
        SqlCommand cmd = null;
        public DataMaster()
        {
            con = new SqlConnection(connectionString);
            con.Open();

        }
       
        
        public int AddData(UserManagement model)
        {
            if (model.UserId == 0)
            {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("AddNewUser", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FirstName", model.Firstname);
                    cmd.Parameters.AddWithValue("@LastName", model.Lastname);
                    cmd.Parameters.AddWithValue("@EmailId", model.EmailId);
                    cmd.Parameters.AddWithValue("@Password", model.Password);
                    cmd.Parameters.AddWithValue("@UserRole", model.UserRole);
                    cmd.Parameters.AddWithValue("@IsActive", 'Y');


                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            else
            {
                using (con)
                {
                    cmd = new SqlCommand("AddNewUser", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userid", SqlDbType.VarChar).Value = model.UserId;
                    cmd.Parameters.AddWithValue("@Firstname", SqlDbType.VarChar).Value = model.Firstname;
                    cmd.Parameters.AddWithValue("@Lastname", SqlDbType.VarChar).Value = model.Lastname;
                    cmd.Parameters.AddWithValue("@EmailId", SqlDbType.VarChar).Value = model.EmailId;
                    cmd.Parameters.AddWithValue("@UserRole", SqlDbType.VarChar).Value = model.UserRole;

                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return 1;
        }

        public List<UserManagement> GetUserData(string orderby, string whereclause)
        {
            List<UserManagement> ULst = new List<UserManagement>();
            using (con)
            {
                cmd = new SqlCommand("GetUserRecords", con);                   
                cmd.Parameters.AddWithValue("@orderby", SqlDbType.VarChar).Value = orderby;
                cmd.Parameters.AddWithValue("@whereclause", SqlDbType.VarChar).Value = whereclause;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    UserManagement U = new UserManagement();
                    U.UserId = Convert.ToInt32(rdr["UserId"]);
                    U.Firstname = rdr["FirstName"].ToString();
                    U.Lastname = rdr["LastName"].ToString();
                    U.EmailId = rdr["EmailId"].ToString();
                    U.UserRole = Convert.ToChar(rdr["UserRole"]);
                    U.IsActive = Convert.ToChar(rdr["IsActive"]);
                    
                    ULst.Add(U);
                }
                con.Close();
            }
            return ULst;
        }


        public int UpdateStatus(UserManagement user)
        {
            if(user.UserId != 0)
            {
                using (con)
                {
                    cmd = new SqlCommand("UpdateUserStatus_SP", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = user.UserId;
                    cmd.Parameters.AddWithValue("@IsActive", SqlDbType.Char).Value = user.IsActive;
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
            }
            return 1;
        }

        public int LoginData(UserManagement model)
        {
            
                using (con)
                {
                    cmd = new SqlCommand("loginuserSP", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email", SqlDbType.NVarChar).Value = model.EmailId;
                    cmd.Parameters.AddWithValue("@Password", SqlDbType.NVarChar).Value = model.Password;
                    SqlParameter oblogin = new SqlParameter();
                    oblogin.ParameterName = "@Isvalid";
                    oblogin.SqlDbType = SqlDbType.Bit;
                    oblogin.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(oblogin);
                    cmd.ExecuteNonQuery();
                    int res = Convert.ToInt32(oblogin.Value);

                    con.Close();
                return res;
            }
            
            
        }







    }
}
