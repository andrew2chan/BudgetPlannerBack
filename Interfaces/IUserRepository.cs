using BudgetPlanner.DTO;
using BudgetPlanner.Models;

namespace BudgetPlanner.Interfaces
{
    public interface IUserRepository
    {
        bool CreateUser(User user);
        bool DeleteUserById(int id);
        bool ModifyUser(UserDTO user);
        User GetUserById(int id);
        bool UserEmailExists(int id);
        bool Save();
    }
}
