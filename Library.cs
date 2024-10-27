namespace LibraryManagementSystem
{
    public class Library
    {
        private List<Book> _books;
        private List<User> _users;
        private readonly INotificationService _notificationService;

        private Dictionary<Book, User> _BorrowedBooks = new Dictionary<Book, User>();
        private Dictionary<Book, List<DateTime>> _BorrowingHistory = new Dictionary<Book, List<DateTime>>();

        public Library(INotificationService notificationService)
        {
            _books = new List<Book>();
            _users = new List<User>();
            _notificationService = notificationService;
        }

        //Add new book to the library
        public void AddBook(Book book)
        {
            if (book == null)
            {
                // throw new ArgumentNullException(nameof(book), "Book cannot be null.");
                _notificationService.SendNotificationOnFailure($"We encountered an issue adding '{book.Title}'. Please review the input data.");
            }
            _books.Add(book);
            _notificationService.SendNotificationOnSuccess($"Book '{book.Title}' added Successfully");
        }
        //Add new user to the library
        public void AddUser(User user)
        {
            if (user == null)
            {
                // throw new ArgumentNullException(nameof(user), "User cannot be null.");  
                _notificationService.SendNotificationOnSuccess($"Error adding User'{user.Name}'.");
            }
            _users.Add(user);
            _notificationService.SendNotificationOnSuccess($"User '{user.Name}' added Successfully.");
        }


        public List<Book> GetAllBooks(int pageNumber, int pageSize)
        {
            // Simulated database query to get books sorted by created date with pagination
            return _books.OrderBy(b => b.CreatedDate)
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();
        }

        public List<User> GetAllUsers(int pageNumber, int pageSize)
        {
            // Simulated database query to get users sorted by created date with pagination
            return _users.OrderBy(u => u.CreatedDate)
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();
        }


        //Find Books By Title
        public void FindBooksByTitle(string title)
        {
            if (title == null)
            {
                Console.WriteLine("Title cannot be null. Please provide a valid title.");
                return;
            }
            // Search for books whose titles contain the provided title (case-insensitive search)
            //Because it is a library, the user may forget the  title of the book or remember a part of you. Therefore, if the user enters a letter that reminds him of the title of the book, it will return all the books that contain this letter "J " or a group of letters "Mo".
            var foundBooks = _books.Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();

            if (foundBooks.Count == 0)
            {
                Console.WriteLine($"No books found with the title '{title}'");
            }
            else
            {
                foreach (var book in foundBooks)
                {
                    Console.WriteLine($"Book found - Title '{book.Title}'");
                    Console.WriteLine($"{book.Id}\t{book.Title}\t{book.CreatedDate.ToString("M/d/yyyy h:mm:ss tt")}");
                }
            }
        }

        //Find Users By Name

        public void FindUserByName(string name)
        {
            // Check if the name is null
            if (name == null)
            {
                Console.WriteLine("User Name cannot be null. Please provide a valid Name.");
                return; // Exit the method if the name is null
            }

            // Search for users with the exact matching name (case-insensitive comparison)
            var foundUser = _users.Where(u => string.Equals(u.Name, name, StringComparison.OrdinalIgnoreCase)).ToList();

            // Display appropriate messages based on the search results
            if (foundUser.Count == 0)
            {
                Console.WriteLine($"No User found with the Name '{name}'");
            }
            else
            {
                // Display information for each found user
                foreach (var user in foundUser)
                {
                    Console.WriteLine($"Found User - '{user.Name}'");
                    Console.WriteLine($"{user.Id}\t{user.Name}\t{user.CreatedDate.ToString("M/d/yyyy h:mm:ss tt")}");
                }
            }
        }

        // Delete book by id
        public void DeleteBookById(Guid bookId)
        {
            var bookToDelete = _books.FirstOrDefault(b => b.Id == bookId);

            if (bookToDelete != null)
            {
                _books.Remove(bookToDelete);
                //Console.WriteLine($"Book with ID {bookId} has been deleted.");
                _notificationService.SendNotificationOnSuccess($"Book with ID {bookId} has been deleted.");
            }
            else
            {
                //Console.WriteLine($"Book with ID {bookId} not found.");
                _notificationService.SendNotificationOnFailure($"Book with ID {bookId} not found.");
            }
        }

        //Delete User by id
        public void DeleteUserById(Guid userId)
        {
            var userToDelete = _users.FirstOrDefault(u => u.Id == userId);

            if (userToDelete != null)
            {
                _users.Remove(userToDelete);
                //Console.WriteLine($"User with ID {userId} has been deleted.");
                _notificationService.SendNotificationOnSuccess($"User with ID {userId} has been deleted.");
            }
            else
            {
                // Console.WriteLine($"User with ID {userId} not found.");
                _notificationService.SendNotificationOnFailure($"User with ID {userId} not found.");
            }
        }

        //Level 4  Borrow Book

        public void BorrowBook(Book book, User user, int daysToReturn)
        {
            if (book == null)
            {
                Console.WriteLine("Book Title is Null!!");
                return;
            }

            if (user == null)
            {
                Console.WriteLine("User Name is Null!!");
                return;
            }

            if (_BorrowedBooks.ContainsKey(book))
            {
                Console.WriteLine($"Book '{book.Title}' is already borrowed by another user.");
                return;
            }

            _BorrowedBooks.Add(book, user);
            book.BorrowedBy = user;
            book.BorrowDate = DateTime.Now;
            book.DueDate = book.BorrowDate.AddDays(daysToReturn);

            if (!_BorrowingHistory.ContainsKey(book))
            {
                _BorrowingHistory.Add(book, new List<DateTime>());
            }
            _BorrowingHistory[book].Add(book.BorrowDate);

            Console.WriteLine($"User '{user.Name}' borrowed Book '{book.Title}' on {book.BorrowDate.ToString("yyyy-MM-dd HH:mm:ss")}. Due date: {book.DueDate.ToString("yyyy-MM-dd")}");
        }

        public void ReturnBook(Book book)
        {
            if (book == null)
            {
                Console.WriteLine("Book Title is Null!!");
            }
            if (!_BorrowedBooks.ContainsKey(book))
            {
                Console.WriteLine($"Book '{book.Title}' is not currently borrowed.");
                return;
            }
            User user = _BorrowedBooks[book];
            _BorrowedBooks.Remove(book);
            DateTime returnDate = DateTime.Now;

            if (returnDate > book.DueDate)
            {
                int daysLate = (returnDate - book.DueDate).Days;
                user.PenaltyPoints += daysLate; // Add penalty points based on days late

                Console.WriteLine($"User '{user.Name}' returned Book '{book.Title}' {daysLate} days late. Penalty points applied: {daysLate}");
            }
            else
            {
                Console.WriteLine($"User '{user.Name}' returned Book '{book.Title}' on time.");
            }
            book.BorrowedBy = null;
            book.BorrowDate = DateTime.MinValue;
            book.DueDate = DateTime.MinValue;
        }


        public void Display()
        {
            Console.WriteLine("\nLibrary Contents:");
            Console.WriteLine("\nBooks:");
            Console.WriteLine("ID\t\t\t\t\tTitle\t\t\t\tCreated Date");
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
            foreach (var book in _books)
            {
                Console.WriteLine($"{book.Id}\t{book.Title.PadRight(30)}\t{book.CreatedDate.ToString("M/d/yyyy h:mm:ss tt")}");
            }
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
            Console.WriteLine("\nUsers:");
            Console.WriteLine("ID\t\t\t\t\tName\t\t\t\tCreated Date");
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
            foreach (var user in _users)
            {
                Console.WriteLine($"{user.Id}\t{user.Name.PadRight(30)}\t{user.CreatedDate.ToString("M/d/yyyy h:mm:ss tt")}");
            }
            Console.WriteLine("----------------------------------------------------------------------------------------------------\n");
        }

    }
}