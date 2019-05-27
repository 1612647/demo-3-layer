using Libraries.DTO;
using System;

using System.Windows.Forms;

namespace Libraries.GUI
{
    public partial class FormSubmit : Form
    {
        public FormSubmit()
        {
            InitializeComponent();
        }
        public int Id = 0;
        public delegate void Delete(BookDto book);
        public event Delete OnDelete = null;
        public FormSubmit(BookDto book)
        {
            InitializeComponent();
            Id = book.Id;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            BookDto book = GetBookInfo();

            if (OnDelete != null)
            {
                OnDelete(book);
            }
            this.Close();
        }

        private BookDto GetBookInfo()
        {
            BookDto book = new BookDto();
            book.Id = Id;

            return book;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
