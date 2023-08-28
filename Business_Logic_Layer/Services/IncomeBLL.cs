using Business_Logic_Layer.Interfaces;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models.DTO;
using Microsoft.Extensions.Logging;
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

        private readonly ILogger<IncomeBLL> _logger;
        public IncomeBLL (IIncomeRepository incomeRepo, ILogger<IncomeBLL> logger)
        {
            _incomeRepo = incomeRepo;
            _logger = logger;
        }   

        public Task CreateIncome(IncomeDTO incomeDTO)
        {
            try
            {
                _logger.LogInformation("Initiated CreateIncome");
                var res = _incomeRepo.CreateIncome(incomeDTO);
                return res;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it 
                _logger.LogError("Error Occured in CreateIncome");
                throw new ArgumentException("An error occurred while Creating income"); 
            }
           
        }
        public Task<List<IncomeDTO>> GetIncomeByUserRefId(int userRefId)
        {
            try
            {
                _logger.LogInformation("Initiated GetIncomeByUserRefId");
                var res = _incomeRepo.GetIncomeByUserRefId(userRefId);
                return res;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Occured in GetIncomeByUserRefId");
                throw new ArgumentException("An error occurred while getting income");
            }

        }
        public Task UpdateIncome(int incomeId, int userRefId, IncomeDTO incomeDTO)
        {
            try
            {
                _logger.LogInformation("Initiated UpdateIncome");
                var res = _incomeRepo.UpdateIncome(incomeId, userRefId, incomeDTO);
                return res;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Occured in UpdateIncome");
                throw new ArgumentException("An error occurred while Updating income");
            }
        }
        public Task DeleteIncome(int incomeId, int userRefId)
        {
            try
            {
                _logger.LogInformation("Initiated DeleteIncome");
                var res = _incomeRepo.DeleteIncome(incomeId, userRefId);
                return res;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Occured in DeleteIncome");
                throw new ArgumentException("An error occurred while Deleting income");
            }
        }

    }
}
