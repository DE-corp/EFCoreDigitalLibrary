namespace EFCoreDigitalLibrary.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User Get(int id);
        void Create(User item);
        void Delete(User item);
        void UpdateUserName(int id, string name);
    }
}
