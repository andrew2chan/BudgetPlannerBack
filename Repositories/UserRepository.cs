using BudgetPlanner.Context;
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
            _context.Users.Add(user);
            return Save();
        }

        public bool DeleteUserById(int id)
        {
            var itemToRemove = _context.Users.Where(u => u.Id == id).FirstOrDefault();
            _context.Users.Remove(itemToRemove);
            return Save();
        }

        public bool ModifyUser(User user)
        {
            _context.Users.Update(user);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UserEmailExists(int id)
        {
            return _context.Users.Where(u => u.Id == id).Any();
        }
    }
}
