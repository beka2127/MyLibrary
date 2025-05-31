using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace LibraryManagementSystem
{
    public partial class MainForm : Form
    {
        private LibraryDatabaseManager dbManager;

        public MainForm()
        {
            InitializeComponent();
            dbManager = new LibraryDatabaseManager();

            this.Load += new EventHandler(MainForm_Load);

            SetupDataGridView(dgvBooks);
            SetupDataGridView(dgvBorrowers);
            SetupDataGridView(dgvIssuedBooks);

            dgvBooks.SelectionChanged += dgvBooks_SelectionChanged;
            dgvBorrowers.SelectionChanged += dgvBorrowers_SelectionChanged;

            btnAddBook.Click += btnAddBook_Click;
            btnUpdateBook.Click += btnUpdateBook_Click;
            btnDeleteBook.Click += btnDeleteBook_Click;
            btnClearBookFields.Click += btnClearBookFields_Click;
            btnBookSearch.Click += btnBookSearch_Click;

            btnAddBorrower.Click += btnAddBorrower_Click;
            btnUpdateBorrower.Click += btnUpdateBorrower_Click;
            btnDeleteBorrower.Click += btnDeleteBorrower_Click;
            btnClearBorrowerFields.Click += btnClearBorrowerFields_Click;
            btnBorrowerSearch.Click += btnBorrowerSearch_Click;

            btnIssueBook.Click += btnIssueBook_Click;
            btnRefreshIssuedBooks.Click += btnRefreshIssuedBooks_Click;

            dtpBorrowDate.Value = DateTime.Now;
            dtpDueDate.Value = DateTime.Now.AddDays(14);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadBooksIntoDataGridView();
            LoadBorrowersIntoDataGridView();
            LoadIssuedBooksIntoDataGridView();
            PopulateBookComboBox();
            PopulateBorrowerComboBox();
        }

        private void SetupDataGridView(DataGridView dgv)
        {
            dgv.AutoGenerateColumns = true;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgv.BorderStyle = BorderStyle.None;
            dgv.BackgroundColor = SystemColors.Control;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.RowHeadersVisible = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSlateGray;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font(dgv.Font, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = dgv.ColumnHeadersDefaultCellStyle.BackColor;
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = dgv.ColumnHeadersDefaultCellStyle.ForeColor;
            dgv.EnableHeadersVisualStyles = false;
            dgv.DefaultCellStyle.SelectionBackColor = Color.SkyBlue;
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
        }

        #region Book Management

        private void LoadBooksIntoDataGridView(string searchTerm = "")
        {
            List<Book> books = dbManager.GetAllBooks(searchTerm);
            dgvBooks.DataSource = books;
            PopulateBookComboBox();
        }

        private void ClearBookFields()
        {
            txtBookTitle.Clear();
            txtBookAuthor.Clear();
            txtBookISBN.Clear();
            chkBookIsBorrowed.Checked = false;
            dgvBooks.ClearSelection();
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBookTitle.Text) || string.IsNullOrWhiteSpace(txtBookAuthor.Text))
            {
                MessageBox.Show("Title and Author cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Book newBook = new Book
                {
                    Title = txtBookTitle.Text.Trim(),
                    Author = txtBookAuthor.Text.Trim(),
                    ISBN = txtBookISBN.Text.Trim(),
                    IsBorrowed = chkBookIsBorrowed.Checked
                };
                dbManager.AddBook(newBook);
                MessageBox.Show("Book added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearBookFields();
                LoadBooksIntoDataGridView();
                LoadIssuedBooksIntoDataGridView();
            }
            catch (SQLiteException ex)
            {
                if (ex.Message.Contains("UNIQUE constraint failed: Books.ISBN"))
                {
                    MessageBox.Show("A book with this ISBN already exists. Please enter a unique ISBN.", "Duplicate ISBN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"Database error adding book: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateBook_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a book to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtBookTitle.Text) || string.IsNullOrWhiteSpace(txtBookAuthor.Text))
            {
                MessageBox.Show("Title and Author cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int bookId = (int)dgvBooks.SelectedRows[0].Cells["Id"].Value;

                Book updatedBook = new Book
                {
                    Id = bookId,
                    Title = txtBookTitle.Text.Trim(),
                    Author = txtBookAuthor.Text.Trim(),
                    ISBN = txtBookISBN.Text.Trim(),
                    IsBorrowed = chkBookIsBorrowed.Checked
                };

                dbManager.UpdateBook(updatedBook);
                MessageBox.Show("Book updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearBookFields();
                LoadBooksIntoDataGridView();
                LoadIssuedBooksIntoDataGridView();
            }
            catch (SQLiteException ex)
            {
                if (ex.Message.Contains("UNIQUE constraint failed: Books.ISBN"))
                {
                    MessageBox.Show("A book with this ISBN already exists. Please enter a unique ISBN or use the existing one.", "Duplicate ISBN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"Database error updating book: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteBook_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a book to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this book?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int bookId = (int)dgvBooks.SelectedRows[0].Cells["Id"].Value;
                    dbManager.DeleteBook(bookId);
                    MessageBox.Show("Book deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearBookFields();
                    LoadBooksIntoDataGridView();
                    LoadIssuedBooksIntoDataGridView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClearBookFields_Click(object sender, EventArgs e)
        {
            ClearBookFields();
        }

        private void btnBookSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtBookSearch.Text.Trim();
            LoadBooksIntoDataGridView(searchTerm);
        }

        private void dgvBooks_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvBooks.SelectedRows[0];
                txtBookTitle.Text = selectedRow.Cells["Title"].Value?.ToString();
                txtBookAuthor.Text = selectedRow.Cells["Author"].Value?.ToString();
                txtBookISBN.Text = selectedRow.Cells["ISBN"].Value?.ToString();
                chkBookIsBorrowed.Checked = (bool)selectedRow.Cells["IsBorrowed"].Value;
            }
            else
            {
                ClearBookFields();
            }
        }

        #endregion

        #region Borrower Management

        private void LoadBorrowersIntoDataGridView(string searchTerm = "")
        {
            List<Borrower> borrowers = dbManager.GetAllBorrowers(searchTerm);
            dgvBorrowers.DataSource = borrowers;
            PopulateBorrowerComboBox();
        }

        private void ClearBorrowerFields()
        {
            txtBorrowerName.Clear();
            txtBorrowerContact.Clear();
            txtBorrowerID.Clear();
            dgvBorrowers.ClearSelection();
        }

        private void btnAddBorrower_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBorrowerName.Text) || string.IsNullOrWhiteSpace(txtBorrowerID.Text))
            {
                MessageBox.Show("Name and Borrower ID cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Borrower newBorrower = new Borrower
                {
                    Name = txtBorrowerName.Text.Trim(),
                    Contact = txtBorrowerContact.Text.Trim(),
                    BorrowerID = txtBorrowerID.Text.Trim()
                };
                dbManager.AddBorrower(newBorrower);
                MessageBox.Show("Borrower added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearBorrowerFields();
                LoadBorrowersIntoDataGridView();
            }
            catch (SQLiteException ex)
            {
                if (ex.Message.Contains("UNIQUE constraint failed: Borrowers.BorrowerID"))
                {
                    MessageBox.Show("A borrower with this ID already exists. Please enter a unique Borrower ID.", "Duplicate Borrower ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"Database error adding borrower: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateBorrower_Click(object sender, EventArgs e)
        {
            if (dgvBorrowers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a borrower to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtBorrowerName.Text) || string.IsNullOrWhiteSpace(txtBorrowerID.Text))
            {
                MessageBox.Show("Name and Borrower ID cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int borrowerId = (int)dgvBorrowers.SelectedRows[0].Cells["Id"].Value;

                Borrower updatedBorrower = new Borrower
                {
                    Id = borrowerId,
                    Name = txtBorrowerName.Text.Trim(),
                    Contact = txtBorrowerContact.Text.Trim(),
                    BorrowerID = txtBorrowerID.Text.Trim()
                };

                dbManager.UpdateBorrower(updatedBorrower);
                MessageBox.Show("Borrower updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearBorrowerFields();
                LoadBorrowersIntoDataGridView();
            }
            catch (SQLiteException ex)
            {
                if (ex.Message.Contains("UNIQUE constraint failed: Borrowers.BorrowerID"))
                {
                    MessageBox.Show("A borrower with this ID already exists. Please enter a unique Borrower ID or use the existing one.", "Duplicate Borrower ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"Database error updating borrower: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteBorrower_Click(object sender, EventArgs e)
        {
            if (dgvBorrowers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a borrower to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this borrower?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int borrowerId = (int)dgvBorrowers.SelectedRows[0].Cells["Id"].Value;
                    dbManager.DeleteBorrower(borrowerId);
                    MessageBox.Show("Borrower deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearBorrowerFields();
                    LoadBorrowersIntoDataGridView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClearBorrowerFields_Click(object sender, EventArgs e)
        {
            ClearBorrowerFields();
        }

        private void btnBorrowerSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtBorrowerSearch.Text.Trim();
            LoadBorrowersIntoDataGridView(searchTerm);
        }

        private void dgvBorrowers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBorrowers.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvBorrowers.SelectedRows[0];
                txtBorrowerName.Text = selectedRow.Cells["Name"].Value?.ToString();
                txtBorrowerContact.Text = selectedRow.Cells["Contact"].Value?.ToString();
                txtBorrowerID.Text = selectedRow.Cells["BorrowerID"].Value?.ToString();
            }
            else
            {
                ClearBorrowerFields();
            }
        }

        #endregion

        #region Borrowing Feature

        private void PopulateBookComboBox()
        {
            List<Book> books = dbManager.GetAllBooks();
            List<Book> availableBooks = books.Where(b => !b.IsBorrowed).ToList();

            cmbBooks.DataSource = null;
            cmbBooks.DisplayMember = "Title";
            cmbBooks.ValueMember = "Id";
            cmbBooks.DataSource = availableBooks;

            if (cmbBooks.Items.Count > 0)
            {
                cmbBooks.SelectedIndex = 0;
            }
            else
            {
                cmbBooks.Text = "";
            }
        }

        private void PopulateBorrowerComboBox()
        {
            List<Borrower> borrowers = dbManager.GetAllBorrowers();
            cmbBorrowers.DataSource = null;
            cmbBorrowers.DisplayMember = "Name";
            cmbBorrowers.ValueMember = "Id";
            cmbBorrowers.DataSource = borrowers;

            if (cmbBorrowers.Items.Count > 0)
            {
                cmbBorrowers.SelectedIndex = 0;
            }
            else
            {
                cmbBorrowers.Text = "";
            }
        }

        private void LoadIssuedBooksIntoDataGridView()
        {
            List<BorrowingRecord> issuedRecords = dbManager.GetIssuedBooks();
            dgvIssuedBooks.DataSource = issuedRecords;

            if (dgvIssuedBooks.Columns.Contains("BookId")) dgvIssuedBooks.Columns["BookId"].Visible = false;
            if (dgvIssuedBooks.Columns.Contains("BorrowerId")) dgvIssuedBooks.Columns["BorrowerId"].Visible = false;
            if (dgvIssuedBooks.Columns.Contains("ReturnDate")) dgvIssuedBooks.Columns["ReturnDate"].Visible = false;

            if (dgvIssuedBooks.Columns.Contains("BookTitle")) dgvIssuedBooks.Columns["BookTitle"].HeaderText = "Book Title";
            if (dgvIssuedBooks.Columns.Contains("BorrowerName")) dgvIssuedBooks.Columns["BorrowerName"].HeaderText = "Borrower Name";
            if (dgvIssuedBooks.Columns.Contains("BorrowDate")) dgvIssuedBooks.Columns["BorrowDate"].HeaderText = "Borrowed Date";
            if (dgvIssuedBooks.Columns.Contains("DueDate")) dgvIssuedBooks.Columns["DueDate"].HeaderText = "Due Date";
            if (dgvIssuedBooks.Columns.Contains("ISBN")) dgvIssuedBooks.Columns["ISBN"].HeaderText = "ISBN";
            if (dgvIssuedBooks.Columns.Contains("BorrowerID")) dgvIssuedBooks.Columns["BorrowerID"].HeaderText = "Borrower ID";
        }

        private void btnIssueBook_Click(object sender, EventArgs e)
        {
            if (cmbBooks.SelectedValue == null || cmbBorrowers.SelectedValue == null)
            {
                MessageBox.Show("Please select both a book and a borrower.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int bookId = (int)cmbBooks.SelectedValue;
            int borrowerId = (int)cmbBorrowers.SelectedValue;
            DateTime borrowDate = dtpBorrowDate.Value;
            DateTime dueDate = dtpDueDate.Value;

            if (dueDate <= borrowDate)
            {
                MessageBox.Show("Due Date must be after Borrow Date.", "Date Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Book? selectedBook = cmbBooks.SelectedItem as Book;
            if (selectedBook != null && selectedBook.IsBorrowed)
            {
                MessageBox.Show("This book is already borrowed.", "Book Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                PopulateBookComboBox();
                return;
            }

            try
            {
                dbManager.IssueBook(bookId, borrowerId, borrowDate, dueDate);
                MessageBox.Show("Book issued successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadBooksIntoDataGridView();
                LoadIssuedBooksIntoDataGridView();
                PopulateBookComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while issuing the book: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefreshIssuedBooks_Click(object sender, EventArgs e)
        {
            LoadIssuedBooksIntoDataGridView();
        }

        #endregion

        private void btnAddBook_Click_1(object sender, EventArgs e)
        {

        }
    }
}