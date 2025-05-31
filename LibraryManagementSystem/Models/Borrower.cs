namespace LibraryManagementSystem
{
    public class Borrower
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // Initialize to empty string
        public string? Contact { get; set; } // Made nullable as it might genuinely be null
        public string BorrowerID { get; set; } = string.Empty; // Initialize to empty string

        public override string ToString()
        {
            return $"{Name} (ID: {BorrowerID})";
        }
    }
}