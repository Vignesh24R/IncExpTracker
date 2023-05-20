using Data_Access_Layer.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Interfaces
{
    public interface IIncomeBLL
    {
        Task CreateIncome(IncomeDTO incomeDTO);
        Task<List<IncomeDTO>> GetIncomeByUserRefId(int userRefId);
        Task UpdateIncome(int incomeId, int userRefId, IncomeDTO incomeDTO);
        Task DeleteIncome(int incomeId, int userRefId);
    }
}
