using Data_Access_Layer.Models.DTO;
using Data_Access_Layer.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IncExpTracker_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
       
        private readonly IExpenseRepository _expenseRepository;
        public ExpenseController(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        [HttpPost]
        public ActionResult<ExpenseDTO> CreateExpense(ExpenseDTO expenseDto)
        {
            try
            {
                var createdExpense = _expenseRepository.CreateExpense(expenseDto);
                return Ok(createdExpense);
            }
            catch (Exception ex)
            {
                // Handle exception here
                return StatusCode(500, "An error occurred while creating the expense.");
            }
        }

        [HttpGet("user/{userRefId}")]
        public ActionResult<ExpenseDTO> GetExpenseByUserRefId(int userRefId)
        {
            try
            {
                var expense = _expenseRepository.GetExpenseByUserRefId(userRefId);
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

        [HttpPut("{expenseId}/user/{userRefId}")]
        public ActionResult<ExpenseDTO> UpdateExpense(int expenseId, int userRefId, ExpenseDTO expenseDto)
        {
            try
            {
                var updatedExpense = _expenseRepository.UpdateExpense(expenseId, userRefId, expenseDto);
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

        [HttpDelete("{expenseId}/user/{userRefId}")]
        public ActionResult DeleteExpense(int expenseId, int userRefId)
        {
            try
            {
                var deleted = _expenseRepository.DeleteExpense(userRefId, expenseId);
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
