using E_Com.Models.Data;

namespace E_Com.Business.Interfaces
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        User CreateUser(User user);
        void UpdateUser(string UserId, string Username, string Paswword, int TypeId);
        User GetUserById(string? id);
    }
}
