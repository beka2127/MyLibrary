using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq; // Added for .Where() in SeedExampleBooks

namespace LibraryManagementSystem
{
    public class LibraryDatabaseManager
    {
        private string dataSource;

        public LibraryDatabaseManager()
        {
            string dbFileName = "LibraryDB.sqlite";
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            dataSource = Path.Combine(appDirectory, dbFileName);

            InitializeDatabase();
        }

        private string ConnectionString
        {
            get { return $"Data Source={dataSource};Version=3;"; }
        }

        private void InitializeDatabase()
        {
            if (!File.Exists(dataSource))
            {
                SQLiteConnection.CreateFile(dataSource);

                using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
                {
                    conn.Open();

                    string createBooksTable = @"
                        CREATE TABLE IF NOT EXISTS Books (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Title TEXT NOT NULL,
                            Author TEXT NOT NULL,
                            ISBN TEXT UNIQUE,
                            IsBorrowed INTEGER DEFAULT 0
                        );";
                    using (SQLiteCommand cmd = new SQLiteCommand(createBooksTable, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    string createBorrowersTable = @"
                        CREATE TABLE IF NOT EXISTS Borrowers (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name TEXT NOT NULL,
                            Contact TEXT,
                            BorrowerID TEXT UNIQUE NOT NULL
                        );";
                    using (SQLiteCommand cmd = new SQLiteCommand(createBorrowersTable, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    string createBorrowingRecordsTable = @"
                        CREATE TABLE IF NOT EXISTS BorrowingRecords (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            BookId INTEGER NOT NULL,
                            BorrowerId INTEGER NOT NULL,
                            BorrowDate TEXT NOT NULL,
                            DueDate TEXT NOT NULL,
                            ReturnDate TEXT,
                            FOREIGN KEY (BookId) REFERENCES Books(Id) ON DELETE CASCADE,
                            FOREIGN KEY (BorrowerId) REFERENCES Borrowers(Id) ON DELETE CASCADE
                        );";
                    using (SQLiteCommand cmd = new SQLiteCommand(createBorrowingRecordsTable, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    string createUsersTable = @"
                        CREATE TABLE IF NOT EXISTS Users (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Username TEXT UNIQUE NOT NULL,
                            PasswordHash TEXT NOT NULL,
                            Role TEXT NOT NULL DEFAULT 'User'
                        );";
                    using (SQLiteCommand cmd = new SQLiteCommand(createUsersTable, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    SeedExampleBooks(conn);
                    SeedExampleUser(conn);
                }
            }
        }

        private void SeedExampleBooks(SQLiteConnection conn)
        {
            string checkBooksCountQuery = "SELECT COUNT(*) FROM Books;";
            using (SQLiteCommand cmd = new SQLiteCommand(checkBooksCountQuery, conn))
            {
                long bookCount = (long)cmd.ExecuteScalar();
                if (bookCount == 0)
                {
                    List<Book> exampleBooks = new List<Book>
                    {
                        new Book { Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", ISBN = "978-0743273565", IsBorrowed = false },
                        new Book { Title = "To Kill a Mockingbird", Author = "Harper Lee", ISBN = "978-0446310789", IsBorrowed = false },
                        new Book { Title = "1984", Author = "George Orwell", ISBN = "978-0451524935", IsBorrowed = false },
                        new Book { Title = "Pride and Prejudice", Author = "Jane Austen", ISBN = "978-0141439518", IsBorrowed = false },
                        new Book { Title = "The Hobbit", Author = "J.R.R. Tolkien", ISBN = "978-0345339683", IsBorrowed = false }
                    };

                    string insertQuery = "INSERT INTO Books (Title, Author, ISBN, IsBorrowed) VALUES (@Title, @Author, @ISBN, @IsBorrowed)";
                    foreach (var book in exampleBooks)
                    {
                        using (SQLiteCommand insertCmd = new SQLiteCommand(insertQuery, conn))
                        {
                            insertCmd.Parameters.AddWithValue("@Title", book.Title);
                            insertCmd.Parameters.AddWithValue("@Author", book.Author);
                            insertCmd.Parameters.AddWithValue("@ISBN", (object)book.ISBN ?? DBNull.Value);
                            insertCmd.Parameters.AddWithValue("@IsBorrowed", book.IsBorrowed ? 1 : 0);
                            insertCmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        private void SeedExampleUser(SQLiteConnection conn)
        {
            string checkUsersCountQuery = "SELECT COUNT(*) FROM Users;";
            using (SQLiteCommand cmd = new SQLiteCommand(checkUsersCountQuery, conn))
            {
                long userCount = (long)cmd.ExecuteScalar();
                if (userCount == 0)
                {
                    string insertQuery = "INSERT INTO Users (Username, PasswordHash, Role) VALUES (@Username, @PasswordHash, @Role)";
                    using (SQLiteCommand insertCmd = new SQLiteCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@Username", "admin");
                        insertCmd.Parameters.AddWithValue("@PasswordHash", "password"); // IMPORTANT: In a real app, hash passwords securely!
                        insertCmd.Parameters.AddWithValue("@Role", "Admin");
                        insertCmd.ExecuteNonQuery();
                    }
                }
            }
        }

        #region Book Operations (CRUD)

        public void AddBook(Book book)
        {
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                string query = "INSERT INTO Books (Title, Author, ISBN, IsBorrowed) VALUES (@Title, @Author, @ISBN, @IsBorrowed)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Title", book.Title);
                    cmd.Parameters.AddWithValue("@Author", book.Author);
                    cmd.Parameters.AddWithValue("@ISBN", (object)book.ISBN ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsBorrowed", book.IsBorrowed ? 1 : 0);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Book> GetAllBooks(string searchTerm = "")
        {
            List<Book> books = new List<Book>();
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                string query = "SELECT Id, Title, Author, ISBN, IsBorrowed FROM Books";
                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    query += " WHERE Title LIKE @SearchTerm OR Author LIKE @SearchTerm OR ISBN LIKE @SearchTerm";
                }
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    if (!string.IsNullOrWhiteSpace(searchTerm))
                    {
                        cmd.Parameters.AddWithValue("@SearchTerm", $"%{searchTerm}%");
                    }
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            books.Add(new Book
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Title = reader.GetString(reader.GetOrdinal("Title")),
                                Author = reader.GetString(reader.GetOrdinal("Author")),
                                ISBN = reader.IsDBNull(reader.GetOrdinal("ISBN")) ? null : reader.GetString(reader.GetOrdinal("ISBN")),
                                IsBorrowed = reader.GetInt32(reader.GetOrdinal("IsBorrowed")) == 1
                            });
                        }
                    }
                }
            }
            return books;
        }

        public void UpdateBook(Book book)
        {
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                string query = "UPDATE Books SET Title = @Title, Author = @Author, ISBN = @ISBN, IsBorrowed = @IsBorrowed WHERE Id = @Id";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Title", book.Title);
                    cmd.Parameters.AddWithValue("@Author", book.Author);
                    cmd.Parameters.AddWithValue("@ISBN", (object)book.ISBN ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsBorrowed", book.IsBorrowed ? 1 : 0);
                    cmd.Parameters.AddWithValue("@Id", book.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteBook(int bookId)
        {
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                string query = "DELETE FROM Books WHERE Id = @Id";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", bookId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        #endregion

        #region Borrower Operations (CRUD)

        public void AddBorrower(Borrower borrower)
        {
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                string query = "INSERT INTO Borrowers (Name, Contact, BorrowerID) VALUES (@Name, @Contact, @BorrowerID)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", borrower.Name);
                    cmd.Parameters.AddWithValue("@Contact", (object)borrower.Contact ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BorrowerID", borrower.BorrowerID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Borrower> GetAllBorrowers(string searchTerm = "")
        {
            List<Borrower> borrowers = new List<Borrower>();
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                string query = "SELECT Id, Name, Contact, BorrowerID FROM Borrowers";
                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    query += " WHERE Name LIKE @SearchTerm OR BorrowerID LIKE @SearchTerm OR Contact LIKE @SearchTerm";
                }
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    if (!string.IsNullOrWhiteSpace(searchTerm))
                    {
                        cmd.Parameters.AddWithValue("@SearchTerm", $"%{searchTerm}%");
                    }
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            borrowers.Add(new Borrower
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                Contact = reader.IsDBNull(reader.GetOrdinal("Contact")) ? null : reader.GetString(reader.GetOrdinal("Contact")),
                                BorrowerID = reader.GetString(reader.GetOrdinal("BorrowerID"))
                            });
                        }
                    }
                }
            }
            return borrowers;
        }

        public void UpdateBorrower(Borrower borrower)
        {
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                string query = "UPDATE Borrowers SET Name = @Name, Contact = @Contact, BorrowerID = @BorrowerID WHERE Id = @Id";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", borrower.Name);
                    cmd.Parameters.AddWithValue("@Contact", (object)borrower.Contact ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BorrowerID", borrower.BorrowerID);
                    cmd.Parameters.AddWithValue("@Id", borrower.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteBorrower(int borrowerId)
        {
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                string query = "DELETE FROM Borrowers WHERE Id = @Id";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", borrowerId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        #endregion

        #region User Operations (Authentication and Management)

        public User? AuthenticateUser(string username, string password)
        {
            User? user = null;
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                string query = "SELECT Id, Username, PasswordHash, Role FROM Users WHERE Username = @Username";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedPasswordHash = reader.GetString(reader.GetOrdinal("PasswordHash"));
                            if (password == storedPasswordHash) // IMPORTANT: In a real app, hash passwords securely!
                            {
                                user = new User
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                    Username = reader.GetString(reader.GetOrdinal("Username")),
                                    PasswordHash = storedPasswordHash,
                                    Role = reader.GetString(reader.GetOrdinal("Role"))
                                };
                            }
                        }
                    }
                }
            }
            return user;
        }

        public void AddUser(User user)
        {
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                string query = "INSERT INTO Users (Username, PasswordHash, Role) VALUES (@Username, @PasswordHash, @Role)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                    cmd.Parameters.AddWithValue("@Role", (object)user.Role ?? "User");
                    cmd.ExecuteNonQuery();
                }
            }
        }

        #endregion

        #region Borrowing Operations (NEW)

        public void IssueBook(int bookId, int borrowerId, DateTime borrowDate, DateTime dueDate)
        {
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                using (SQLiteTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string insertRecordQuery = "INSERT INTO BorrowingRecords (BookId, BorrowerId, BorrowDate, DueDate, ReturnDate) VALUES (@BookId, @BorrowerId, @BorrowDate, @DueDate, NULL)";
                        using (SQLiteCommand cmd = new SQLiteCommand(insertRecordQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@BookId", bookId);
                            cmd.Parameters.AddWithValue("@BorrowerId", borrowerId);
                            cmd.Parameters.AddWithValue("@BorrowDate", borrowDate.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                            cmd.Parameters.AddWithValue("@DueDate", dueDate.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                            cmd.ExecuteNonQuery();
                        }

                        string updateBookQuery = "UPDATE Books SET IsBorrowed = 1 WHERE Id = @BookId";
                        using (SQLiteCommand cmd = new SQLiteCommand(updateBookQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@BookId", bookId);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public List<BorrowingRecord> GetIssuedBooks()
        {
            List<BorrowingRecord> records = new List<BorrowingRecord>();
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                string query = @"
                    SELECT
                        br.Id, br.BookId, br.BorrowerId, br.BorrowDate, br.DueDate, br.ReturnDate,
                        b.Title AS BookTitle, b.ISBN,
                        bor.Name AS BorrowerName, bor.BorrowerID
                    FROM BorrowingRecords br
                    JOIN Books b ON br.BookId = b.Id
                    JOIN Borrowers bor ON br.BorrowerId = bor.Id
                    WHERE br.ReturnDate IS NULL;"; // Get only currently issued books

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            records.Add(new BorrowingRecord
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                BookId = reader.GetInt32(reader.GetOrdinal("BookId")),
                                BorrowerId = reader.GetInt32(reader.GetOrdinal("BorrowerId")),
                                BorrowDate = DateTime.Parse(reader.GetString(reader.GetOrdinal("BorrowDate"))),
                                DueDate = DateTime.Parse(reader.GetString(reader.GetOrdinal("DueDate"))),
                                ReturnDate = reader.IsDBNull(reader.GetOrdinal("ReturnDate")) ? (DateTime?)null : DateTime.Parse(reader.GetString(reader.GetOrdinal("ReturnDate"))),
                                BookTitle = reader.IsDBNull(reader.GetOrdinal("BookTitle")) ? null : reader.GetString(reader.GetOrdinal("BookTitle")),
                                ISBN = reader.IsDBNull(reader.GetOrdinal("ISBN")) ? null : reader.GetString(reader.GetOrdinal("ISBN")),
                                BorrowerName = reader.IsDBNull(reader.GetOrdinal("BorrowerName")) ? null : reader.GetString(reader.GetOrdinal("BorrowerName")),
                                BorrowerID = reader.IsDBNull(reader.GetOrdinal("BorrowerID")) ? null : reader.GetString(reader.GetOrdinal("BorrowerID"))
                            });
                        }
                    }
                }
            }
            return records;
        }

        #endregion
    }
}