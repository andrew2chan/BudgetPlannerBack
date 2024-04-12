using BudgetPlanner.Models;

namespace BudgetPlanner.Interfaces
{
    public interface IBudgetItemRepository
    {
        ICollection<BudgetItem> GetBudgetItemsByUserId(int id);
        BudgetItem GetBudgetItemById(int id);
        bool UpdateBudgetItemCost(BudgetItemDTO budgetItemDTO);
        bool Save();
    }
}
