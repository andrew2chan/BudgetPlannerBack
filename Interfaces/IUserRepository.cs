using BudgetPlanner.Models;

namespace BudgetPlanner.Interfaces
{
    public interface IUserRepository
    {
        bool CreateUser(User user);
        bool DeleteUserById(int id);
        bool ModifyUser(User user);
        bool UserEmailExists(int id);
        bool Save();
    }
}
