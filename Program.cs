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

            // Получаем книги по жанру и году
            var booksByGenreAndYear = bookRepository.GetBooksByGenreAndYear("Genre2", 1912, 1991);

            //Получаем количество книг определенного автора в библиотеке
            var countBookByAutor = bookRepository.CountBookByAutor("Autor1");

            //Получаем количество книг определенного жанра в библиотеке
            var countBookByGenre = bookRepository.CountBookByGenre("Genre3");

            //Получаем булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке
            var isBookByAutorAndTitle = bookRepository.IsBookByAutorAndTitle("Лев Толстой", "Война и мир");

            //Получаем булевый флаг о том, есть ли определенная книга на руках у пользователя
            var isBookInHand = bookRepository.IsBookInHand("Книга1");

            //Получаем количество книг на руках у пользователя
            var countBooksInHand = userRepository.BooksCount("Dmitry");

            //Получение последней вышедшей книги
            var lastBook = bookRepository.LastBook();

            //Получение списка всех книг, отсортированного в алфавитном порядке по названию
            var SortedBooksByAlphabet = bookRepository.ListBooksAsc();

            //Получение списка всех книг, отсортированного в порядке убывания года их выхода
            var SortedBooksByYear = bookRepository.ListBooksDesc();
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
