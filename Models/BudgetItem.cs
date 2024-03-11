namespace BudgetPlanner.Models
{
    public class BudgetItem
    {
        public int Id { get; set; }
        public string item_name { get; set; }
        public decimal item_budget { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
