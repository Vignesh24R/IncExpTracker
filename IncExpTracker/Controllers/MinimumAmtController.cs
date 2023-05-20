using Business_Logic_Layer.Interfaces;
using Data_Access_Layer.DTO;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models;
using Data_Access_Layer.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IncExpTracker_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MinimumAmtController : ControllerBase
    {
        private readonly IMinimumAmtBLL _minimumAmtBLL;
        //private readonly AppDbContext _context;

        public MinimumAmtController(IMinimumAmtBLL minimumAmtBLL)
        {
            _minimumAmtBLL = minimumAmtBLL;
        }

        [HttpGet("{userRefId}")]
        public async Task<ActionResult<MinimumAmtDTO>> GetMinimumAmtByUserRefId(int userRefId)
        {
            try
            {
                var minimumAmt = await _minimumAmtBLL.GetMinimumAmtByUserRefId(userRefId);

                if (minimumAmt == null)
                {
                    return NotFound();
                }

                var minimumAmtDto = new MinimumAmtDTO
                {
                    MinAmtId = minimumAmt.MinAmtId,
                    UserRefId = minimumAmt.UserRefId,
                    MinAmt = minimumAmt.MinAmt,
                    UpdatedTime = minimumAmt.UpdatedTime
                };

                return Ok(minimumAmtDto);
            }
            catch (Exception ex)
            {
                // Handle exception appropriately
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<MinimumAmtDTO>> CreateMinimumAmt(CreateMinimumAmtDTO createMinimumAmtDto)
        {
            try
            {
                var minimumAmt = new MinimumAmt
                {
                    UserRefId = createMinimumAmtDto.UserRefId,
                    MinAmt = createMinimumAmtDto.MinAmt,
                    UpdatedTime = DateTime.Now
                };

                await _minimumAmtBLL.CreateMinimumAmt(minimumAmt);

                var minimumAmtDto = new MinimumAmtDTO
                {
                    MinAmtId = minimumAmt.MinAmtId,
                    UserRefId = minimumAmt.UserRefId,
                    MinAmt = minimumAmt.MinAmt,
                    UpdatedTime = minimumAmt.UpdatedTime
                };

                return CreatedAtAction(nameof(GetMinimumAmtByUserRefId), new { userRefId = minimumAmt.UserRefId }, minimumAmtDto);
            }
            catch (Exception ex)
            {
                // Handle exception appropriately
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpPut("{userRefId}")]
        public async Task<ActionResult<MinimumAmtDTO>> UpdateMinimumAmt(int userRefId, UpdateMinimumAmtDTO updateMinimumAmtDto)
        {
            try
            {
                var existingMinimumAmt = await _minimumAmtBLL.GetMinimumAmtByUserRefId(userRefId);

                if (existingMinimumAmt == null)
                {
                    return NotFound();
                }

                existingMinimumAmt.MinAmt = updateMinimumAmtDto.MinAmt;
                existingMinimumAmt.UpdatedTime = DateTime.Now;

                await _minimumAmtBLL.UpdateMinimumAmt(existingMinimumAmt);

                var minimumAmtDto = new MinimumAmtDTO
                {
                    MinAmtId = existingMinimumAmt.MinAmtId,
                    UserRefId = existingMinimumAmt.UserRefId,
                    MinAmt = existingMinimumAmt.MinAmt,
                    UpdatedTime = existingMinimumAmt.UpdatedTime
                };

                return Ok(minimumAmtDto);
            }
            catch (Exception ex)
            {
                // Handle exception appropriately
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{userRefId}")]
        public async Task<IActionResult> DeleteMinimumAmt(int userRefId)
        {
            try
            {
                var existingMinimumAmt = await _minimumAmtBLL.GetMinimumAmtByUserRefId(userRefId);
                if (existingMinimumAmt == null)
                {
                    return NotFound();
                }

                await _minimumAmtBLL.DeleteMinimumAmt(existingMinimumAmt.UserRefId);

                return NoContent();
            }
            catch (Exception ex)
            {
                // Handle exception appropriately
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
