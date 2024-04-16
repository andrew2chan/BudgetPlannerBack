using BudgetPlanner.Models;

namespace BudgetPlanner.Interfaces
{
    public interface IBudgetItemRepository
    {
        bool DeleteBudgetItemById(int id);
        bool AddNewBudgetItem(BudgetItemDTO budgetItemDTO);
        bool UpdateBudgetItemCost(BudgetItemDTO budgetItemDTO);
        bool Save();
    }
}
