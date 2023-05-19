using Data_Access_Layer.Migrations;
using Data_Access_Layer.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository
{
    public interface IIncomeRepository
    {
        Task CreateIncome(IncomeDTO incomeDTO);

        //Task<IncomeDTO> GetIncomeByUserRefId(int userRefId);
        Task<List<IncomeDTO>> GetIncomeByUserRefId(int userRefId);
        Task UpdateIncome(int incomeId, int userRefId, IncomeDTO incomeDTO);
        Task DeleteIncome(int incomeId, int userRefId);
    }
}

