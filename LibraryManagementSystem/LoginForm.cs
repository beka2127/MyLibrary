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
    public partial class LoginForm : Form
    {
        private LibraryDatabaseManager dbManager;

        public LoginForm()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
            dbManager = new LibraryDatabaseManager();
            this.AcceptButton = btnLogin;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            User? authenticatedUser = dbManager.AuthenticateUser(username, password);

            if (authenticatedUser != null)
            {
                MessageBox.Show($"Login successful! Welcome, {authenticatedUser.Username} ({authenticatedUser.Role}).", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                MainForm mainForm = new MainForm();
                mainForm.Show();

                mainForm.FormClosed += (s, args) => this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtUsername.Focus();
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Username and Password cannot be empty for sign up.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                User newUser = new User
                {
                    Username = txtUsername.Text.Trim(),
                    PasswordHash = txtPassword.Text.Trim(), // IMPORTANT: In a real app, hash passwords securely!
                    Role = "User"
                };

                dbManager.AddUser(newUser);
                MessageBox.Show("User signed up successfully! You can now log in.", "Sign Up Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtUsername.Clear();
                txtPassword.Clear();
                txtUsername.Focus();
            }
            catch (SQLiteException ex)
            {
                if (ex.Message.Contains("UNIQUE constraint failed: Users.Username"))
                {
                    MessageBox.Show("Username already exists. Please choose a different username.", "Sign Up Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"An error occurred during sign up: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }
    }
}