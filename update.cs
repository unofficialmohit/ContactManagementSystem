using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TelephoneDirectory
{
    public partial class update : Form
    {
        public update()
        {
            InitializeComponent();
        }

        private void Update_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'telephoneDataSet2.tele' table. You can move, or remove it, as needed.
            this.teleTableAdapter.Fill(this.telephoneDataSet2.tele);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            string phoneNumber = selectedRow.Cells[3].Value.ToString();
            Form activeForm = Form.ActiveForm;
            if (activeForm != null)
            {
                activeForm.Close();
            }
            new info(phoneNumber).Show();
            
        }
    }
}
