namespace BudgetPlanner.Models
{
    public class BudgetItem
    {
        public int Id { get; set; }
        public string BudgetItemName { get; set; }
        public double BudgetItemCost { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
