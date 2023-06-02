using Data_Access_Layer.Models.DTO;
using Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer.Interfaces;
using Business_Logic_Layer.Interfaces;

namespace Business_Logic_Layer.Services
{
    public class MinimumAmountBLL : IMinimumAmtBLL
    {
        private readonly IMinimumAmtRepository _minAmtRepo;

        public MinimumAmountBLL (IMinimumAmtRepository minAmtRepo)
        {
            _minAmtRepo = minAmtRepo;
        }

        public Task<MinimumAmtDTO> GetMinimumAmtByUserRefId(int userRefId)
        {
            
            try
            {
                var res = _minAmtRepo.GetMinimumAmtByUserRefId(userRefId);
                return res;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("An error occurred while getting Minimum Amount");
            }
        }
        public Task CreateMinimumAmt(MinimumAmtDTO minimumAmtDto)
        {
            
            try
            {
                var res = _minAmtRepo.CreateMinimumAmt(minimumAmtDto);
                return res;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("An error occurred while creating Minimum Amount");
            }
        }
        public Task UpdateMinimumAmt(MinimumAmtDTO minimumAmtDto)
        {
            
            try
            {
                var res = _minAmtRepo.UpdateMinimumAmt(minimumAmtDto);
                return res;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("An error occurred while Updating Minimum Amount");
            }
        }
        public Task DeleteMinimumAmt(int userRefId)
        {
            
            try
            {
                var res = _minAmtRepo.DeleteMinimumAmt(userRefId);
                return res;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("An error occurred while Deleting Minimum Amount");
            }
        }
        public Task CreateMinimumAmt(MinimumAmt minimumAmt)
        {
            
            try
            {
                var res = _minAmtRepo.CreateMinimumAmt(minimumAmt);
                return res;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("An error occurred while creating Minimum Amount");
            }
        }
    }
}
