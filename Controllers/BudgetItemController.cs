using BudgetPlanner.Interfaces;
using BudgetPlanner.Models;
using Microsoft.AspNetCore.Mvc;

namespace BudgetPlanner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetItemController : ControllerBase
    {
        private readonly IBudgetItemRepository _budgetItemRepository;
        public BudgetItemController(IBudgetItemRepository budgetItemRepository) {
            _budgetItemRepository = budgetItemRepository;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult DeleteBudgetItem(int id)
        {
            _budgetItemRepository.DeleteBudgetItemById(id);

            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult AddNewBudgetItem(BudgetItemDTO budgetItemDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _budgetItemRepository.AddNewBudgetItem(budgetItemDTO);

            return Ok();
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult UpdateExistingBudgetItemCost([FromBody] BudgetItemDTO budgetItemDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var budgetItemDTOResponse = _budgetItemRepository.UpdateBudgetItemCost(budgetItemDTO);

            if(!budgetItemDTOResponse)
            {
                ModelState.AddModelError("Error", "There was an issue updating the cost");
                return BadRequest(ModelState);
            }

            return Ok();
        }
    }
}
