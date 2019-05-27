using Libraries.BUS;
using Libraries.DTO;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Libraries.GUI
{
    public partial class FormMain : Form
    {
        const string connectionString = @"Data Source=.;Initial Catalog=LibrariesDb;Integrated Security=True";
        BookBus bookBus = new BookBus();

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            ResetData();
        }

        private void ResetData()
        {
            DataTable table = bookBus.LoadBooks();
            dataGridView.DataSource = table;

            textBox_id.Text = "";
            textBox_name.Text = "";

            setGridHeader();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormInfo form = new FormInfo();
            form.OnInsert += form_OnInsert;
            form.ShowDialog();
        }

        private void form_OnInsert(BookDto book)
        {
            bookBus.InsertBook(book);
            ResetData();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetData();
        }

        private void setGridHeader()
        {
            this.dataGridView.Columns[0].HeaderText = "Mã số";
            this.dataGridView.Columns[1].HeaderText = "Tên Sách";
            this.dataGridView.Columns[2].HeaderText = "Tác giả";
            this.dataGridView.Columns[3].HeaderText = "Ghi chú";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            BookDto book = new BookDto();

            if (dataGridView.CurrentRow == null)
            {
                return;
            }

            book.Id = int.Parse(dataGridView.CurrentRow.Cells[0].Value.ToString());
            book.Name = dataGridView.CurrentRow.Cells[1].Value.ToString();
            book.Author = dataGridView.CurrentRow.Cells[2].Value.ToString();
            book.Note = dataGridView.CurrentRow.Cells[3].Value.ToString();

            FormInfo form = new FormInfo(book);
            form.OnUpdate += form_OnUpdate;
            form.ShowDialog();
        }

        private void form_OnUpdate(BookDto book)
        {
            bookBus.UpdateBook(book);
            ResetData();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            BookDto book = new BookDto();
            if (dataGridView.CurrentRow == null)
            {
                return;
            }
            book.Id = int.Parse(dataGridView.CurrentRow.Cells[0].Value.ToString());
            FormSubmit form = new FormSubmit(book);
            form.OnDelete += form_OnDelete;
            form.ShowDialog();
        }

        private void form_OnDelete(BookDto book)
        {
            bookBus.DeleteBook(book.Id);
            ResetData();
        }

        private void btnSearchById_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (!string.IsNullOrEmpty(textBox_id.Text) && int.TryParse(textBox_id.Text, out int number))
            {
                id = int.Parse(textBox_id.Text);
            }

            DataTable table = bookBus.GetBooksById(id);            
            dataGridView.DataSource = table;

            setGridHeader();
        }

        private void btnSearchByName_Click(object sender, EventArgs e)
        {
            string name = textBox_name.Text;

            DataTable table = bookBus.GetBooksByName(name);
            dataGridView.DataSource = table;

            setGridHeader();
        }
        
    }
}
