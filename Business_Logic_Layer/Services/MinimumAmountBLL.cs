using Data_Access_Layer.Models.DTO;
using Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer.Interfaces;
using Business_Logic_Layer.Interfaces;
using Microsoft.Extensions.Logging;

namespace Business_Logic_Layer.Services
{
    public class MinimumAmountBLL : IMinimumAmtBLL
    {
        private readonly IMinimumAmtRepository _minAmtRepo;

        private readonly ILogger<MinimumAmountBLL> _logger;
        public MinimumAmountBLL (IMinimumAmtRepository minAmtRepo, ILogger<MinimumAmountBLL> logger)
        {
            _minAmtRepo = minAmtRepo;
            _logger = logger;
        }

        public Task<MinimumAmtDTO> GetMinimumAmtByUserRefId(int userRefId)
        {
            
            try
            {
                _logger.LogInformation("Initiated GetMinimumAmtByUserRefId");
                var res = _minAmtRepo.GetMinimumAmtByUserRefId(userRefId);
                return res;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Occured in GetMinimumAmtByUserRefId");
                throw new ArgumentException("An error occurred while getting Minimum Amount");
            }
        }
        public Task CreateMinimumAmt(MinimumAmtDTO minimumAmtDto)
        {
            
            try
            {
                _logger.LogInformation("Initiated CreateMinimumAmt");
                var res = _minAmtRepo.CreateMinimumAmt(minimumAmtDto);
                return res;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Occured in CreateMinimumAmt");
                throw new ArgumentException("An error occurred while creating Minimum Amount");
            }
        }
        public Task UpdateMinimumAmt(MinimumAmtDTO minimumAmtDto)
        {
            
            try
            {
                _logger.LogInformation("Initiated UpdateMinimumAmt");
                var res = _minAmtRepo.UpdateMinimumAmt(minimumAmtDto);
                return res;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Occured in UpdateMinimumAmt");
                throw new ArgumentException("An error occurred while Updating Minimum Amount");
            }
        }
        public Task DeleteMinimumAmt(int userRefId)
        {
            
            try
            {
                _logger.LogInformation("Initiated DeleteMinimumAmt");
                var res = _minAmtRepo.DeleteMinimumAmt(userRefId);
                return res;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Occured in DeleteMinimumAmt");
                throw new ArgumentException("An error occurred while Deleting Minimum Amount");
            }
        }
        public Task CreateMinimumAmt(MinimumAmt minimumAmt)
        {
            
            try
            {
                _logger.LogInformation("Initiated CreateMinimumAmt");
                var res = _minAmtRepo.CreateMinimumAmt(minimumAmt);
                return res;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Occured in CreateMinimumAmt");
                throw new ArgumentException("An error occurred while creating Minimum Amount");
            }
        }
    }
}
