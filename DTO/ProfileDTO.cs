﻿using BudgetPlanner.Models;

namespace BudgetPlanner.DTO
{
    public class ProfileDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public double MonthlyIncome { get; set; }
        public ICollection<BudgetItem> BudgetItems { get; set; }
    }
}
