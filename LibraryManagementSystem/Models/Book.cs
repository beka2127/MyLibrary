namespace LibraryManagementSystem
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty; // Initialize to empty string to prevent nullability warning
        public string Author { get; set; } = string.Empty; // Initialize to empty string
        public string? ISBN { get; set; } // Made nullable as it might genuinely be null
        public bool IsBorrowed { get; set; }

        public override string ToString()
        {
            return $"{Title} by {Author} (ISBN: {ISBN ?? "N/A"}) {(IsBorrowed ? "[Borrowed]" : "[Available]")}";
        }
    }
}