using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Models
{
    public class Expense
    {
        [Key]
        public int ExpenseId { get; set; }

        [ForeignKey("User")]
        public int UserRefId { get; set; }
        public User User { get; set; }

        public Int64 ExpenseAmt { get; set; }

        public string Categories { get; set; }
        public string Particulars { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
