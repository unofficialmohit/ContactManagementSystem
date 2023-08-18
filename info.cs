using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TelephoneDirectory
{
    public partial class info : Form
    {
        string phone;
        public info(String s)
        {
            InitializeComponent();
            string connectionString = "Data Source=MOHIT\\SQLEXPRESS;Initial Catalog=telephone;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM tele WHERE Phone = @Phone";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@Phone", s);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string fname = reader["FName"].ToString();
                            string lname = reader["LName"].ToString();
                            phone = reader["Phone"].ToString();
                            string email = reader["Email"].ToString();
                            string mobile = reader["Mobile"].ToString();
                            textBox1.Text = fname;
                            textBox2.Text = lname;
                            textBox3.Text = mobile;
                            textBox5.Text = email;
                            label4.Text = "Updating Details of "+phone;

                        }
                        else
                        {
                            MessageBox.Show("No record found.");
                        }
                    }
                }
                connection.Close();
            }

            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=MOHIT\\SQLEXPRESS;Initial Catalog=telephone;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string updateQuery = "UPDATE tele SET FName = @FName, LName = @LName, Mobile = @Mobile, Email = @Email WHERE Phone = @Phone";

                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@FName", textBox1.Text);
                    command.Parameters.AddWithValue("@LName", textBox2.Text);
                    command.Parameters.AddWithValue("@Mobile", textBox3.Text);
                    command.Parameters.AddWithValue("@Email", textBox5.Text);
                    command.Parameters.AddWithValue("@Phone", phone);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Contact updated successfully.");
                        Form activeForm = Form.ActiveForm;
                        if (activeForm != null)
                        {
                            activeForm.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Failed to update Contact.");
                    }
                }
            }
        }
    }
}
