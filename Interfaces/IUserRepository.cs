using BudgetPlanner.DTO;
using BudgetPlanner.Models;

namespace BudgetPlanner.Interfaces
{
    public interface IUserRepository
    {
        bool CreateUser(User user);
        bool DeleteUserById(int id);
        bool ModifyUser(UserDTO user);
        bool UpdateUserIncome(MonthlyBudgetDTO monthlyBudget);
        ProfileDTO GetUserByEmail(CredentialsDTO credentials);
        bool UserEmailExists(string email);
        bool Save();
    }
}
