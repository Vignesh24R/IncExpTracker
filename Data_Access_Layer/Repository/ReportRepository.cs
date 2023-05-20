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
    public class ReportRepository : IReportRepository
    {
        private readonly AppDbContext _dbContext;

        public ReportRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<IncomeReportDTO>> GetIncomeByUserRefId(int userRefId)
        {
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

        public async Task<List<IncomeReportDTO>> GetIncomeByDateRange(int userRefId, DateTime fromDate, DateTime toDate)
        {
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




    }
}
