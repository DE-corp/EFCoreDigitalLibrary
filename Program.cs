namespace EFCoreDigitalLibrary;
public class Program
{
    static void Main(string[] args)
    {
        using (var db = new AppContext())

        {
            var book1 = new Book { Name = "Книга1", IssueYear = 1991 };
            var book2 = new Book { Name = "Книга2", IssueYear = 1989 };

            var user1 = new User { Name = "Arthur", Email = "Admin", Books = new List<Book> { book1 } };
            var user2 = new User { Name = "Klim", Email = "User", Books = new List<Book> { book2 } };

            

            db.Users.Add(user1);
            db.Users.Add(user2);

            db.Books.Add(book1);
            db.Books.Add(book2);

            db.SaveChanges();
        }
    }
}
