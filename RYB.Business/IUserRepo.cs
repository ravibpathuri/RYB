using RYB.Model.ViewModel;

namespace RYB.Business
{
    public interface IUserRepo
    {
        Task<IEnumerable<User>> GetUsers();
        Task<IEnumerable<User>> GetUserByEmail(string userEmail);
    }
}