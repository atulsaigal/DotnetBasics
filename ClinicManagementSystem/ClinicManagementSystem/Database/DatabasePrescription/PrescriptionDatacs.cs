using ClinicManagementSystem.Controllers;
using System.Data;
using System.Data.SqlClient;
using ClinicManagementSystem.Models;


namespace ClinicManagementSystem.Database.DatabasePrescription
{
    public class PrescriptionDatacs
    {

        string connectionString = "Server=192.168.1.250\\SQL2019INT; Database=CMS_14; User Id=atul; Password=atul; Trusted_Connection=false; MultipleActiveResultSets=true";

        SqlConnection con = null;
        SqlCommand cmd = null;


        public PrescriptionDatacs()
        {
            con = new SqlConnection(connectionString);
            con.Open();
        }

        public void AddPprescription(PrescriptionData model)
        {
            using (con)
            {
                SqlCommand cmd = new SqlCommand("AddPrescription", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PatientId", model.PatientId);
                cmd.Parameters.AddWithValue("@CreatedAt", SqlDbType.VarChar).Value = DateTime.Now.ToString("dd/MM/yyyy");
                cmd.Parameters.AddWithValue("@MedicineName", model.MedicineName);
                cmd.Parameters.AddWithValue("@SoldQuantity", model.Quantity);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
