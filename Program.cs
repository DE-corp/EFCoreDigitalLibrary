using EFCoreDigitalLibrary.Repository;

namespace EFCoreDigitalLibrary;
public class Program
{
    static void Main(string[] args)
    {

        using (var db = new AppContext())

        {
            var bookRepository = new BookRepository(db);
            var userRepository = new UserRepository(db);

            var book1 = new Book { Name = "Книга1", IssueYear = 1991 };
            var book2 = new Book { Name = "Книга2", IssueYear = 1989 };

            var user1 = new User { Name = "Arthur", Email = "Admin", Books = new List<Book> { book1 } };
            var user2 = new User { Name = "Klim", Email = "User", Books = new List<Book> { book2 } };

            userRepository.Create(user1);
            userRepository.Create(user2);
            ShowUsers(userRepository);

            userRepository.Delete(user1);
            ShowUsers(userRepository);

            userRepository.UpdateUserName(2, "Artur");
            ShowUsers(userRepository);
        }
    }

    static void ShowUsers(UserRepository userRepository)
    {
        foreach (var item in userRepository.GetAll())
        {
            Console.WriteLine(item.Name);
        }
        Console.WriteLine();
    }
}
