using BudgetPlanner.Models;

namespace BudgetPlanner.Interfaces
{
    public interface IBudgetItemRepository
    {
        ICollection<BudgetItem> GetBudgetItemsByUserId(int id);
        BudgetItem GetBudgetItemById(int id);
        bool Save();
    }
}
