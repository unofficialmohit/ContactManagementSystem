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
    public partial class delete : Form
    {
        public delete()
        {
            InitializeComponent();
        }

        private void Delete_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'telephoneDataSet1.tele' table. You can move, or remove it, as needed.
            this.teleTableAdapter.Fill(this.telephoneDataSet1.tele);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string phoneNumber = selectedRow.Cells[2].Value.ToString();
                string connectionString = "Data Source=MOHIT\\SQLEXPRESS;Initial Catalog=telephone;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string deleteQuery = "DELETE FROM tele WHERE Phone = @PhoneNumber";

                    using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Contact deleted successfully.");
                            dataGridView1.Rows.Remove(selectedRow); // Remove the row from the DataGridView
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete the Contact.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No row selected.");
            }

        }
    }
}
