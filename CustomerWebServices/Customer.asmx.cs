using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CustomerWebServices
{
    /// <summary>
    /// Summary description for Customer1
    /// </summary>
    [WebService(Namespace = "http://google.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Customer1 : System.Web.Services.WebService
    {

        [WebMethod]
        public List<Customer> GetCustomerDetails()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDBConn"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "spCustomer_Details";
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cmd;
            da.Fill(dt);
            List<Customer> customer = new List<Customer>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Customer cusObj = new Customer();
                    cusObj.ID = Convert.ToInt32(dr["ID"]);
                    cusObj.FirstName = dr["FirstName"].ToString();
                    cusObj.LastName = dr["LastName"].ToString();
                    cusObj.Phone = dr["Phone"].ToString();
                    cusObj.Email = dr["Email"].ToString();
                    customer.Add(cusObj);
                }
            }
            return customer;
        }

        [WebMethod]
        public Customer GetCustomerByID(int ID)
        {
            string cs = ConfigurationManager.ConnectionStrings["CustomerDBConn"].ConnectionString;
            using(SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetCustomerByID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter("@ID", ID);
                cmd.Parameters.Add(parameter);
                Customer customer = new Customer();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    customer.ID = Convert.ToInt32(reader["ID"]);
                    customer.FirstName = reader["Firstname"].ToString();
                    customer.LastName = reader["LastName"].ToString();
                    customer.Phone = reader["Phone"].ToString();
                    customer.Email = reader["Email"].ToString();

                }

                return customer;
            }
        }

        [WebMethod]
        public int InsertCustomer(string FirstName, string LastName, string Phone, string Email)
        {
            int retRecord=0;
            string cs = ConfigurationManager.ConnectionStrings["CustomerDBConn"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spCustomer_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("FirstName", SqlDbType.VarChar, 50).Value = FirstName;
                cmd.Parameters.Add("LastName", SqlDbType.VarChar, 50).Value = LastName;
                cmd.Parameters.Add("Phone", SqlDbType.VarChar, 20).Value = Phone;
                cmd.Parameters.Add("Email", SqlDbType.VarChar, 50).Value = Email;
                if(con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                retRecord = cmd.ExecuteNonQuery();

            }

            return retRecord;
        }  

        [WebMethod]
        public int UpdateCustomer(int ID, string FirstName, string LastName, string Phone, string Email)
        {
            int retRecord = 0;
            string cs = ConfigurationManager.ConnectionStrings["CustomerDBConn"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spCustomer_Update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@FirstName", FirstName);
                cmd.Parameters.AddWithValue("@LastName", LastName);
                cmd.Parameters.AddWithValue("@Phone", Phone);
                cmd.Parameters.AddWithValue("@Email", Email);
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                retRecord = cmd.ExecuteNonQuery();

            }

            return retRecord;
        }

        [WebMethod]
        public int Delete(int ID, string FirstName, string LastName)
        {
            int retRecord = 0;
            string cs = ConfigurationManager.ConnectionStrings["CustomerDBConn"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spCustomer_Delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", ID);
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                retRecord = cmd.ExecuteNonQuery();

            }

            return retRecord;



        }

    }
}
