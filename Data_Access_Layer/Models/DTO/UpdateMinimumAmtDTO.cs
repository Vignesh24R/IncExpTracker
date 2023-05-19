using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Models.DTO
{
    public class UpdateMinimumAmtDTO
    {
        public int UserRefId { get; set; }
        public long MinAmt { get; set; }
    }
}
