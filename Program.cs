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

            #region /// Заполнение базы данными ///
            var user1 = new User { Name = "Arthur", Email = "Arthur@mail.com" };
            var user2 = new User { Name = "Klim", Email = "Klim@mail.com" };

            var user3 = new User { Name = "Dmitry", Email = "Dmitry@mail.com" };

            db.Users.Add(user3);
            db.SaveChanges();

            var book1 = new Book { Name = "Книга1", IssueYear = 1991, Autor = "Autor1", Genre = "Genre1" };
            var book2 = new Book { Name = "Книга2", IssueYear = 1989, Autor = "Autor2", Genre = "Genre2" };
            var book3 = new Book { Name = "Книга3", IssueYear = 1912, Autor = "Autor3", Genre = "Genre3" };

            book1.User = user1;
            user2.Books.Add(book2);
            book3.UserId = user3.Id;

            db.Users.AddRange(user1, user2);
            db.Books.AddRange(book1, book2, book3);

            db.SaveChanges();
            #endregion

            ShowUsers(userRepository);

            //userRepository.Delete(user1);
            //ShowUsers(userRepository);

            //userRepository.UpdateUserName(1, "Artur");
            //ShowUsers(userRepository);
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
