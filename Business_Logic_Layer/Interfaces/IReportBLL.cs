using Data_Access_Layer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Interfaces
{
    public interface IReportBLL
    {
        Task<List<IncomeReportDTO>> GetIncomeByUserRefId(int userRefId);
        Task<List<IncomeReportDTO>> GetIncomeByDateRange(int userRefId, DateTime fromDate, DateTime toDate);
    }
}
