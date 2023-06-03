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
    public class ReportRepository : IReportRepository
    {
        private readonly AppDbContext _dbContext;

        private readonly ILogger<ReportRepository> _logger;
        public ReportRepository(AppDbContext dbContext, ILogger<ReportRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<List<IncomeReportDTO>> GetIncomeByUserRefId(int userRefId)
        {
            try
            {
                _logger.LogInformation("Initiated GetIncomeByUserRefId");
                return await _dbContext.Incomes
                    .Where(i => i.UserRefId == userRefId)
                    .Select(i => new IncomeReportDTO
                    {
                        Source = i.Source,
                        IncomeAmt = i.IncomeAmt,
                        UpdatedDate = i.UpdatedDate
                    })
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Occured in GetIncomeByUserRefId");
                throw;
            }
        }

           //  decimal totalIncomeAmt = await _dbContext.Incomes
           //.Where(i => i.UserRefId == userRefId && i.UpdatedDate >= fromDate && i.UpdatedDate <= toDate)
           //.SumAsync(i => i.IncomeAmt);

        public async Task<List<IncomeReportDTO>> GetIncomeByDateRange(int userRefId, DateTime fromDate, DateTime toDate)
        {
            try
            {
                _logger.LogInformation("Initiated GetIncomeByDateRange");
                return await _dbContext.Incomes
                    .Where(i => i.UserRefId == userRefId && i.UpdatedDate >= fromDate && i.UpdatedDate <= toDate)
                    .Select(i => new IncomeReportDTO
                    {
                        Source = i.Source,
                        IncomeAmt = i.IncomeAmt,
                        UpdatedDate = i.UpdatedDate
                    })
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Occured in GetIncomeByDateRange");
                throw;
            }
        }

        public async Task<List<ExpenseReportDTO>> GetExpensesByUserRefId(int userRefId)
        {
            try
            {
                _logger.LogInformation("Initiated GetExpensesByUserRefId");
                return await _dbContext.Expenses
                    .Where(e => e.UserRefId == userRefId)
                    .Select(e => new ExpenseReportDTO
                    {
                        Source = e.Categories,
                        ExpenseAmt = e.ExpenseAmt,
                        UpdatedDate = e.UpdatedDate
                    })
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Occured in GetExpensesByUserRefId");
                throw;
            }
        }

        public async Task<List<ExpenseReportDTO>> GetExpensesByDateRange(int userRefId, DateTime fromDate, DateTime toDate)
        {
            try
            {
                _logger.LogInformation("Initiated GetExpensesByDateRange");
                var expenses = await _dbContext.Expenses
                    .Where(e => e.UserRefId == userRefId && e.UpdatedDate >= fromDate && e.UpdatedDate <= toDate)
                    .Select(e => new ExpenseReportDTO
                    {
                        Source = e.Categories,
                        ExpenseAmt = e.ExpenseAmt,
                        UpdatedDate = e.UpdatedDate
                    })
                    .ToListAsync();

                return expenses;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Occured in GetExpensesByDateRange");
                throw new ApplicationException("Failed to retrieve expenses for the specified user and date range.", ex);
            }
        }

        public async Task<List<ExpReportCategoryDTO>> GetExpenseReportByCategory(int userRefId)
        {
            try
            {
                _logger.LogInformation("Initiated GetExpenseReportByCategory");
                return await _dbContext.Expenses
                    .Where(e => e.UserRefId == userRefId)
                    .GroupBy(e => e.Categories)
                    .Select(g => new ExpReportCategoryDTO
                    {
                        Category = g.Key,
                        TotalExpenseAmt = g.Sum(e => e.ExpenseAmt)
                    })
                    .ToListAsync();
            }
            catch (Exception ex) 
            {
                _logger.LogError("Error Occured in GetExpenseReportByCategory");
                throw;
            }
        }


    }
}
