using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.DTO
{
    public class IncomeReportDTO
    {
        public string Source { get; set; }
        public Int64 IncomeAmt { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
