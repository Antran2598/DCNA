using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussinessLogicLayer_BLL;
using BookEccommerce_Admin.Models;

namespace BookEccommerce_Admin
{
    public partial class PublisherAdmin : Form
    {
        public PublisherAdmin()
        {
            InitializeComponent();
        }

        private void PublisherAdmin_Load(object sender, EventArgs e)
        {
            List<Publisher> publishers = new BookManagement().viewAllPub();
            dataGridView2.DataSource = publishers;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmDashboard frmAdmin = new FrmDashboard();
            frmAdmin.Show();
            this.Close();
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                int pubId = int.Parse(dataGridView2.SelectedRows[0].Cells["Id"].Value.ToString());
                Publisher publisher = new BookManagement().viewPublisher(pubId);
                if (publisher != null)
                {
                    textBox2.Text = publisher.Id.ToString();
                    textBox1.Text = publisher.Publishname;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Publisher newPub = new Publisher()
            {
                Publishname = textBox1.Text.Trim(),
            };
            new BookManagement().addPublisher(newPub);
            List<Publisher> publishers = new BookManagement().viewAllPub();
            dataGridView2.DataSource = publishers;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("ARE U SURE?", "CONFIRMATION", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int Id = int.Parse(textBox2.Text);
                bool result = new BookManagement().delPublisher(Id);
                if (result)
                {
                    List<Publisher> publishers = new BookManagement().viewAllPub();
                    dataGridView2.DataSource = publishers;
                }
                else { MessageBox.Show("SORRY BAE"); }
            }
        }
    }
}
