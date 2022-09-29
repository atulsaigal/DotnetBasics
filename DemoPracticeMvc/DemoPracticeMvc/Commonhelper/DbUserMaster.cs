using DemoPracticeMvc.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DemoPracticeMvc.Commonhelper
{
    public class DbUserMaster
    {
        SqlConnection con = null;
        SqlCommand cmd = null;

        public DbUserMaster()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString);
            con.Open();
        }

        public int InsertData(UserModel U)
        {
            if (U.Id == 0)
            {
                using (con)
                {
                    cmd = new SqlCommand("CreateNewAccount_SP", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = U.Id;
                    cmd.Parameters.AddWithValue("@CreatedAt", SqlDbType.VarChar).Value = DateTime.Now.ToString("dd/MM/yyyy | hh:mm:ss tt");
                    cmd.Parameters.AddWithValue("@EditedAt", SqlDbType.VarChar).Value = null;
                    cmd.Parameters.AddWithValue("@DeletedAt", SqlDbType.VarChar).Value = null;
                    cmd.Parameters.AddWithValue("@FirstName", SqlDbType.VarChar).Value = U.FirstName;
                    cmd.Parameters.AddWithValue("@LastName", SqlDbType.VarChar).Value = U.LastName;
                    cmd.Parameters.AddWithValue("@ContactNo", SqlDbType.VarChar).Value = U.ContactNo;
                    cmd.Parameters.AddWithValue("@EmailId", SqlDbType.VarChar).Value = U.EmailId;
                    cmd.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = U.Password;
                    cmd.Parameters.AddWithValue("@Gender", SqlDbType.Char).Value = U.Gender;
                    cmd.Parameters.AddWithValue("@Status", SqlDbType.Char).Value = U.Status;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            else
            {
                using (con)
                {
                    cmd = new SqlCommand("CreateNewAccount_SP", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = U.Id;
                    cmd.Parameters.AddWithValue("@CreatedAt", SqlDbType.VarChar).Value = null;
                    cmd.Parameters.AddWithValue("@EditedAt", SqlDbType.VarChar).Value = DateTime.Now.ToString("dd/MM/yyyy | hh:mm:ss tt");
                    cmd.Parameters.AddWithValue("@DeletedAt", SqlDbType.VarChar).Value = null;
                    cmd.Parameters.AddWithValue("@FirstName", SqlDbType.VarChar).Value = U.FirstName;
                    cmd.Parameters.AddWithValue("@LastName", SqlDbType.VarChar).Value = U.LastName;
                    cmd.Parameters.AddWithValue("@ContactNo", SqlDbType.VarChar).Value = U.ContactNo;
                    cmd.Parameters.AddWithValue("@EmailId", SqlDbType.VarChar).Value = U.EmailId;
                    cmd.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = "";
                    cmd.Parameters.AddWithValue("@Gender", SqlDbType.Char).Value = U.Gender;
                    cmd.Parameters.AddWithValue("@Status", SqlDbType.Char).Value = 'X';
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return 1;
        }

        public List<UserModel> GetUserData(string OrderBy, string WhereClause)
        {
            List<UserModel> ULst = new List<UserModel>();
            using (con)
            {
                cmd = new SqlCommand("GetUserRecords_SP", con);
                cmd.Parameters.AddWithValue("@OrderBy", SqlDbType.VarChar).Value = OrderBy;
                cmd.Parameters.AddWithValue("@WhereClause", SqlDbType.VarChar).Value = WhereClause;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    UserModel U = new UserModel();
                    U.setId(Convert.ToInt32(rdr["Id"]));
                    U.setFirstName(Convert.ToString(rdr["FirstName"]));
                    U.setLastName(Convert.ToString(rdr["LastName"]));
                    U.setEmailId(Convert.ToString(rdr["EmailId"]));
                    U.setContactNo(Convert.ToString(rdr["ContactNo"]));
                    U.setGender(Convert.ToChar(rdr["Gender"]));
                    U.setStatus(Convert.ToChar(rdr["Status"]));
                    U.setCreatedAt(Convert.ToString(rdr["CreatedAt"]));
                    U.setEditedAt(Convert.ToString(rdr["EditedAt"]));
                    U.setDeletedAt(Convert.ToString(rdr["DeletedAt"]));
                    ULst.Add(U);
                }
            }
            return ULst;
        }

        public int UpdateData(UserModel U)
        {
            if (U.Id != 0)
            {
                using (con)
                {
                    cmd = new SqlCommand("UpdateUserStatusDemo", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = U.Id;
                    cmd.Parameters.AddWithValue("@DeletedAt", SqlDbType.VarChar).Value = DateTime.Now.ToString("dd/MMM/YYYY | hh:mm:ss tt");
                    cmd.Parameters.AddWithValue("@Status", SqlDbType.Char).Value = U.Status;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return 1;

        }

        



    }

}

    