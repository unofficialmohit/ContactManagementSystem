using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TelephoneDirectory
{
    public partial class add : Form
    {
        private string connectionString = "Data Source=MOHIT\\SQLEXPRESS;Initial Catalog=telephone;Integrated Security=True";
        public add()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string value1 = textBox1.Text;
            string value2 = textBox2.Text;
            string value3 = textBox3.Text;
            string value4 = textBox4.Text;
            string value5 = textBox5.Text;
            System.Text.RegularExpressions.Regex rEmail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");

           
            try {
                if (!string.IsNullOrEmpty(value1) && !string.IsNullOrEmpty(value2) &&
                    !string.IsNullOrEmpty(value3) && !string.IsNullOrEmpty(value4) && !string.IsNullOrEmpty(value5))
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "INSERT INTO tele VALUES (@Value1, @Value2, @Value3, @Value4, @Value5)";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Value1", value1);
                            command.Parameters.AddWithValue("@Value2", value2);
                            command.Parameters.AddWithValue("@Value3", value3);
                            command.Parameters.AddWithValue("@Value4", value4);
                            command.Parameters.AddWithValue("@Value5", value5);

                            connection.Open();
                            if (textBox5.Text.Length > 0 && textBox5.Text.Trim().Length != 0)
                            {
                                if (!rEmail.IsMatch(textBox5.Text.Trim()))
                                {
                                    MessageBox.Show("INVALID EMAIL ID");
                                    
                                }
                                else
                                {
                                    int rowsAffected = command.ExecuteNonQuery();
                                    if (rowsAffected > 0)
                                    {
                                        MessageBox.Show("Contact Added successfully!");
                                        Form activeForm = Form.ActiveForm;
                                        if (activeForm != null)
                                        {
                                            activeForm.Close();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Failed to insert data.");
                                    }
                                }
                            }
                            

                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please fill in all values.");
                }
            }
            catch
            {

                MessageBox.Show("Contact Not Added, Invalid Details");
            }
            }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Add_Load(object sender, EventArgs e)
        {

        }
        

        private void TextBox3_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

       

        private void TextBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }
    }
}
