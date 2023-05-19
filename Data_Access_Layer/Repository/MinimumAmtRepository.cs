using Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Data_Access_Layer.Models.DTO;

namespace Data_Access_Layer.Repository
{
    public class MinimumAmtRepository : IMinimumAmtRepository
    {
        private readonly AppDbContext _context;

        public MinimumAmtRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<MinimumAmtDTO> GetMinimumAmtByUserRefId(int userRefId)
        {
            // Retrieve the MinimumAmt entity by userRefId
            var minimumAmt = await _context.MinimumAmts
                .FirstOrDefaultAsync(m => m.UserRefId == userRefId);

            // Map the MinimumAmt entity to MinimumAmtDTO
            var minimumAmtDto = MapToMinimumAmtDTO(minimumAmt);

            return minimumAmtDto;
        }

        public async Task CreateMinimumAmt(MinimumAmtDTO minimumAmtDto)
        {
            // Map MinimumAmtDTO to MinimumAmt entity
            var minimumAmt = MapToMinimumAmt(minimumAmtDto);

            // Set the creation timestamp
            minimumAmt.UpdatedTime = DateTime.Now;

            // Add the MinimumAmt entity to the context
            _context.MinimumAmts.Add(minimumAmt);

            // Save the changes to the database
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMinimumAmt(MinimumAmtDTO minimumAmtDto)
        {
            // Retrieve the MinimumAmt entity by userRefId
            var minimumAmt = await _context.MinimumAmts
                .FirstOrDefaultAsync(m => m.UserRefId == minimumAmtDto.UserRefId);

            if (minimumAmt == null)
            {
                throw new Exception("MinimumAmt not found.");
            }

            // Update the MinimumAmt entity properties
            minimumAmt.MinAmt = minimumAmtDto.MinAmt;
            minimumAmt.UpdatedTime = DateTime.Now;

            // Save the changes to the database
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMinimumAmt(int userRefId)
        {
            // Retrieve the MinimumAmt entity by userRefId
            var minimumAmt = await _context.MinimumAmts
                .FirstOrDefaultAsync(m => m.UserRefId == userRefId);

            if (minimumAmt == null)
            {
                throw new Exception("MinimumAmt not found.");
            }

            // Remove the MinimumAmt entity from the context
            _context.MinimumAmts.Remove(minimumAmt);

            // Save the changes to the database
            await _context.SaveChangesAsync();
        }

        private MinimumAmtDTO MapToMinimumAmtDTO(MinimumAmt minimumAmt)
        {
            // Map MinimumAmt entity to MinimumAmtDTO
            var minimumAmtDto = new MinimumAmtDTO
            {
                MinAmtId = minimumAmt.MinAmtId,
                UserRefId = minimumAmt.UserRefId,
                MinAmt = minimumAmt.MinAmt,
                UpdatedTime = minimumAmt.UpdatedTime
            };

            return minimumAmtDto;
        }

        private MinimumAmt MapToMinimumAmt(MinimumAmtDTO minimumAmtDto)
        {
            // Map MinimumAmtDTO to MinimumAmt entity
            var minimumAmt = new MinimumAmt
            {
                MinAmtId = minimumAmtDto.MinAmtId,
                UserRefId = minimumAmtDto.UserRefId,
                MinAmt = minimumAmtDto.MinAmt,
                UpdatedTime = minimumAmtDto.UpdatedTime
            };

            return minimumAmt;
        }

        public async Task CreateMinimumAmt(MinimumAmt minimumAmt)
        {
            _context.MinimumAmts.Add(minimumAmt);
            await _context.SaveChangesAsync();
        }
    }

}
