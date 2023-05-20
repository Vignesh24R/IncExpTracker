using Data_Access_Layer.DTO;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models;
using Data_Access_Layer.Models.DTO;
using Microsoft.EntityFrameworkCore;
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

        public IncomeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateIncome(IncomeDTO incomeDTO)
        {
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

        public async Task<List<IncomeDTO>> GetIncomeByUserRefId(int userRefId)
        {
            // Retrieve the income records for the specified user
            var incomes = await _context.Incomes
                .Where(i => i.UserRefId == userRefId)
                .ToListAsync();

            // Map the Income entities to IncomeDTOs
            var incomeDTOs = incomes.Select(i => new IncomeDTO
            {
                UserRefId = i.UserRefId,
                IncomeAmt = i.IncomeAmt,
                Source = i.Source,
            }).ToList();

            return incomeDTOs;
        }

        public async Task UpdateIncome(int incomeId, int userRefId, IncomeDTO incomeDTO)
        {
            var income = await _context.Incomes.FirstOrDefaultAsync(i => i.IncomeId == incomeId && i.UserRefId == userRefId);

            if (income == null)
                throw new Exception("Income not found.");

            income.IncomeAmt = incomeDTO.IncomeAmt;
            income.Source = incomeDTO.Source;
            income.UpdatedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteIncome(int incomeId, int userRefId)
        {
            var income = await _context.Incomes.FirstOrDefaultAsync(i => i.IncomeId == incomeId && i.UserRefId == userRefId);

            if (income == null)
                throw new Exception("Income not found.");

            _context.Incomes.Remove(income);
            await _context.SaveChangesAsync();
        }
    }
}
