using BudgetPlanner.Context;
using BudgetPlanner.Interfaces;
using BudgetPlanner.Models;

namespace BudgetPlanner.Repositories
{
    public class BudgetItemRepository : IBudgetItemRepository
    {
        private readonly DataContext _context;
        public BudgetItemRepository(DataContext context)
        {
            _context = context;
        }

        public bool AddNewBudgetItem(BudgetItemDTO budgetItemDTO)
        {
            var budgetItem = new BudgetItem
            {
                Id = budgetItemDTO.Id,
                BudgetItemName = budgetItemDTO.BudgetItemName,
                BudgetItemCost = budgetItemDTO.BudgetItemCost,
                UserId = budgetItemDTO.UserId,
            };

            _context.BudgetItems.Add(budgetItem);
            return Save();
        }

        public bool DeleteBudgetItemById(int id)
        {
            _context.BudgetItems.Remove(_context.BudgetItems.Where(bi => bi.Id == id).First());

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true: false;
        }

        public bool UpdateBudgetItemCost(BudgetItemDTO budgetItemDTO)
        {
            var budgetItem = _context.BudgetItems.Where(bi => bi.Id == budgetItemDTO.Id).FirstOrDefault();

            if (budgetItem == null) {
                return false; //can't find the id
            }

            budgetItem.BudgetItemCost = budgetItemDTO.BudgetItemCost;

            _context.BudgetItems.Update(budgetItem);
            return Save();
        }
    }
}
