using Data_Access_Layer.Models.DTO;
using Data_Access_Layer.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IncExpTracker_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeController : ControllerBase
    {
        private readonly IIncomeRepository _incomeRepository;

        public IncomeController(IIncomeRepository incomeRepository)
        {
            _incomeRepository = incomeRepository;
        }

        // POST: api/Income
        [HttpPost]
        public async Task<IActionResult> CreateIncome([FromBody] IncomeDTO incomeDTO)
        {
            try
            {
                await _incomeRepository.CreateIncome(incomeDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while creating the income: {ex.Message}");
            }
        }

        // GET: api/Income/{userRefId}
        /* [HttpGet("{userRefId}")]
         public async Task<IActionResult> GetIncomeByUserRefId(int userRefId)
         {
             try
             {
                 var incomeDTO = await _incomeRepository.GetIncomeByUserRefId(userRefId);

                 if (incomeDTO == null)
                     return NotFound();

                 return Ok(incomeDTO);
             }
             catch (Exception ex)
             {
                 return StatusCode(500, $"An error occurred while retrieving the income: {ex.Message}");
             }
         }
        */

        [HttpGet("{userRefId}")]
        public async Task<IActionResult> GetIncomeByUserRefId(int userRefId)
        {
            try
            {
                var incomeDTOs = await _incomeRepository.GetIncomeByUserRefId(userRefId);

                if (incomeDTOs == null || incomeDTOs.Count == 0)
                    return NotFound();

                return Ok(incomeDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving the income: {ex.Message}");
            }
        }

        // PUT: api/Income/{incomeId}/{userRefId}
        [HttpPut("{incomeId}/{userRefId}")]
        public async Task<IActionResult> UpdateIncome(int incomeId, int userRefId, [FromBody] IncomeDTO incomeDTO)
        {
            try
            {
                await _incomeRepository.UpdateIncome(incomeId, userRefId, incomeDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the income: {ex.Message}");
            }
        }

        // DELETE: api/Income/{incomeId}/{userRefId}
        [HttpDelete("{incomeId}/{userRefId}")]
        public async Task<IActionResult> DeleteIncome(int incomeId, int userRefId)
        {
            try
            {
                await _incomeRepository.DeleteIncome(incomeId, userRefId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting the income: {ex.Message}");
            }
        }
    }
}
