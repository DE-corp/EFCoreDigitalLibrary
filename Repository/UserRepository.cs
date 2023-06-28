namespace EFCoreDigitalLibrary.Repository
{
    public class UserRepository : IUserRepository
    {
        private AppContext _db;

        public UserRepository(AppContext? db)
        {
            _db = db;
        }

        public IEnumerable<User> GetAll()
        {
            return _db.Users.ToList();
        }

        public User Get(int id)
        {
            return _db.Users.FirstOrDefault(user => user.Id == id);
        }

        public void Create(User item)
        {
            _db.Users.Add(item);
            _db.SaveChanges();
        }

        public void Delete(User item)
        {
            _db.Users.Remove(item);
            _db.SaveChanges();
        }

        public void UpdateUserName(int id, string name)
        {
            var user = _db.Users.FirstOrDefault(user => user.Id == id);
            user.Name = name;
            _db.SaveChanges();
        }

        public int BooksCount(string name)
        {
            return _db.Users.Where(x => x.Name == name).Select(x => x.Books).Count();
        }
    }
}
