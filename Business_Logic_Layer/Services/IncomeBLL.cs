using Business_Logic_Layer.Interfaces;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models.DTO;
using Microsoft.IdentityModel.Tokens;
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
            try
            {
                var res = _incomeRepo.CreateIncome(incomeDTO);
                return res;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as per your application's requirements
                throw new ArgumentException("An error occurred while Creating income"); ;
            }
           
        }
        public Task<List<IncomeDTO>> GetIncomeByUserRefId(int userRefId)
        {
            try
            {
                var res = _incomeRepo.GetIncomeByUserRefId(userRefId);
                return res;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("An error occurred while getting income");
            }

        }
        public Task UpdateIncome(int incomeId, int userRefId, IncomeDTO incomeDTO)
        {
            try
            {
                var res = _incomeRepo.UpdateIncome(incomeId, userRefId, incomeDTO);
                return res;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("An error occurred while Updating income");
            }
        }
        public Task DeleteIncome(int incomeId, int userRefId)
        {
            try
            {
                var res = DeleteIncome(incomeId, userRefId);
                return res;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("An error occurred while Deleting income");
            }
        }

    }
}
