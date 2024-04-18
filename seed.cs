using BudgetPlanner.Context;
using BudgetPlanner.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.ComponentModel.DataAnnotations;

namespace BudgetPlanner
{
    public class seed
    {
        private readonly DataContext _context;
        public seed(DataContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
            if(!_context.Users.Any())
            {
                var seededUserData = new List<User>()
                {
                    new User() {
                        Id = 1,
                        Name = "Bob",
                        Email = "test@a.c",
                        Password = "test",
                        MonthlyIncome = 3500
                    },
                    new User() {
                        Id = 2,
                        Name = "Steve",
                        Email = "x@t.y",
                        Password = "test",
                        MonthlyIncome = 4500
                    },
                    new User() {
                        Id = 3,
                        Name = "John",
                        Email = "j@u.p",
                        Password = "test",
                        MonthlyIncome = 6700
                    },
                };

                var seededBudgetItemData = new List<BudgetItem>()
                {
                    new BudgetItem() {
                        Id = 1,
                        BudgetItemName = "Food",
                        BudgetItemCost = 303.23,
                        UserId = 1
                    },
                    new BudgetItem() {
                        Id = 2,
                        BudgetItemName = "Entertainment",
                        BudgetItemCost = 60,
                        UserId = 1
                    },
                    new BudgetItem() {
                        Id = 3,
                        BudgetItemName = "Rent",
                        BudgetItemCost = 2000,
                        UserId = 2
                    },
                    new BudgetItem() {
                        Id = 4,
                        BudgetItemName = "Clubbing",
                        BudgetItemCost = 300,
                        UserId = 3
                    },
                };

                _context.AddRange(seededUserData);
                _context.AddRange(seededBudgetItemData);
                _context.SaveChanges();

                _context.Database.ExecuteSqlRaw("SELECT setval('\"BudgetItems_Id_seq\"', (SELECT MAX(\"BudgetItems\".\"Id\") FROM \"BudgetItems\"))");
                _context.Database.ExecuteSqlRaw("SELECT setval('\"Users_Id_seq\"', (SELECT MAX(\"Users\".\"Id\") FROM \"Users\"))");
            }
        }
    }
}
