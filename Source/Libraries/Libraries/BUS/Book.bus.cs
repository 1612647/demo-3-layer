
using Libraries.DAO;
using Libraries.DTO;
using System.Data;
using System.Data.SqlClient;

namespace Libraries.BUS
{
    class BookBus
    {
        BookDao bookDao = new BookDao();
        public DataTable LoadBooks()
        {
            return bookDao.LoadBooks();
        }
        public void InsertBook(BookDto book)
        {
            if (string.IsNullOrEmpty(book.Name))
            {
                book.Name = "";
            }
            if (string.IsNullOrEmpty(book.Author))
            {
                book.Author = "";
            }
            if (string.IsNullOrEmpty(book.Note))
            {
                book.Note = "";
            }
            bookDao.InsertBook(book);
        }
        public void UpdateBook(BookDto book)
        {
            if (string.IsNullOrEmpty(book.Name))
            {
                book.Name = "";
            }
            if (string.IsNullOrEmpty(book.Author))
            {
                book.Author = "";
            }
            if (string.IsNullOrEmpty(book.Note))
            {
                book.Note = "";
            }
            bookDao.InsertBook(book);
        }
        public void DeleteBook(int bookId)
        {
            if (bookId != 0)
            {
                bookDao.DeleteBook(bookId);
            }
        }
        public DataTable GetBooksById(int bookId)
        {
            return bookDao.GetBooksById(bookId);
        }
        public DataTable GetBooksByName(string keyword)
        {
            return bookDao.GetBooksByName(keyword);
        }
    }
}
