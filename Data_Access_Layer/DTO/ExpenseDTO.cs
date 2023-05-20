using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Models.DTO
{
    public class ExpenseDTO
    {
        public int ExpenseId { get; set; }
        public int UserRefId { get; set; }
        public Int64 ExpenseAmt { get; set; }
        public string Categories { get; set; }
        public string Particulars { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
