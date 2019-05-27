using Libraries.DTO;
using System.Data;
using System.Data.SqlClient;

namespace Libraries.DAO
{
    class BookDao
    {
        const string connectionString = @"Data Source=.;Initial Catalog=LibrariesDb;Integrated Security=True";
        SqlConnection conn = new SqlConnection(connectionString);
        public DataTable LoadBooks()
        {
            string sqlQuerry = "SELECT * FROM Book";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlQuerry, conn);

            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }
        public void InsertBook(BookDto book)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sqlQuerry = "INSERT INTO Book (Name, Author, Note) VALUES(@name, @author, @note)";

            SqlCommand command = new SqlCommand(sqlQuerry, conn);
            command.Parameters.AddWithValue("@name", book.Name);
            command.Parameters.AddWithValue("@author", book.Author);
            command.Parameters.AddWithValue("@note", book.Note);
            command.ExecuteNonQuery();
            conn.Close();
        }
        public void UpdateBook(BookDto book)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sqlQuerry = "UPDATE Book SET Name = @name, Author = @author, Note = @note WHERE Id = @id";

            SqlCommand command = new SqlCommand(sqlQuerry, conn);
            command.Parameters.AddWithValue("@name", book.Name);
            command.Parameters.AddWithValue("@author", book.Author);
            command.Parameters.AddWithValue("@note", book.Note);
            command.Parameters.AddWithValue("@id", book.Id);
            command.ExecuteNonQuery();
            conn.Close();
        }
        public void DeleteBook(int bookId)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sqlQuerry = "DELETE FROM Book WHERE Id = @id";

            SqlCommand command = new SqlCommand(sqlQuerry, conn);
            command.Parameters.AddWithValue("@id", bookId);
            command.ExecuteNonQuery();
            conn.Close();
        }

        public DataTable GetBooksById(int bookId)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            string sqlQuerry = "SELECT * FROM Book WHERE Id = @id";

            SqlDataAdapter adapter = new SqlDataAdapter(sqlQuerry, conn);
            adapter.SelectCommand.Parameters.AddWithValue("@id", bookId);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }
        public DataTable GetBooksByName(string keyword)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            string sqlQuerry = "SELECT * FROM Book WHERE Name LIKE '%' + @keyword + '%'";

            SqlDataAdapter adapter = new SqlDataAdapter(sqlQuerry, conn);
            adapter.SelectCommand.Parameters.AddWithValue("@keyword", keyword);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }
    }
}
