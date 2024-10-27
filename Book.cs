namespace LibraryManagementSystem
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }

        public bool IsBorrowed { get; private set; }
        public User BorrowedBy { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }

        // Constructor 
        public Book(string title, DateTime? createdDate = null)
        {
            Title = title;
            CreatedDate = createdDate ?? DateTime.Now;
        }
    }
}