namespace EFCoreDigitalLibrary.Repository
{
    public class BookRepository : IBookRepository
    {
        private AppContext _db;

        public BookRepository(AppContext? db)
        {
            _db = db;
        }

        public void Create(Book item)
        {
            _db.Books.Add(item);
            _db.SaveChanges();
        }

        public void Delete(Book item)
        {
            _db.Books.Remove(item);
            _db.SaveChanges();
        }

        public Book Get(int id)
        {
            return _db.Books.FirstOrDefault(book => book.Id == id);
        }

        public IEnumerable<Book> GetAll()
        {
            return _db.Books.ToList();
        }

        public void UpdateIssueYear(int id, short year)
        {
            var book = _db.Books.FirstOrDefault(book => book.Id == id);
            book.IssueYear = year;
            _db.SaveChanges();
        }

        public List<Book> GetBooksByGenreAndYear(string genre, short year1, short year2)
        {
            return _db.Books.Where(u => u.Genre == genre).Where(x => x.IssueYear >= year1 && x.IssueYear <= year2).ToList();
        }

        public int CountBookByAutor(string autor)
        {
            return _db.Books.Where(x => x.Autor == autor).Count();
        }

        public int CountBookByGenre(string genre)
        {
            return _db.Books.Where(x => x.Genre == genre).Count();
        }

        public bool IsBookByAutorAndTitle(string autor, string title)
        {
            var book = _db.Books.Where(x => x.Autor == autor && x.Name == title).Count();
            if (book != 0)
            {
                return true;
            }
            else return false;
        }

        public bool IsBookInHand(string title)
        {
            var book = _db.Books.Where(x => x.Name == title && x.UserId != 0).Count();

            if (book != 0)
            {
                return true;
            }
            else return false;
        }

        public Book LastBook()
        {
            return _db.Books.OrderByDescending(x => x.IssueYear).First();
        }

        public List<Book> ListBooksAsc()
        {
            return _db.Books.OrderBy(x => x.Name).ToList();
        }

        public List<Book> ListBooksDesc()
        {
            return _db.Books.OrderByDescending(x => x.IssueYear).ToList();
        }
    }
}
