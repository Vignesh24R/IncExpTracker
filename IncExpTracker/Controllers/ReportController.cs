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

        [HttpGet("{userRefId}")]
        public async Task<ActionResult<List<IncomeReportDTO>>> GetIncomeByUserRefId(int userRefId)
        {
            try
            {
                var income = await _reportBLL.GetIncomeByUserRefId(userRefId);
                return Ok(income);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it according to your application's requirements
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while retrieving income records. {ex}");
            }

        }

        [HttpGet]
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

    }
}
