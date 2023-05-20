using Data_Access_Layer.DTO;
using Data_Access_Layer.Models;
using Data_Access_Layer.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Interfaces
{
    public interface IMinimumAmtRepository
    {
        Task<MinimumAmtDTO> GetMinimumAmtByUserRefId(int userRefId);
        Task CreateMinimumAmt(MinimumAmtDTO minimumAmtDto);
        Task UpdateMinimumAmt(MinimumAmtDTO minimumAmtDto);
        Task DeleteMinimumAmt(int userRefId);
        Task CreateMinimumAmt(MinimumAmt minimumAmt);
    }
}
