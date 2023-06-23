namespace EFCoreDigitalLibrary
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public IEnumerable<Book> Books { get; set; } = new List<Book>();
    }
}
