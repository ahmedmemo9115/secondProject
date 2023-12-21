using secondP.EcontactClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace secondP
{
    public partial class second : Form
    {
        contactClass c = new contactClass();
        public second()
        {
            InitializeComponent();
        }

       

        private void second_Load(object sender, EventArgs e)
        {
            DataTable dt = c.select();
            ContactList.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            c.FirstName = f_name.Text;
            c.LastName = l_name.Text;
            c.phone = num.Text;
            c.address = address.Text;
            c.gender = gender.Text;
            bool success = c.insert(c);
            
            if (success == true)
            {
                MessageBox.Show("New Contact added successfully");
                clear();
            }
            else
            {
                MessageBox.Show("Failed to Add aNew Contact");

            }
            DataTable dt = c.select();
            ContactList.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            c.ContactID = int.Parse(id.Text);
            c.FirstName = f_name.Text;
            c.LastName = l_name.Text;
            c.phone = num.Text;
            c.address = address.Text;
            c.gender = gender.Text;

            bool success = c.update(c);

            if (success == true)
            {
                MessageBox.Show("Contact info Updated Successfully");
                DataTable dt = c.select();
                ContactList.DataSource = dt;
                clear();
            }
            else
            {
                MessageBox.Show("Failed to Update user");

            }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            c.ContactID = Convert.ToInt32(id.Text);


            bool success = c.Delete(c);

            if (success == true)
            {
                MessageBox.Show("Contact info Deleted Successfully");
                DataTable dt = c.select();
                ContactList.DataSource = dt;
                clear();
            }
            else
            {
                MessageBox.Show("Failed to Delete User Row");

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ContactList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        public void clear()
        {
            id.Text = "";
            f_name.Text = "";
            l_name.Text = "";
            num.Text = "";
            address.Text = "";
            gender.Text = "";

        }

        private void ContactList_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;


            id.Text = ContactList.Rows[rowIndex].Cells[0].Value.ToString();
            f_name.Text = ContactList.Rows[rowIndex].Cells[1].Value.ToString();
            l_name.Text = ContactList.Rows[rowIndex].Cells[2].Value.ToString();
            num.Text = ContactList.Rows[rowIndex].Cells[3].Value.ToString();
            address.Text = ContactList.Rows[rowIndex].Cells[4].Value.ToString();
            gender.Text = ContactList.Rows[rowIndex].Cells[5].Value.ToString();


        }
        static string myconnstr = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        private void search_TextChanged(object sender, EventArgs e)
        {
            string keyword = search.Text;
            SqlConnection conn = new SqlConnection(myconnstr);
            SqlDataAdapter sdaa = new SqlDataAdapter("SELECT * FROM tbl_contact WHERE FirstName LIKE '%" +keyword+ "%' OR LastName LIKE '%"+keyword+ "%' OR address LIKE '%" +keyword+ "%'",conn);

            DataTable dt1 = new DataTable();
            sdaa.Fill(dt1);
            ContactList.DataSource = dt1;
        }
    }
}
