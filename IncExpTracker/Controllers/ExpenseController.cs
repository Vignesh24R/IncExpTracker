using Business_Logic_Layer.Interfaces;
using Data_Access_Layer.DTO;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IncExpTracker_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
       
        private readonly IExpenseBLL _expenseBLL;
        public ExpenseController(IExpenseBLL expenseBLL)
        {
            _expenseBLL = expenseBLL;
        }

        [HttpPost]
        public ActionResult<ExpenseDTO> CreateExpense(ExpenseDTO expenseDto)
        {
            try
            {
                var createdExpense = _expenseBLL.CreateExpense(expenseDto);
                return Ok(createdExpense);
            }
            catch (Exception ex)
            {
                // Handle exception here
                return StatusCode(500, "An error occurred while creating the expense.");
            }
        }

        //[Authorize]
        [HttpGet("{userRefId}")]
        public ActionResult<ExpenseDTO> GetExpenseByUserRefId(int userRefId)
        {
            try
            {
                var expense = _expenseBLL.GetExpenseByUserRefId(userRefId);
                if (expense == null)
                    return NotFound();

                return Ok(expense);
            }
            catch (Exception ex)
            {
                // Handle exception here
                return StatusCode(500, "An error occurred while retrieving the expense.");
            }
        }

        [HttpPut("{expenseId}/{userRefId}")]
        public ActionResult<ExpenseDTO> UpdateExpense(int expenseId, int userRefId, ExpenseDTO expenseDto)
        {
            try
            {
                var updatedExpense = _expenseBLL.UpdateExpense(expenseId, userRefId, expenseDto);
                if (!updatedExpense)
                    return NotFound();

                return Ok(expenseDto);
            }
            catch (Exception ex)
            {
                // Handle exception here
                return StatusCode(500, "An error occurred while updating the expense.");
            }
        }

        [HttpDelete("{expenseId}/{userRefId}")]
        public ActionResult DeleteExpense(int expenseId, int userRefId)
        {
            try
            {
                var deleted = _expenseBLL.DeleteExpense(userRefId, expenseId);
                if (!deleted)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                // Handle exception here
                return StatusCode(500, "An error occurred while deleting the expense.");
            }
        }
    }
}
