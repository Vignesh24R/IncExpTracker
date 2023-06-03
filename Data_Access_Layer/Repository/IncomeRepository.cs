using Data_Access_Layer.DTO;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models;
using Data_Access_Layer.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository
{
    public class IncomeRepository : IIncomeRepository
    {
        private readonly AppDbContext _context;

        private readonly ILogger<IncomeRepository> _logger;
        public IncomeRepository(AppDbContext context, ILogger<IncomeRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task CreateIncome(IncomeDTO incomeDTO)
        {
            try
            {
                _logger.LogInformation("Initiated CreateIncome");
                var income = new Income
                {
                    UserRefId = incomeDTO.UserRefId,
                    IncomeAmt = incomeDTO.IncomeAmt,
                    Source = incomeDTO.Source,
                    UpdatedDate = DateTime.UtcNow
                };

                _context.Incomes.Add(income);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as per your application's requirements
                _logger.LogError("Error Occured in CreateIncome");
                throw;
            }
        }

        public async Task<List<IncomeDTO>> GetIncomeByUserRefId(int userRefId)
        {
            try
            {
                _logger.LogInformation("Initiated GetIncomeByUserRefId");
                var incomes = await _context.Incomes
                    .Where(i => i.UserRefId == userRefId)
                    .ToListAsync();

                var incomeDTOs = incomes.Select(i => new IncomeDTO
                {
                    UserRefId = i.UserRefId,
                    IncomeAmt = i.IncomeAmt,
                    Source = i.Source,
                }).ToList();

                return incomeDTOs;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it 
                _logger.LogError("Error Occured in GetIncomeByUserRefId");
                throw;
            }
        }

        /*public async Task<IncomeDTO> GetIncomeByUserRefId(int userRefId)
        {
            var income = await _context.Incomes.FirstOrDefaultAsync(i => i.UserRefId == userRefId);

            if (income == null)
                return null;

            var incomeDTO = new IncomeDTO
            {
                UserRefId = income.UserRefId,
                IncomeAmt = income.IncomeAmt,
                Source = income.Source
            };

            return incomeDTO;
        }
        */

        public async Task UpdateIncome(int incomeId, int userRefId, IncomeDTO incomeDTO)
        {
            try
            {
                _logger.LogInformation("Initiated UpdateIncome");
                var income = await _context.Incomes.FirstOrDefaultAsync(i => i.IncomeId == incomeId && i.UserRefId == userRefId);

                if (income == null)
                {
                    _logger.LogInformation("income not found");
                    throw new Exception("Income not found.");
                }
                income.IncomeAmt = incomeDTO.IncomeAmt;
                income.Source = incomeDTO.Source;
                income.UpdatedDate = DateTime.UtcNow;

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it 
                _logger.LogError("Error Occured in UpdateIncome");
                throw;
            }
        }

        public async Task DeleteIncome(int incomeId, int userRefId)
        {
            try
            {
                _logger.LogInformation("Initiated DeleteIncome");
                var income = await _context.Incomes.FirstOrDefaultAsync(i => i.IncomeId == incomeId && i.UserRefId == userRefId);

                if (income == null)
                    throw new Exception("Income not found.");

                _context.Incomes.Remove(income);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it
                _logger.LogError("Error Occured in DeleteIncome");
                throw;
            }
        }
    }
}
