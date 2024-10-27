namespace LibraryManagementSystem
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
         public int PenaltyPoints { get; set; } // Penalty points for the user        public List<Book> BorrowedBooks { get; set; }

        // Constructor 
        public User(string name, DateTime? createdDate = null)
        {
            Name = name;
            CreatedDate = createdDate ?? DateTime.Now;
            PenaltyPoints = 0;
        }
    }
}