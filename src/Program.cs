namespace LibraryManagementSystem
{

    public class Program
    {
        private static void Main()
        {

            //all Book
            var user1 = new User("Alice", new DateTime(2023, 1, 1));
            var user2 = new User("Bob", new DateTime(2023, 2, 1));
            var user3 = new User("Charlie", new DateTime(2023, 3, 1));
            var user4 = new User("David", new DateTime(2023, 4, 1));
            var user5 = new User("Eve", new DateTime(2024, 5, 1));
            var user6 = new User("Fiona", new DateTime(2024, 6, 1));
            var user7 = new User("George", new DateTime(2024, 7, 1));
            var user8 = new User("Hannah", new DateTime(2024, 8, 1));
            var user9 = new User("Ian");
            var user10 = new User("Julia");
            var book1 = new Book("The Great Gatsby", new DateTime(2023, 1, 1));
            var book2 = new Book("1984", new DateTime(2023, 2, 1));
            var book3 = new Book("To Kill a Mockingbird", new DateTime(2023, 3, 1));
            var book4 = new Book("The Catcher in the Rye", new DateTime(2023, 4, 1));
            var book5 = new Book("Pride and Prejudice", new DateTime(2023, 5, 1));
            var book6 = new Book("Wuthering Heights", new DateTime(2023, 6, 1));
            var book7 = new Book("Jane Eyre", new DateTime(2023, 7, 1));
            var book8 = new Book("Brave New World", new DateTime(2023, 8, 1));
            var book9 = new Book("Moby-Dick", new DateTime(2023, 9, 1));
            var book10 = new Book("War and Peace", new DateTime(2023, 10, 1));
            var book11 = new Book("Hamlet", new DateTime(2023, 11, 1));
            var book12 = new Book("Great Expectations", new DateTime(2023, 12, 1));
            var book13 = new Book("Ulysses", new DateTime(2024, 1, 1));
            var book14 = new Book("The Odyssey", new DateTime(2024, 2, 1));
            var book15 = new Book("The Divine Comedy", new DateTime(2024, 3, 1));
            var book16 = new Book("Crime and Punishment", new DateTime(2024, 4, 1));
            var book17 = new Book("The Brothers Karamazov", new DateTime(2024, 5, 1));
            var book18 = new Book("Don Quixote", new DateTime(2024, 6, 1));
            var book19 = new Book("The Iliad");
            var book20 = new Book("Anna Karenina");
            var book21 = new Book("The Divine Comedy V2", new DateTime(2024, 6, 1));


            var emailService = new EmailNotificationService();
            var smsService = new SMSNotificationService();

            var libraryWithEmail = new Library(emailService);
            var libraryWithSMS = new Library(smsService);

            //library With Email
            Console.WriteLine("\nAdding users and books to Library with Email Notification:\n");
            libraryWithEmail.AddUser(user1);
            libraryWithEmail.AddUser(user2);

            libraryWithEmail.AddUser(user3);
            libraryWithEmail.AddUser(user4);
            libraryWithEmail.AddUser(user5);
            libraryWithEmail.AddUser(user6);
            libraryWithEmail.AddUser(user7);
            libraryWithEmail.AddUser(user8);
            libraryWithEmail.AddUser(user9);
            libraryWithEmail.AddUser(user10);
            libraryWithEmail.AddBook(book1);
            libraryWithEmail.AddBook(book2);
            libraryWithEmail.AddBook(book3);
            libraryWithEmail.AddBook(book4);
            libraryWithEmail.AddBook(book5);
            libraryWithEmail.AddBook(book6);
            libraryWithEmail.AddBook(book7);
            libraryWithEmail.AddBook(book8);
            libraryWithEmail.AddBook(book9);
            libraryWithEmail.AddBook(book10);
            libraryWithEmail.AddBook(book11);
            libraryWithEmail.AddBook(book12);
            libraryWithEmail.AddBook(book13);
            libraryWithEmail.AddBook(book14);
            libraryWithEmail.AddBook(book15);
            libraryWithEmail.AddBook(book16);
            libraryWithEmail.AddBook(book17);
            libraryWithEmail.AddBook(book18);
            libraryWithEmail.AddBook(book19);
            libraryWithEmail.AddBook(book20);
            libraryWithEmail.AddBook(book21);

            //library With SMS
            Console.WriteLine("\nAdding users and books to Library with SMS Notification:\n");
            libraryWithSMS.AddUser(user1);
            libraryWithSMS.AddBook(book1);
            libraryWithSMS.AddUser(user1);
            libraryWithSMS.AddUser(user2);
            libraryWithSMS.AddUser(user3);
            libraryWithSMS.AddUser(user4);
            libraryWithSMS.AddUser(user5);
            libraryWithSMS.AddUser(user6);
            libraryWithSMS.AddUser(user7);
            libraryWithSMS.AddUser(user8);
            libraryWithSMS.AddUser(user9);
            libraryWithSMS.AddUser(user10);
            libraryWithSMS.AddBook(book1);
            libraryWithSMS.AddBook(book2);
            libraryWithSMS.AddBook(book3);
            libraryWithSMS.AddBook(book4);
            libraryWithSMS.AddBook(book5);
            libraryWithSMS.AddBook(book6);
            libraryWithSMS.AddBook(book7);
            libraryWithSMS.AddBook(book8);
            libraryWithSMS.AddBook(book9);
            libraryWithSMS.AddBook(book10);
            libraryWithSMS.AddBook(book11);
            libraryWithSMS.AddBook(book12);
            libraryWithSMS.AddBook(book13);
            libraryWithSMS.AddBook(book14);
            libraryWithSMS.AddBook(book15);
            libraryWithSMS.AddBook(book16);
            libraryWithSMS.AddBook(book17);
            libraryWithSMS.AddBook(book18);
            libraryWithSMS.AddBook(book19);
            libraryWithSMS.AddBook(book20);
            libraryWithSMS.AddBook(book21);
        
            // Display the library contents
            libraryWithEmail.Display();

            // Get all Boos
            List<Book> booksPage = libraryWithEmail.GetAllBooks(1, 3);
            foreach (var book in booksPage)
            {
                Console.WriteLine($"Book ID: {book.Id}, Title: {book.Title}, Created Date: {book.CreatedDate}");
            }

            // Get all users
            List<User> usersPage = libraryWithEmail.GetAllUsers(1, 3);
            foreach (var user in usersPage)
            {
                Console.WriteLine($"User ID: {user.Id}, Name: {user.Name}, Created Date: {user.CreatedDate}");
            }

            Console.Write("\nEnter the book name to search: ");
            string searchTitle = Console.ReadLine();
            libraryWithEmail.FindBooksByTitle(searchTitle);  //Searsh In  library With Email
            // libraryWithSMS.FindBookByTitle(searchTitle);  //Searsh In  library With SMS

            Console.Write("\nEnter the User name to search: ");
            string searchUser = Console.ReadLine();
            libraryWithEmail.FindUserByName(searchUser); //Searsh In  library With Email
            // libraryWithSMS.FindUserByName(searchUser);  //Searsh In  library With SMS

            Console.WriteLine("\nDeleting Book 'The Great Gatsby' By ID ");
            libraryWithEmail.DeleteBookById(book1.Id); //Deleting Book In library With Email
            // libraryWithSMS.DeleteBookById(book1.Id);  //Deleting Book In library With SMS

            // Delete a user by id 
            Console.WriteLine("\nDeleting User Alice By ID ");
            libraryWithEmail.DeleteUserById(user1.Id); //Deleting User In library With Email
            libraryWithSMS.DeleteUserById(user1.Id); //Deleting User In library With SMS


            // Display the library contents after chane 
            libraryWithEmail.Display();    //Display library With Email after Deleting 
            // libraryWithSMS.Display();  //Display library With SMS after Deleting

            Console.WriteLine("\n-------------------- Borrow Book ---------------------");
            libraryWithEmail.BorrowBook(book1, user1, 14);
            libraryWithEmail.BorrowBook(book2, user2, 1);
            libraryWithEmail.BorrowBook(book2, user3, 7);


            Console.WriteLine("\n-------------------- Return Book ---------------------");
            libraryWithEmail.ReturnBook(book1);


            //Level 1 and 2 
            //var library = new Library();
            // // Add all users and Books 
            // library.AddUser(user1);
            // library.AddUser(user2);
            // library.AddUser(user3);
            // library.AddUser(user4);
            // library.AddUser(user5);
            // library.AddUser(user6);
            // library.AddUser(user7);
            // library.AddUser(user8);
            // library.AddUser(user9);
            // library.AddUser(user10);
            // library.AddBook(book1);
            // library.AddBook(book2);
            // library.AddBook(book3);
            // library.AddBook(book4);
            // library.AddBook(book5);
            // library.AddBook(book6);
            // library.AddBook(book7);
            // library.AddBook(book8);
            // library.AddBook(book9);
            // library.AddBook(book10);
            // library.AddBook(book11);
            // library.AddBook(book12);
            // library.AddBook(book13);
            // library.AddBook(book14);
            // library.AddBook(book15);
            // library.AddBook(book16);
            // library.AddBook(book17);
            // library.AddBook(book18);
            // library.AddBook(book19);
            // library.AddBook(book20);
            // library.AddBook(book21);

            // // Display the library contents
            // library.Display();


            // Console.WriteLine("\nGet all books");
            // List<Book> booksPage = library.GetAllBooks(1, 3);
            // foreach (var book in booksPage)
            // {

            //     Console.WriteLine($"Book ID: {book.Id}, Title: {book.Title}, Created Date: {book.CreatedDate}");
            // }
            // Console.WriteLine("\nGet all Users");
            // List<User> usersPage = library.GetAllUsers(1, 3);
            // foreach (var user in usersPage)
            // {
            //     Console.WriteLine($"User ID: {user.Id}, Name: {user.Name}, Created Date: {user.CreatedDate}");
            // }

            // // Find Book by name
            // Console.Write("\nEnter the book name to search: ");
            // string searchTitle = Console.ReadLine();
            // library.FindBookByTitle(searchTitle);

            // // Find users by name
            // Console.Write("\nEnter the User name to search: ");
            // string searchUser = Console.ReadLine();
            // library.FindUserByName(searchUser);


            // // Delete a book by id
            // Console.WriteLine("\nDeleting Book 'The Great Gatsby' By ID ");
            // library.DeleteBookById(book1.Id);


            // // Delete a user by id 
            // Console.WriteLine("\nDeleting User Alice By ID ");
            // library.DeleteUserById(user1.Id);

            // // Display the updated library contents
            // library.Display();
        }
    }
}

