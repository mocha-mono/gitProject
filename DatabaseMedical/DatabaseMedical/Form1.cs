using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseMedical
{
    public partial class Form1 : Form
    {
        BindingSource patientsBindingSource = new BindingSource();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PatientsDAO patientsDAO = new PatientsDAO();

            // list connect
            patientsBindingSource.DataSource = patientsDAO.GetAllPatients();
            dataGridView1.DataSource = patientsBindingSource;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PatientsDAO patientsDAO = new PatientsDAO();

            // list connect
            patientsBindingSource.DataSource = patientsDAO.SearchPatients(textBox1.Text);
            dataGridView1.DataSource = patientsBindingSource;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;

            int rowCLicked = dataGridView.CurrentRow.Index;
            MessageBox.Show("You clicked row " + rowCLicked);
        }
    }
}
