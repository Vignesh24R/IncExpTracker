using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Models.DTO
{
    public class IncomeDTO
    {
        public int UserRefId { get; set; }
        public int IncomeId { get; set; }
        public Int64 IncomeAmt { get; set; }
        public string Source { get; set; }
        public DateTime UpdatedDate { get; set; }


    }
}
