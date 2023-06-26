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
    }
}
