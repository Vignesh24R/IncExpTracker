using Business_Logic_Layer.Interfaces;
using Data_Access_Layer.DTO;
using Data_Access_Layer.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IncExpTracker_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportBLL _reportBLL;

        public ReportController(IReportBLL reportBLL)
        {
            _reportBLL = reportBLL;
        }

        [HttpGet("Income/{userRefId}")]
        public async Task<ActionResult<List<IncomeReportDTO>>> GetIncomeByUserRefId(int userRefId)
        {
            try
            {
                var income = await _reportBLL.GetIncomeByUserRefId(userRefId);
                return Ok(income);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while retrieving income records. {ex}");
            }

        }

        [HttpGet("Income")]
        public async Task<ActionResult<List<IncomeDTO>>> GetIncomeByDateRange(int userRefId,DateTime fromDate, DateTime toDate)
        {
            try
            {
                var income = await _reportBLL.GetIncomeByDateRange(userRefId,fromDate, toDate);
                return Ok(income);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving income records.");
            }
        }


        [HttpGet("Expense/{userRefId}")]
        public async Task<ActionResult<List<ExpenseDTO>>> GetExpensesByUserRefId(int userRefId)
        {
            try
            {
                var expenses = await _reportBLL.GetExpensesByUserRefId(userRefId);
                return Ok(expenses);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving income records.");
            }

        }

        [HttpGet("Expense/dateRange")]
        public async Task<ActionResult<List<ExpenseDTO>>> GetExpensesByDateRange(int userRefId, DateTime fromDate, DateTime toDate)
        {
            try
            {
                var expenses = await _reportBLL.GetExpensesByDateRange(userRefId,fromDate, toDate);
                return Ok(expenses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving expenses by date range.");
            }
        }

        [HttpGet("Expense/report")]
        public async Task<ActionResult<List<ExpenseReportDTO>>> GetExpenseReportByCategory()
        {
            try
            {
                var expenseReport = await _reportBLL.GetExpenseReportByCategory();
                return Ok(expenseReport);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving expense report by category.");
            }
        }


    }
}
