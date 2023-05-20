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
            var res = _minAmtRepo.GetMinimumAmtByUserRefId(userRefId); 
            return res;
        }
        public Task CreateMinimumAmt(MinimumAmtDTO minimumAmtDto)
        {
            var res = _minAmtRepo.CreateMinimumAmt(minimumAmtDto);
            return res;
        }
        public Task UpdateMinimumAmt(MinimumAmtDTO minimumAmtDto)
        {
            var res = _minAmtRepo.UpdateMinimumAmt(minimumAmtDto);
            return res;
        }
        public Task DeleteMinimumAmt(int userRefId)
        {
            var res = _minAmtRepo.DeleteMinimumAmt(userRefId);
            return res;
        }
        public Task CreateMinimumAmt(MinimumAmt minimumAmt)
        {
            var res = _minAmtRepo.CreateMinimumAmt(minimumAmt);
            return res;
        }
    }
}
