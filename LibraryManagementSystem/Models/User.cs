namespace LibraryManagementSystem
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty; // Initialize to empty string
        public string PasswordHash { get; set; } = string.Empty; // Initialize to empty string
        public string Role { get; set; } = "User";
    }
}