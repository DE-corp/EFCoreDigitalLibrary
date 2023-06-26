namespace EFCoreDigitalLibrary
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public short IssueYear { get; set; }
        public string Autor { get; set; }
        public string Genre { get; set; }

        // Внешний ключ
        public int UserId { get; set; }
        // Навигационное свойство
        public User User { get; set; }

    }
}
