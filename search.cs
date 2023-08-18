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
    public partial class search : Form
    {
        public object DataGridView1 { get; private set; }

        public search()
        {
            InitializeComponent();
        }

        private void Search_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'telephoneDataSet.tele' table. You can move, or remove it, as needed.
            this.teleTableAdapter.Fill(this.telephoneDataSet.tele);

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

      
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            string filterValue = textBox1.Text; // Get the value from textbox1

            // Build the filter expression using the filterValue
            string filterExpression = $"fname LIKE '%{filterValue}%'";

            DataRow[] filteredRows = telephoneDataSet.Tables[0].Select(filterExpression);

            if (filteredRows.Length > 0)
            {
                DataTable filteredTable = filteredRows.CopyToDataTable();
                dataGridView1.DataSource = filteredTable;
            }
            else
            {
                dataGridView1.DataSource = null;
            }
        }
    }


    
}

