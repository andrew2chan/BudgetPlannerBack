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

        public BudgetItem GetBudgetItemById(int id)
        {
            var budgetItem = _context.BudgetItems.Where(bi => bi.Id == id).FirstOrDefault();
            return budgetItem;
        }

        public ICollection<BudgetItem> GetBudgetItemsByUserId(int id)
        {
            var budgetItems = _context.BudgetItems.Where(bi => bi.UserId == id).ToList();
            return budgetItems;
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
