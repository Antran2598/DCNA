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
    public partial class CateAdmin : Form
    {
        public CateAdmin()
        {
            InitializeComponent();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                int cateId = int.Parse(dataGridView2.SelectedRows[0].Cells["Id"].Value.ToString());
                Category cate = new BookManagement().viewCategory(cateId);
                if (cate != null)
                {
                    textBox2.Text = cate.Id.ToString();
                    textBox1.Text = cate.Categoryname;
                }
            }
        }

        private void CateAdmin_Load(object sender, EventArgs e)
        {
            List<Category> categories = new BookManagement().viewAllCategory();
            dataGridView2.DataSource = categories;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Category newCate = new Category()
            {
                Categoryname = textBox1.Text.Trim(),
            };
            new BookManagement().addCate(newCate);
            List<Category> categories = new BookManagement().viewAllCategory();
            dataGridView2.DataSource = categories;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Category newCate = new Category()
            {
                Categoryname = textBox1.Text.Trim(),
            };
            bool result = new BookManagement().updateCate(newCate);
            if (result)
            {
                List<Category> categories = new BookManagement().viewAllCategory();
                dataGridView2.DataSource = categories;
            }
            else { MessageBox.Show("SORRY BAE"); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("ARE U SURE?", "CONFIRMATION", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int Id = int.Parse(textBox2.Text);
                bool result = new BookManagement().delCate(Id);
                if (result)
                {
                    List<Category> categories = new BookManagement().viewAllCategory();
                    dataGridView2.DataSource = categories;
                }
                else { MessageBox.Show("SORRY BAE"); }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmDashboard frmAdmin = new FrmDashboard();
            frmAdmin.Show();
            this.Close();
        }
    }
}
