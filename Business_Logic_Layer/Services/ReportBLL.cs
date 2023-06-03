using Business_Logic_Layer.Interfaces;
using Data_Access_Layer.DTO;
using Data_Access_Layer.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services
{
    public class ReportBLL : IReportBLL
    {
        private readonly IReportRepository _reportRepo;

        private readonly ILogger<ReportBLL> _logger;
        public ReportBLL(IReportRepository reportRepo, ILogger<ReportBLL> logger)
        {
            _reportRepo = reportRepo;
            _logger = logger;
        }

        public Task<List<IncomeReportDTO>> GetIncomeByUserRefId(int userRefId)
        {
            
            try
            {
                _logger.LogInformation("Initiated GetIncomeByUserId");
                var res = _reportRepo.GetIncomeByUserRefId(userRefId);
                return res;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Occured while Getting Income using user details");
                throw new ArgumentException("An error occurred ");
            }
        }
        public Task<List<IncomeReportDTO>> GetIncomeByDateRange(int userRefId, DateTime fromDate, DateTime toDate)
        {
            
            try
            {
                _logger.LogInformation("Initiated GetIncomeByDateRange");
                var res = _reportRepo.GetIncomeByDateRange(userRefId, fromDate, toDate);
                return res;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred in GetIncomeByDateRange");
                throw new ArgumentException("An error occurred ");
            }

        }

        public Task<List<ExpenseReportDTO>> GetExpensesByUserRefId(int userRefId)
        {
            
            try
            {
                _logger.LogInformation("Initiated GetExpensesByUserRefId");
                var res = _reportRepo.GetExpensesByUserRefId(userRefId);
                return res;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred in GetExpensesByUserRefId");
                throw new ArgumentException("An error occurred ");
            }
        }
        public Task<List<ExpenseReportDTO>> GetExpensesByDateRange(int userRefId, DateTime fromDate, DateTime toDate)
        {
            
            try
            {
                _logger.LogInformation("Initiated GetExpensesByDateRange");
                var res = _reportRepo.GetExpensesByDateRange(userRefId, fromDate, toDate);
                return res;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred in GetExpensesByDateRange");
                throw new ArgumentException("An error occurred ");
            }
        }
        public Task<List<ExpReportCategoryDTO>> GetExpenseReportByCategory(int userRefId)
        {
            
            try
            {
                _logger.LogInformation("Initiated GetExpenseReportByCategory");
                var res = _reportRepo.GetExpenseReportByCategory(userRefId);
                return res;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred in GetExpenseReportByCategory");
                throw new ArgumentException("An error occurred ");
            }
        }

    }
}
