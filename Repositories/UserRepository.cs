using BudgetPlanner.Context;
using BudgetPlanner.DTO;
using BudgetPlanner.Interfaces;
using BudgetPlanner.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlanner.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context) {
            _context = context;
        }

        public bool CreateUser(User user)
        {
            if (UserEmailExists(user.Email)) return false;

            _context.Users.Add(user);
            return Save();
        }

        public bool DeleteUserById(int id)
        {
            var itemToRemove = _context.Users.Where(u => u.Id == id).FirstOrDefault();
            _context.Users.Remove(itemToRemove);
            return Save();
        }

        public User GetUserByEmail(CredentialsDTO credentials)
        {
            var existingUser = _context.Users.Where(u => u.Email == credentials.Email).Include(u => u.BudgetItems).FirstOrDefault();

            if (existingUser == null) return null;

            return existingUser;
        }

        public bool ModifyUser(UserDTO user)
        {
            var existingUser = _context.Users.Include(u => u.BudgetItems).FirstOrDefault(u => u.Id == user.Id);

            if (existingUser == null) return false; //user does not exist

            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;

            _context.Users.Update(existingUser);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateUserIncome(MonthlyBudgetDTO monthlyBudget)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == monthlyBudget.Id);

            if(user == null) return false;

            user.MonthlyIncome = monthlyBudget.MonthlyIncome;

            _context.Users.Update(user);
            return Save();
        }

        public bool UserEmailExists(string email)
        {
            return _context.Users.Where(u => u.Email == email).Any();
        }
    }
}
