using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookEccommerce_Admin.Models;
using BussinessLogicLayer_BLL;
using Microsoft.Data.SqlClient;

namespace BookEccommerce_Admin
{
    public partial class BookAdmin : Form
    {
        
        public BookAdmin()                            
        {
            InitializeComponent();
        }

        private void BookAdmin_Load(object sender, EventArgs e)
        {
            List<Book> books = new BookManagement().viewAllBook();
            dataGridView2.DataSource = books;
            List<Author> reader = new BookManagement().viewAllAuthor();
            comboBox1.DisplayMember = "Authorname";
            comboBox1.ValueMember = "Id";
            comboBox1.SelectedIndex = -1;
            comboBox1.DataSource = reader;

            List<Publisher> pub = new BookManagement().viewAllPub();
            comboBox2.DisplayMember = "Publishname";
            comboBox2.ValueMember = "Id";
            comboBox2.SelectedIndex = -1;
            comboBox2.DataSource = pub;

            List<Category> cate = new BookManagement().viewAllCategory();
            comboBox3.DisplayMember = "Categoryname";
            comboBox3.ValueMember = "Id";
            comboBox3.SelectedIndex = -1;
            comboBox3.DataSource = cate;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Book newBook = new Book()
            {
                Bookname = textBox1.Text.Trim(),
                AuthorId = int.Parse(comboBox1.SelectedValue.ToString()),
                PublisherId = int.Parse(comboBox2.SelectedValue.ToString()),
                CategoryId = int.Parse(comboBox3.SelectedValue.ToString()),
                Price = double.Parse(textBox2.Text.Trim()),
                StorageQuantity = int.Parse(textBox3.Text.Trim()),
                Description = textBox4.Text.Trim(),
                Image = textBox5.Text.Trim(),
            };
            new BookManagement().addBook(newBook);
            List<Book> books = new BookManagement().viewAllBook();
            dataGridView2.DataSource = books;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if(dataGridView2.SelectedRows.Count > 0)
            {
                int bookId = int.Parse(dataGridView2.SelectedRows[0].Cells["Id"].Value.ToString());
                Book book = new BookManagement().viewDetailBook(bookId);
                Author author = new BookManagement().viewAuthor(book.AuthorId);
                Category category = new BookManagement().viewCategory(book.CategoryId);
                Publisher publisher = new BookManagement().viewPublisher(book.PublisherId);
                if (book != null)
                {
                    textBox7.Text = book.Id.ToString();
                    textBox1.Text = book.Bookname;
                    comboBox1.Text = author.Authorname;
                    comboBox2.Text = publisher.Publishname;
                    comboBox3.Text = category.Categoryname;
                    textBox2.Text = book.Price.ToString();
                    textBox4.Text = book.Description;
                    textBox5.Text = book.Image;
                    textBox3.Text = book.StorageQuantity.ToString();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmDashboard frmAdmin = new FrmDashboard();
            frmAdmin.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("ARE U SURE?", "CONFIRMATION", MessageBoxButtons.YesNo);
            if(dialogResult == DialogResult.Yes)
            {
                int Id = int.Parse(textBox7.Text);
                bool result = new BookManagement().delBook(Id);
                if (result)
                {
                    List<Book> books = new BookManagement().viewAllBook();
                    dataGridView2.DataSource = books;
                }
                else { MessageBox.Show("SORRY BAE"); }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Book newBook = new Book()
            {
                Bookname = textBox1.Text.Trim(),
                AuthorId = int.Parse(comboBox1.SelectedValue.ToString()),
                PublisherId = int.Parse(comboBox2.SelectedValue.ToString()),
                CategoryId = int.Parse(comboBox3.SelectedValue.ToString()),
                Price = double.Parse(textBox2.Text.Trim()),
                StorageQuantity = int.Parse(textBox3.Text.Trim()),
                Description = textBox4.Text.Trim(),
                Image = textBox5.Text.Trim(),
            };
            bool result = new BookManagement().updateBook(newBook);
            if (result)
            {
                List<Book> books = new BookManagement().viewAllBook();
                dataGridView2.DataSource = books;
            }
            else { MessageBox.Show("SORRY BAE"); }
        }
    }
}
