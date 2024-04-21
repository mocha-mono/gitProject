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
            PatientsDAO x = new PatientsDAO();
            Patient a1 = new Patient
            {
                ID = 1,
                LastName = "Cabarrubias",
                FirstName = "Mitchel",
                MiddleName = "Cantano",
                SuffixName = "N/A",
                BirthDate = DateTime.Now,
                Address = "Camp 7"

            };

            Patient a2 = new Patient
            {
                ID = 1,
                LastName = "Klein",
                FirstName = "Anne",
                MiddleName = "Eeep",
                SuffixName = "N/A",
                BirthDate = DateTime.Now,
                Address = "Japan"

            };

            x.patients.Add(a1);
            x.patients.Add(a2);

            // list connect
            patientsBindingSource.DataSource = x.patients;
            dataGridView1.DataSource = patientsBindingSource;

        }
    }
}
