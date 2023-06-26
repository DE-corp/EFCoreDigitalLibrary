namespace EFCoreDigitalLibrary.Repository
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAll();
        Book Get(int id);
        void Create(Book item);
        void Delete(Book item);
        void UpdateIssueYear(int id, short year);
    }
}
