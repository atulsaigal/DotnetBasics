using ClinicManagementSystem.Models;
using System.Data;
using System.Data.SqlClient;

namespace ClinicManagementSystem.Database.DatabaseMedicine
{
    public class DataMed
    {
        string connectionString = "Server=192.168.1.250\\SQL2019INT; Database=CMS_14; User Id=atul; Password=atul; Trusted_Connection=false; MultipleActiveResultSets=true";

        SqlConnection con = null;
        SqlCommand cmd = null;

        public DataMed()
        {
            con = new SqlConnection(connectionString);
            con.Open();
        }
        public int AddMed(MedicineReg model)
        {
            if (model.MedicineId == 0)
            {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("MedADDandUpdate", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@M_Name", model.MedicineName);
                    cmd.Parameters.AddWithValue("@M_Manufacturer", model.MedicineManufacturer);
                    cmd.Parameters.AddWithValue("@M_Price", model.MedicinePrice);
                    cmd.Parameters.AddWithValue("@M_Date", model.MedicineExpiryDate);
                    cmd.Parameters.AddWithValue("@Stock", model.MedicineStock);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            else
            {
                using (con)
                {
                    cmd = new SqlCommand("MedADDandUpdate", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@M_Id", SqlDbType.VarChar).Value = model.MedicineId;
                    cmd.Parameters.AddWithValue("@M_Name", SqlDbType.VarChar).Value = model.MedicineName;
                    cmd.Parameters.AddWithValue("@M_Manufacturer", SqlDbType.VarChar).Value = model.MedicineManufacturer;
                    cmd.Parameters.AddWithValue("@M_Price", SqlDbType.VarChar).Value = model.MedicinePrice;
                    cmd.Parameters.AddWithValue("@M_Date", SqlDbType.VarChar).Value = model.MedicineExpiryDate;
                    cmd.Parameters.AddWithValue("@Stock", SqlDbType.VarChar).Value = model.MedicineStock;

                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return 1;
        }

        public List<MedicineReg> GetMedicineData(string orderby, string whereclause)
        {
            List<MedicineReg> ULst = new List<MedicineReg>();
            using (con)
            {
                cmd = new SqlCommand("M_GetMedicineRecords", con);
                cmd.Parameters.AddWithValue("@orderby", SqlDbType.VarChar).Value = orderby;
                cmd.Parameters.AddWithValue("@whereclause", SqlDbType.VarChar).Value = whereclause;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    MedicineReg U = new MedicineReg();
                    U.MedicineId = Convert.ToInt32(rdr["MedicineId"]);
                    U.MedicineName = rdr["MedicineName"].ToString();
                    U.MedicineManufacturer = rdr["MedicineManufacturer"].ToString();
                    U.MedicinePrice = Convert.ToInt32(rdr["MedicinePrice"]);
                    U.MedicineExpiryDate = rdr["MedicineExpiryDate"].ToString();
                    U.MedicineStock = Convert.ToInt32((rdr["MedicineStock"]));

                    ULst.Add(U);
                }
                con.Close();
            }
            return ULst;
        }


        public int DeleteRecord(MedicineReg model)
        {
            if (model.MedicineId != 0)
            {
                using (con)
                {
                    cmd = new SqlCommand("DeleteMedicine", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@M_Id", SqlDbType.Int).Value = model.MedicineId;
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
            }
            return 1;
        }



    }
}
