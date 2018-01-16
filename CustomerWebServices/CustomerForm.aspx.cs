using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using CustomerWebServices.CustomerService;


namespace CustomerWebServices
{
    public partial class CustomerForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();
            }
        }

        private void BindGrid()
        {
            CustomerService.Customer1SoapClient client = new CustomerService.Customer1SoapClient();
            gvCustomer.DataSource = client.GetCustomerDetails();
            gvCustomer.DataBind();
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        { 
             CustomerWebServices.Customer1 objTest = new CustomerWebServices.Customer1();

             int ret = objTest.InsertCustomer(txtFirstName.Text, txtLastName.Text, txtPhone.Text, txtEmail.Text);
             lblMsg.Visible = true;
             if (ret > 0)
             {

                 lblMsg.Text = "Record inserted successfully";
             }
             else
             {
                 lblMsg.Text = "Error while inserting record";
             }

            this.BindGrid();


        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            //Clear all information
            txtCustomerID.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            lblMsg.Visible = false;


        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            CustomerWebServices.Customer1 objTest = new CustomerWebServices.Customer1();

            int ret = objTest.UpdateCustomer(Convert.ToInt32(txtCustomerID.Text), txtFirstName.Text, txtLastName.Text, txtPhone.Text, txtEmail.Text);
            lblMsg.Visible = true;
            if (ret > 0)
            {

                lblMsg.Text = "Record updated successfully";
            }
            else
            {
                lblMsg.Text = "Error while updating record";
            }

            this.BindGrid();

        }

        protected void btnDelet_Click(object sender, EventArgs e)
        {
            
            CustomerWebServices.Customer1 objTest = new CustomerWebServices.Customer1();

            int ret = objTest.Delete(Convert.ToInt32(txtCustomerID.Text), txtFirstName.Text, txtLastName.Text);
            lblMsg.Visible = true;
            
            if (ret > 0)
            {

                lblMsg.Text = "Record Deleted successfully";
            }
            else
            {
                lblMsg.Text = "Error while Deleting record";
            }

            this.BindGrid();

            txtCustomerID.Text = "";
        }
    }
}