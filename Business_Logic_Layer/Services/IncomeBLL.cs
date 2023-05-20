using Business_Logic_Layer.Interfaces;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services
{
    public class IncomeBLL : IIncomeBLL
    {
        private readonly IIncomeRepository _incomeRepo;

        public IncomeBLL (IIncomeRepository incomeRepo)
        {
            _incomeRepo = incomeRepo;
        }   

        public Task CreateIncome(IncomeDTO incomeDTO)
        {
            var res = _incomeRepo.CreateIncome(incomeDTO);
            return res;
        }
        public Task<List<IncomeDTO>> GetIncomeByUserRefId(int userRefId)
        {
            var res = _incomeRepo.GetIncomeByUserRefId(userRefId);
            return res;
        }
        public Task UpdateIncome(int incomeId, int userRefId, IncomeDTO incomeDTO)
        {
            var res = _incomeRepo.UpdateIncome(incomeId, userRefId, incomeDTO);
            return res;
        }
        public Task DeleteIncome(int incomeId, int userRefId)
        {
            var res = DeleteIncome(incomeId, userRefId);
            return res;

        }

    }
}
