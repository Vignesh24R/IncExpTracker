using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Models.DTO
{
    public class MinimumAmtDTO
    {
        public int MinAmtId { get; set; }
        public int UserRefId { get; set; }
        public long MinAmt { get; set; }
        public DateTime UpdatedTime { get; set; }
    }
}
