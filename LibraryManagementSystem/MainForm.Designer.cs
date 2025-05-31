namespace LibraryManagementSystem
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabBooks = new System.Windows.Forms.TabPage();
            this.btnBookSearch = new System.Windows.Forms.Button();
            this.txtBookSearch = new System.Windows.Forms.TextBox();
            this.lblBookSearch = new System.Windows.Forms.Label();
            this.btnClearBookFields = new System.Windows.Forms.Button();
            this.chkBookIsBorrowed = new System.Windows.Forms.CheckBox();
            this.lblBookIsBorrowed = new System.Windows.Forms.Label();
            this.btnDeleteBook = new System.Windows.Forms.Button();
            this.btnUpdateBook = new System.Windows.Forms.Button();
            this.btnAddBook = new System.Windows.Forms.Button();
            this.txtBookISBN = new System.Windows.Forms.TextBox();
            this.txtBookAuthor = new System.Windows.Forms.TextBox();
            this.txtBookTitle = new System.Windows.Forms.TextBox();
            this.lblBookISBN = new System.Windows.Forms.Label();
            this.lblBookAuthor = new System.Windows.Forms.Label();
            this.lblBookTitle = new System.Windows.Forms.Label();
            this.dgvBooks = new System.Windows.Forms.DataGridView();
            this.tabBorrowers = new System.Windows.Forms.TabPage();
            this.btnBorrowerSearch = new System.Windows.Forms.Button();
            this.txtBorrowerSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClearBorrowerFields = new System.Windows.Forms.Button();
            this.btnDeleteBorrower = new System.Windows.Forms.Button();
            this.btnUpdateBorrower = new System.Windows.Forms.Button();
            this.btnAddBorrower = new System.Windows.Forms.Button();
            this.txtBorrowerContact = new System.Windows.Forms.TextBox();
            this.txtBorrowerID = new System.Windows.Forms.TextBox();
            this.txtBorrowerName = new System.Windows.Forms.TextBox();
            this.lblBorrowerContact = new System.Windows.Forms.Label();
            this.lblBorrowerID = new System.Windows.Forms.Label();
            this.lblBorrowerName = new System.Windows.Forms.Label();
            this.dgvBorrowers = new System.Windows.Forms.DataGridView();
            this.tabBorrowing = new System.Windows.Forms.TabPage();
            this.btnRefreshIssuedBooks = new System.Windows.Forms.Button();
            this.dgvIssuedBooks = new System.Windows.Forms.DataGridView();
            this.btnIssueBook = new System.Windows.Forms.Button();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.dtpBorrowDate = new System.Windows.Forms.DateTimePicker();
            this.cmbBorrowers = new System.Windows.Forms.ComboBox();
            this.cmbBooks = new System.Windows.Forms.ComboBox();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.lblBorrowDate = new System.Windows.Forms.Label();
            this.lblSelectBorrower = new System.Windows.Forms.Label();
            this.lblSelectBook = new System.Windows.Forms.Label();
            this.tabControlMain.SuspendLayout();
            this.tabBooks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).BeginInit();
            this.tabBorrowers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrowers)).BeginInit();
            this.tabBorrowing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIssuedBooks)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabBooks);
            this.tabControlMain.Controls.Add(this.tabBorrowers);
            this.tabControlMain.Controls.Add(this.tabBorrowing);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(800, 600);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabBooks
            // 
            this.tabBooks.Controls.Add(this.btnBookSearch);
            this.tabBooks.Controls.Add(this.txtBookSearch);
            this.tabBooks.Controls.Add(this.lblBookSearch);
            this.tabBooks.Controls.Add(this.btnClearBookFields);
            this.tabBooks.Controls.Add(this.chkBookIsBorrowed);
            this.tabBooks.Controls.Add(this.lblBookIsBorrowed);
            this.tabBooks.Controls.Add(this.btnDeleteBook);
            this.tabBooks.Controls.Add(this.btnUpdateBook);
            this.tabBooks.Controls.Add(this.btnAddBook);
            this.tabBooks.Controls.Add(this.txtBookISBN);
            this.tabBooks.Controls.Add(this.txtBookAuthor);
            this.tabBooks.Controls.Add(this.txtBookTitle);
            this.tabBooks.Controls.Add(this.lblBookISBN);
            this.tabBooks.Controls.Add(this.lblBookAuthor);
            this.tabBooks.Controls.Add(this.lblBookTitle);
            this.tabBooks.Controls.Add(this.dgvBooks);
            this.tabBooks.Location = new System.Drawing.Point(4, 25);
            this.tabBooks.Name = "tabBooks";
            this.tabBooks.Padding = new System.Windows.Forms.Padding(3);
            this.tabBooks.Size = new System.Drawing.Size(792, 571);
            this.tabBooks.TabIndex = 0;
            this.tabBooks.Text = "Book Management";
            this.tabBooks.UseVisualStyleBackColor = true;
            // 
            // btnBookSearch
            // 
            this.btnBookSearch.Location = new System.Drawing.Point(340, 250);
            this.btnBookSearch.Name = "btnBookSearch";
            this.btnBookSearch.Size = new System.Drawing.Size(75, 23);
            this.btnBookSearch.TabIndex = 15;
            this.btnBookSearch.Text = "Search";
            this.btnBookSearch.UseVisualStyleBackColor = true;
            // 
            // txtBookSearch
            // 
            this.txtBookSearch.Location = new System.Drawing.Point(120, 250);
            this.txtBookSearch.Name = "txtBookSearch";
            this.txtBookSearch.Size = new System.Drawing.Size(200, 22);
            this.txtBookSearch.TabIndex = 14;
            // 
            // lblBookSearch
            // 
            this.lblBookSearch.AutoSize = true;
            this.lblBookSearch.Location = new System.Drawing.Point(20, 250);
            this.lblBookSearch.Name = "lblBookSearch";
            this.lblBookSearch.Size = new System.Drawing.Size(53, 16);
            this.lblBookSearch.TabIndex = 13;
            this.lblBookSearch.Text = "Search:";
            // 
            // btnClearBookFields
            // 
            this.btnClearBookFields.Location = new System.Drawing.Point(340, 180);
            this.btnClearBookFields.Name = "btnClearBookFields";
            this.btnClearBookFields.Size = new System.Drawing.Size(75, 23);
            this.btnClearBookFields.TabIndex = 12;
            this.btnClearBookFields.Text = "Clear";
            this.btnClearBookFields.UseVisualStyleBackColor = true;
            // 
            // chkBookIsBorrowed
            // 
            this.chkBookIsBorrowed.AutoSize = true;
            this.chkBookIsBorrowed.Location = new System.Drawing.Point(120, 150);
            this.chkBookIsBorrowed.Name = "chkBookIsBorrowed";
            this.chkBookIsBorrowed.Size = new System.Drawing.Size(18, 17);
            this.chkBookIsBorrowed.TabIndex = 11;
            this.chkBookIsBorrowed.UseVisualStyleBackColor = true;
            // 
            // lblBookIsBorrowed
            // 
            this.lblBookIsBorrowed.AutoSize = true;
            this.lblBookIsBorrowed.Location = new System.Drawing.Point(20, 150);
            this.lblBookIsBorrowed.Name = "lblBookIsBorrowed";
            this.lblBookIsBorrowed.Size = new System.Drawing.Size(81, 16);
            this.lblBookIsBorrowed.TabIndex = 10;
            this.lblBookIsBorrowed.Text = "Is Borrowed:";
            // 
            // btnDeleteBook
            // 
            this.btnDeleteBook.Location = new System.Drawing.Point(230, 180);
            this.btnDeleteBook.Name = "btnDeleteBook";
            this.btnDeleteBook.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteBook.TabIndex = 9;
            this.btnDeleteBook.Text = "Delete";
            this.btnDeleteBook.UseVisualStyleBackColor = true;
            // 
            // btnUpdateBook
            // 
            this.btnUpdateBook.Location = new System.Drawing.Point(120, 180);
            this.btnUpdateBook.Name = "btnUpdateBook";
            this.btnUpdateBook.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateBook.TabIndex = 8;
            this.btnUpdateBook.Text = "Update";
            this.btnUpdateBook.UseVisualStyleBackColor = true;
            // 
            // btnAddBook
            // 
            this.btnAddBook.Location = new System.Drawing.Point(20, 180);
            this.btnAddBook.Name = "btnAddBook";
            this.btnAddBook.Size = new System.Drawing.Size(75, 23);
            this.btnAddBook.TabIndex = 7;
            this.btnAddBook.Text = "Add";
            this.btnAddBook.UseVisualStyleBackColor = true;
            this.btnAddBook.Click += new System.EventHandler(this.btnAddBook_Click_1);
            // 
            // txtBookISBN
            // 
            this.txtBookISBN.Location = new System.Drawing.Point(120, 110);
            this.txtBookISBN.Name = "txtBookISBN";
            this.txtBookISBN.Size = new System.Drawing.Size(200, 22);
            this.txtBookISBN.TabIndex = 6;
            // 
            // txtBookAuthor
            // 
            this.txtBookAuthor.Location = new System.Drawing.Point(120, 70);
            this.txtBookAuthor.Name = "txtBookAuthor";
            this.txtBookAuthor.Size = new System.Drawing.Size(200, 22);
            this.txtBookAuthor.TabIndex = 5;
            // 
            // txtBookTitle
            // 
            this.txtBookTitle.Location = new System.Drawing.Point(120, 30);
            this.txtBookTitle.Name = "txtBookTitle";
            this.txtBookTitle.Size = new System.Drawing.Size(200, 22);
            this.txtBookTitle.TabIndex = 4;
            // 
            // lblBookISBN
            // 
            this.lblBookISBN.AutoSize = true;
            this.lblBookISBN.Location = new System.Drawing.Point(20, 110);
            this.lblBookISBN.Name = "lblBookISBN";
            this.lblBookISBN.Size = new System.Drawing.Size(41, 16);
            this.lblBookISBN.TabIndex = 3;
            this.lblBookISBN.Text = "ISBN:";
            // 
            // lblBookAuthor
            // 
            this.lblBookAuthor.AutoSize = true;
            this.lblBookAuthor.Location = new System.Drawing.Point(20, 70);
            this.lblBookAuthor.Name = "lblBookAuthor";
            this.lblBookAuthor.Size = new System.Drawing.Size(48, 16);
            this.lblBookAuthor.TabIndex = 2;
            this.lblBookAuthor.Text = "Author:";
            // 
            // lblBookTitle
            // 
            this.lblBookTitle.AutoSize = true;
            this.lblBookTitle.Location = new System.Drawing.Point(20, 30);
            this.lblBookTitle.Name = "lblBookTitle";
            this.lblBookTitle.Size = new System.Drawing.Size(36, 16);
            this.lblBookTitle.TabIndex = 1;
            this.lblBookTitle.Text = "Title:";
            // 
            // dgvBooks
            // 
            this.dgvBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBooks.Location = new System.Drawing.Point(8, 290);
            this.dgvBooks.Name = "dgvBooks";
            this.dgvBooks.RowHeadersWidth = 51;
            this.dgvBooks.RowTemplate.Height = 24;
            this.dgvBooks.Size = new System.Drawing.Size(776, 260);
            this.dgvBooks.TabIndex = 0;
            // 
            // tabBorrowers
            // 
            this.tabBorrowers.Controls.Add(this.btnBorrowerSearch);
            this.tabBorrowers.Controls.Add(this.txtBorrowerSearch);
            this.tabBorrowers.Controls.Add(this.label1);
            this.tabBorrowers.Controls.Add(this.btnClearBorrowerFields);
            this.tabBorrowers.Controls.Add(this.btnDeleteBorrower);
            this.tabBorrowers.Controls.Add(this.btnUpdateBorrower);
            this.tabBorrowers.Controls.Add(this.btnAddBorrower);
            this.tabBorrowers.Controls.Add(this.txtBorrowerContact);
            this.tabBorrowers.Controls.Add(this.txtBorrowerID);
            this.tabBorrowers.Controls.Add(this.txtBorrowerName);
            this.tabBorrowers.Controls.Add(this.lblBorrowerContact);
            this.tabBorrowers.Controls.Add(this.lblBorrowerID);
            this.tabBorrowers.Controls.Add(this.lblBorrowerName);
            this.tabBorrowers.Controls.Add(this.dgvBorrowers);
            this.tabBorrowers.Location = new System.Drawing.Point(4, 25);
            this.tabBorrowers.Name = "tabBorrowers";
            this.tabBorrowers.Padding = new System.Windows.Forms.Padding(3);
            this.tabBorrowers.Size = new System.Drawing.Size(792, 571);
            this.tabBorrowers.TabIndex = 1;
            this.tabBorrowers.Text = "Borrower Management";
            this.tabBorrowers.UseVisualStyleBackColor = true;
            // 
            // btnBorrowerSearch
            // 
            this.btnBorrowerSearch.Location = new System.Drawing.Point(340, 180);
            this.btnBorrowerSearch.Name = "btnBorrowerSearch";
            this.btnBorrowerSearch.Size = new System.Drawing.Size(75, 23);
            this.btnBorrowerSearch.TabIndex = 13;
            this.btnBorrowerSearch.Text = "Search";
            this.btnBorrowerSearch.UseVisualStyleBackColor = true;
            // 
            // txtBorrowerSearch
            // 
            this.txtBorrowerSearch.Location = new System.Drawing.Point(120, 180);
            this.txtBorrowerSearch.Name = "txtBorrowerSearch";
            this.txtBorrowerSearch.Size = new System.Drawing.Size(200, 22);
            this.txtBorrowerSearch.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Search:";
            // 
            // btnClearBorrowerFields
            // 
            this.btnClearBorrowerFields.Location = new System.Drawing.Point(340, 140);
            this.btnClearBorrowerFields.Name = "btnClearBorrowerFields";
            this.btnClearBorrowerFields.Size = new System.Drawing.Size(75, 23);
            this.btnClearBorrowerFields.TabIndex = 10;
            this.btnClearBorrowerFields.Text = "Clear";
            this.btnClearBorrowerFields.UseVisualStyleBackColor = true;
            // 
            // btnDeleteBorrower
            // 
            this.btnDeleteBorrower.Location = new System.Drawing.Point(230, 140);
            this.btnDeleteBorrower.Name = "btnDeleteBorrower";
            this.btnDeleteBorrower.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteBorrower.TabIndex = 9;
            this.btnDeleteBorrower.Text = "Delete";
            this.btnDeleteBorrower.UseVisualStyleBackColor = true;
            // 
            // btnUpdateBorrower
            // 
            this.btnUpdateBorrower.Location = new System.Drawing.Point(120, 140);
            this.btnUpdateBorrower.Name = "btnUpdateBorrower";
            this.btnUpdateBorrower.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateBorrower.TabIndex = 8;
            this.btnUpdateBorrower.Text = "Update";
            this.btnUpdateBorrower.UseVisualStyleBackColor = true;
            // 
            // btnAddBorrower
            // 
            this.btnAddBorrower.Location = new System.Drawing.Point(20, 140);
            this.btnAddBorrower.Name = "btnAddBorrower";
            this.btnAddBorrower.Size = new System.Drawing.Size(75, 23);
            this.btnAddBorrower.TabIndex = 7;
            this.btnAddBorrower.Text = "Add";
            this.btnAddBorrower.UseVisualStyleBackColor = true;
            // 
            // txtBorrowerContact
            // 
            this.txtBorrowerContact.Location = new System.Drawing.Point(120, 100);
            this.txtBorrowerContact.Name = "txtBorrowerContact";
            this.txtBorrowerContact.Size = new System.Drawing.Size(200, 22);
            this.txtBorrowerContact.TabIndex = 6;
            // 
            // txtBorrowerID
            // 
            this.txtBorrowerID.Location = new System.Drawing.Point(120, 60);
            this.txtBorrowerID.Name = "txtBorrowerID";
            this.txtBorrowerID.Size = new System.Drawing.Size(200, 22);
            this.txtBorrowerID.TabIndex = 5;
            // 
            // txtBorrowerName
            // 
            this.txtBorrowerName.Location = new System.Drawing.Point(120, 20);
            this.txtBorrowerName.Name = "txtBorrowerName";
            this.txtBorrowerName.Size = new System.Drawing.Size(200, 22);
            this.txtBorrowerName.TabIndex = 4;
            // 
            // lblBorrowerContact
            // 
            this.lblBorrowerContact.AutoSize = true;
            this.lblBorrowerContact.Location = new System.Drawing.Point(20, 100);
            this.lblBorrowerContact.Name = "lblBorrowerContact";
            this.lblBorrowerContact.Size = new System.Drawing.Size(55, 16);
            this.lblBorrowerContact.TabIndex = 3;
            this.lblBorrowerContact.Text = "Contact:";
            // 
            // lblBorrowerID
            // 
            this.lblBorrowerID.AutoSize = true;
            this.lblBorrowerID.Location = new System.Drawing.Point(20, 60);
            this.lblBorrowerID.Name = "lblBorrowerID";
            this.lblBorrowerID.Size = new System.Drawing.Size(80, 16);
            this.lblBorrowerID.TabIndex = 2;
            this.lblBorrowerID.Text = "Borrower ID:";
            // 
            // lblBorrowerName
            // 
            this.lblBorrowerName.AutoSize = true;
            this.lblBorrowerName.Location = new System.Drawing.Point(20, 20);
            this.lblBorrowerName.Name = "lblBorrowerName";
            this.lblBorrowerName.Size = new System.Drawing.Size(47, 16);
            this.lblBorrowerName.TabIndex = 1;
            this.lblBorrowerName.Text = "Name:";
            // 
            // dgvBorrowers
            // 
            this.dgvBorrowers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBorrowers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBorrowers.Location = new System.Drawing.Point(8, 220);
            this.dgvBorrowers.Name = "dgvBorrowers";
            this.dgvBorrowers.RowHeadersWidth = 51;
            this.dgvBorrowers.RowTemplate.Height = 24;
            this.dgvBorrowers.Size = new System.Drawing.Size(776, 330);
            this.dgvBorrowers.TabIndex = 0;
            // 
            // tabBorrowing
            // 
            this.tabBorrowing.Controls.Add(this.btnRefreshIssuedBooks);
            this.tabBorrowing.Controls.Add(this.dgvIssuedBooks);
            this.tabBorrowing.Controls.Add(this.btnIssueBook);
            this.tabBorrowing.Controls.Add(this.dtpDueDate);
            this.tabBorrowing.Controls.Add(this.dtpBorrowDate);
            this.tabBorrowing.Controls.Add(this.cmbBorrowers);
            this.tabBorrowing.Controls.Add(this.cmbBooks);
            this.tabBorrowing.Controls.Add(this.lblDueDate);
            this.tabBorrowing.Controls.Add(this.lblBorrowDate);
            this.tabBorrowing.Controls.Add(this.lblSelectBorrower);
            this.tabBorrowing.Controls.Add(this.lblSelectBook);
            this.tabBorrowing.Location = new System.Drawing.Point(4, 25);
            this.tabBorrowing.Name = "tabBorrowing";
            this.tabBorrowing.Padding = new System.Windows.Forms.Padding(3);
            this.tabBorrowing.Size = new System.Drawing.Size(792, 571);
            this.tabBorrowing.TabIndex = 2;
            this.tabBorrowing.Text = "Borrow/Return";
            this.tabBorrowing.UseVisualStyleBackColor = true;
            // 
            // btnRefreshIssuedBooks
            // 
            this.btnRefreshIssuedBooks.Location = new System.Drawing.Point(20, 240);
            this.btnRefreshIssuedBooks.Name = "btnRefreshIssuedBooks";
            this.btnRefreshIssuedBooks.Size = new System.Drawing.Size(150, 23);
            this.btnRefreshIssuedBooks.TabIndex = 10;
            this.btnRefreshIssuedBooks.Text = "Refresh Issued Books";
            this.btnRefreshIssuedBooks.UseVisualStyleBackColor = true;
            // 
            // dgvIssuedBooks
            // 
            this.dgvIssuedBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvIssuedBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIssuedBooks.Location = new System.Drawing.Point(8, 280);
            this.dgvIssuedBooks.Name = "dgvIssuedBooks";
            this.dgvIssuedBooks.RowHeadersWidth = 51;
            this.dgvIssuedBooks.RowTemplate.Height = 24;
            this.dgvIssuedBooks.Size = new System.Drawing.Size(776, 270);
            this.dgvIssuedBooks.TabIndex = 9;
            // 
            // btnIssueBook
            // 
            this.btnIssueBook.Location = new System.Drawing.Point(20, 200);
            this.btnIssueBook.Name = "btnIssueBook";
            this.btnIssueBook.Size = new System.Drawing.Size(100, 23);
            this.btnIssueBook.TabIndex = 8;
            this.btnIssueBook.Text = "Issue Book";
            this.btnIssueBook.UseVisualStyleBackColor = true;
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.Location = new System.Drawing.Point(140, 160);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(200, 22);
            this.dtpDueDate.TabIndex = 7;
            // 
            // dtpBorrowDate
            // 
            this.dtpBorrowDate.Location = new System.Drawing.Point(140, 120);
            this.dtpBorrowDate.Name = "dtpBorrowDate";
            this.dtpBorrowDate.Size = new System.Drawing.Size(200, 22);
            this.dtpBorrowDate.TabIndex = 6;
            // 
            // cmbBorrowers
            // 
            this.cmbBorrowers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBorrowers.FormattingEnabled = true;
            this.cmbBorrowers.Location = new System.Drawing.Point(140, 70);
            this.cmbBorrowers.Name = "cmbBorrowers";
            this.cmbBorrowers.Size = new System.Drawing.Size(200, 24);
            this.cmbBorrowers.TabIndex = 5;
            // 
            // cmbBooks
            // 
            this.cmbBooks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBooks.FormattingEnabled = true;
            this.cmbBooks.Location = new System.Drawing.Point(140, 30);
            this.cmbBooks.Name = "cmbBooks";
            this.cmbBooks.Size = new System.Drawing.Size(200, 24);
            this.cmbBooks.TabIndex = 4;
            // 
            // lblDueDate
            // 
            this.lblDueDate.AutoSize = true;
            this.lblDueDate.Location = new System.Drawing.Point(20, 160);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(67, 16);
            this.lblDueDate.TabIndex = 3;
            this.lblDueDate.Text = "Due Date:";
            // 
            // lblBorrowDate
            // 
            this.lblBorrowDate.AutoSize = true;
            this.lblBorrowDate.Location = new System.Drawing.Point(20, 120);
            this.lblBorrowDate.Name = "lblBorrowDate";
            this.lblBorrowDate.Size = new System.Drawing.Size(84, 16);
            this.lblBorrowDate.TabIndex = 2;
            this.lblBorrowDate.Text = "Borrow Date:";
            // 
            // lblSelectBorrower
            // 
            this.lblSelectBorrower.AutoSize = true;
            this.lblSelectBorrower.Location = new System.Drawing.Point(20, 70);
            this.lblSelectBorrower.Name = "lblSelectBorrower";
            this.lblSelectBorrower.Size = new System.Drawing.Size(105, 16);
            this.lblSelectBorrower.TabIndex = 1;
            this.lblSelectBorrower.Text = "Select Borrower:";
            // 
            // lblSelectBook
            // 
            this.lblSelectBook.AutoSize = true;
            this.lblSelectBook.Location = new System.Drawing.Point(20, 30);
            this.lblSelectBook.Name = "lblSelectBook";
            this.lblSelectBook.Size = new System.Drawing.Size(83, 16);
            this.lblSelectBook.TabIndex = 0;
            this.lblSelectBook.Text = "Select Book:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.tabControlMain);
            this.Name = "MainForm";
            this.Text = "Library Management System";
            this.tabControlMain.ResumeLayout(false);
            this.tabBooks.ResumeLayout(false);
            this.tabBooks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).EndInit();
            this.tabBorrowers.ResumeLayout(false);
            this.tabBorrowers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrowers)).EndInit();
            this.tabBorrowing.ResumeLayout(false);
            this.tabBorrowing.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIssuedBooks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabBooks;
        private System.Windows.Forms.DataGridView dgvBooks;
        private System.Windows.Forms.TextBox txtBookISBN;
        private System.Windows.Forms.TextBox txtBookAuthor;
        private System.Windows.Forms.TextBox txtBookTitle;
        private System.Windows.Forms.Label lblBookISBN;
        private System.Windows.Forms.Label lblBookAuthor;
        private System.Windows.Forms.Label lblBookTitle;
        private System.Windows.Forms.Button btnDeleteBook;
        private System.Windows.Forms.Button btnUpdateBook;
        private System.Windows.Forms.Button btnAddBook;
        private System.Windows.Forms.CheckBox chkBookIsBorrowed;
        private System.Windows.Forms.Label lblBookIsBorrowed;
        private System.Windows.Forms.Button btnClearBookFields;
        private System.Windows.Forms.Button btnBookSearch;
        private System.Windows.Forms.TextBox txtBookSearch;
        private System.Windows.Forms.Label lblBookSearch;
        private System.Windows.Forms.TabPage tabBorrowers;
        private System.Windows.Forms.Button btnBorrowerSearch;
        private System.Windows.Forms.TextBox txtBorrowerSearch;
        private System.Windows.Forms.Label label1; // Make sure this matches your label for borrower search
        private System.Windows.Forms.Button btnClearBorrowerFields;
        private System.Windows.Forms.Button btnDeleteBorrower;
        private System.Windows.Forms.Button btnUpdateBorrower;
        private System.Windows.Forms.Button btnAddBorrower;
        private System.Windows.Forms.TextBox txtBorrowerContact;
        private System.Windows.Forms.TextBox txtBorrowerID;
        private System.Windows.Forms.TextBox txtBorrowerName;
        private System.Windows.Forms.Label lblBorrowerContact;
        private System.Windows.Forms.Label lblBorrowerID;
        private System.Windows.Forms.Label lblBorrowerName;
        private System.Windows.Forms.DataGridView dgvBorrowers;

        // NEW CONTROLS FOR BORROWING TAB
        private System.Windows.Forms.TabPage tabBorrowing;
        private System.Windows.Forms.ComboBox cmbBooks;
        private System.Windows.Forms.Label lblSelectBook;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.DateTimePicker dtpBorrowDate;
        private System.Windows.Forms.ComboBox cmbBorrowers;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.Label lblBorrowDate;
        private System.Windows.Forms.Label lblSelectBorrower;
        private System.Windows.Forms.Button btnIssueBook;
        private System.Windows.Forms.DataGridView dgvIssuedBooks;
        private System.Windows.Forms.Button btnRefreshIssuedBooks;
    }
}