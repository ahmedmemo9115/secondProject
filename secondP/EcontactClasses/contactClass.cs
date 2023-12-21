using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace secondP.EcontactClasses
{
    internal class contactClass
    {
    public int ContactID {  get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string phone{ get; set; }
    public string address {  get; set; }
    public string gender { get; set; }

        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;


        public DataTable select()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try {

                string sql = "SELECT * FROM tbl_contact";
                SqlCommand cmd = new SqlCommand(sql,conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            
            }
            catch (Exception ex)
            { 
            
            }
            finally
            {
                conn.Close(); 
            
            }

            return dt;
        }

        public bool insert(contactClass c)
        {
            bool issuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            
            try
            {

                string sql = "INSERT INTO tbl_contact (FirstName , LastName , phone, address, gender) VALUES (@firstName,@lastName,@phone ,@address , @Gender)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@firstName", c.FirstName);
                cmd.Parameters.AddWithValue("@lastName", c.LastName);
                cmd.Parameters.AddWithValue("@phone", c.phone);
                cmd.Parameters.AddWithValue("@address", c.address);
                cmd.Parameters.AddWithValue("@Gender", c.gender);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    issuccess = true;

                }
                else
                {
                    issuccess = false;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();

            }

            return issuccess;
        }

        public bool update(contactClass c)
        {
            bool issuccess = false;

            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "UPDATE tbl_contact SET FirstName=@firstname , LastName=@lastname, phone=@phone , address=@address , gender=@gender WHERE ContactID=@ContactID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@firstName", c.FirstName);
                cmd.Parameters.AddWithValue("@lastName", c.LastName);
                cmd.Parameters.AddWithValue("@phone", c.phone);
                cmd.Parameters.AddWithValue("@address", c.address);
                cmd.Parameters.AddWithValue("@Gender", c.gender);
                cmd.Parameters.AddWithValue("@ContactID", c.ContactID);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    issuccess = true;

                }
                else
                {
                    issuccess = false;
                }

            }
            catch (Exception ex)
            {
            
            
    
            }
            finally
            {

                conn.Close();

            }
            return issuccess;
        }

        public bool Delete (contactClass c)
        {
            bool issuccess = false;

            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "Delete FROM tbl_contact WHERE ContactID=@ContactID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ContactID", c.ContactID);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    issuccess = true;
                }
                else
                {
                    issuccess = false;
                }

            }
            catch (Exception ex)
            {



            }
            finally
            {

                conn.Close();

            }
            return issuccess;

        }


    }
}
