using ClinicManagementSystem.Models;
using System.Data;
using System.Data.SqlClient;

namespace ClinicManagementSystem.Database.DatabasePatient
{
    public class DataPatient
    {
        string connectionString = "Server=192.168.1.250\\SQL2019INT; Database=CMS_14; User Id=atul; Password=atul; Trusted_Connection=false; MultipleActiveResultSets=true";

        SqlConnection con = null;
        SqlCommand cmd = null;

        public DataPatient()
        {
            con = new SqlConnection(connectionString);
            con.Open();
        }

        public int AddPatient(PatientRegisteration model)
        {
            if (model.PatientId == 0)
            {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("AddNewPatient2", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CreatedAt", SqlDbType.VarChar).Value = DateTime.Now.ToString("dd/MM/yyyy | hh:mm:ss tt");
                    cmd.Parameters.AddWithValue("@FirstName", model.Firstname);
                    cmd.Parameters.AddWithValue("@LastName", model.Lastname);
                    cmd.Parameters.AddWithValue("@EmailId", model.EmailID);
                    cmd.Parameters.AddWithValue("@Address", model.Address);
                    cmd.Parameters.AddWithValue("@symptoms", model.Symptoms);
                    cmd.Parameters.AddWithValue("@ContactNo", model.ContactNo);
                    cmd.Parameters.AddWithValue("@IsFollowUp", 'Y');
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            else
            {
                using (con)
                {
                    cmd = new SqlCommand("UpdatePatient_SP", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatientId", SqlDbType.VarChar).Value = model.PatientId;
           
                    cmd.Parameters.AddWithValue("@EditedAt", SqlDbType.VarChar).Value = DateTime.Now.ToString("dd/MM/yyyy | hh:mm:ss tt");
                    cmd.Parameters.AddWithValue("@Firstname", SqlDbType.VarChar).Value = model.Firstname;
                    cmd.Parameters.AddWithValue("@Lastname", SqlDbType.VarChar).Value = model.Lastname;
                    cmd.Parameters.AddWithValue("@EmailId", SqlDbType.VarChar).Value = model.EmailID;
                    cmd.Parameters.AddWithValue("@Address", SqlDbType.VarChar).Value = model.Address;
                    cmd.Parameters.AddWithValue("@symptoms", SqlDbType.VarChar).Value = model.Symptoms;
                    cmd.Parameters.AddWithValue("@ContactNo", SqlDbType.VarChar).Value = model.ContactNo;
                    cmd.Parameters.AddWithValue("@IsFollowUp", SqlDbType.VarChar).Value = model.IsFollowUp;

                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return 1;
        }


        public List<PatientRegisteration> GetPatientData(string orderby, string whereclause)
        {
            List<PatientRegisteration> ULst = new List<PatientRegisteration>();
            using (con)
            {
                cmd = new SqlCommand("GetPatientRecords", con);
                cmd.Parameters.AddWithValue("@orderby", SqlDbType.VarChar).Value = orderby;
                cmd.Parameters.AddWithValue("@whereclause", SqlDbType.VarChar).Value = whereclause;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    PatientRegisteration U = new PatientRegisteration();
                    U.PatientId = Convert.ToInt32(rdr["PatientId"]);
                    U.Firstname = rdr["Firstname"].ToString();
                    U.Lastname = rdr["Lastname"].ToString();
                    U.EmailID = rdr["EmailId"].ToString();
                    U.Address = rdr["Address"].ToString();
                    U.ContactNo = rdr["ContactNo"].ToString();
                    U.Symptoms = rdr["Symptoms"].ToString();
                    U.IsFollowUp = Convert.ToChar(rdr["IsFollowUp"]);

                    ULst.Add(U);
                }
                con.Close();
            }
            return ULst;
        }

        public int DeleteRecord(PatientRegisteration user)
        {
            if (user.PatientId != 0)
            {
                using (con)
                {
                    cmd = new SqlCommand("DeletePatient", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = user.PatientId;
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
            }
            return 1;
        }







    }
}
