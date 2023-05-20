using Business_Logic_Layer.Interfaces;
using Data_Access_Layer.DTO;
using Data_Access_Layer.Interfaces;
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

        public ReportBLL(IReportRepository reportRepo)
        {
            _reportRepo = reportRepo;
        }

        public Task<List<IncomeReportDTO>> GetIncomeByUserRefId(int userRefId)
        {
            var res = _reportRepo.GetIncomeByUserRefId(userRefId);
            return res;
        }
        public Task<List<IncomeReportDTO>> GetIncomeByDateRange(int userRefId, DateTime fromDate, DateTime toDate)
        {
            var res = _reportRepo.GetIncomeByDateRange(userRefId, fromDate, toDate);
            return res;
        }

        public Task<List<ExpenseReportDTO>> GetExpensesByUserRefId(int userRefId)
        {
            var res = _reportRepo.GetExpensesByUserRefId(userRefId);
            return res;
        }
        public Task<List<ExpenseReportDTO>> GetExpensesByDateRange(int userRefId, DateTime fromDate, DateTime toDate)
        {
            var res = _reportRepo.GetExpensesByDateRange(userRefId, fromDate, toDate);
            return res;
        }
        public Task<List<ExpReportCategoryDTO>> GetExpenseReportByCategory()
        {
            var res = _reportRepo.GetExpenseReportByCategory();
            return res;
        }

    }
}
