using System;

namespace LibraryManagementSystem
{
    public class BorrowingRecord
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int BorrowerId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; } // Nullable for currently issued books

        // Properties for UI display (populated via JOINs in DbManager)
        public string? BookTitle { get; set; } // Made nullable
        public string? BorrowerName { get; set; } // Made nullable
        public string? ISBN { get; set; } // Made nullable
        public string? BorrowerID { get; set; } // Made nullable

        public override string ToString()
        {
            return $"Book: {BookTitle ?? "N/A"} (ISBN: {ISBN ?? "N/A"}), Borrower: {BorrowerName ?? "N/A"} (ID: {BorrowerID ?? "N/A"}), Borrowed: {BorrowDate.ToShortDateString()}, Due: {DueDate.ToShortDateString()}";
        }
    }
}