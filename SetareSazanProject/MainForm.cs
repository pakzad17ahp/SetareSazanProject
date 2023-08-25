using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SetareSazanProject.Forms;

namespace SetareSazanProject
{
    public partial class MainForm : BaseForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddTermButton_Click(object sender, EventArgs e)
        {

        }

        private void AddPersonButton_Click(object sender, EventArgs e)
        {
            AddPersonForm personForm = new AddPersonForm();
            personForm.ShowDialog  ();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            PersianDateTime today = new PersianDateTime();
            tarikh t = new tarikh();
            today = today.ToPersianDateTime(t.today());
            lblnow.Text = "امروز:  " + today.ToLongDateString();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
