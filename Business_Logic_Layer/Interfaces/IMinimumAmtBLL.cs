using Data_Access_Layer.Models.DTO;
using Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Interfaces
{
    public interface IMinimumAmtBLL
    {
        Task<MinimumAmtDTO> GetMinimumAmtByUserRefId(int userRefId);
        Task CreateMinimumAmt(MinimumAmtDTO minimumAmtDto);
        Task UpdateMinimumAmt(MinimumAmtDTO minimumAmtDto);
        Task DeleteMinimumAmt(int userRefId);
        Task CreateMinimumAmt(MinimumAmt minimumAmt);
    }
}
