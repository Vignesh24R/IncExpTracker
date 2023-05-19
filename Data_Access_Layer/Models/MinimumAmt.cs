using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Models
{
    public class MinimumAmt
    {
        [Key]
        public int MinAmtId { get; set; }
        [ForeignKey("User")]
        public int UserRefId { get; set; }
        public User User { get; set; }


        public Int64 MinAmt { get; set; }
        public DateTime UpdatedTime { get; set;}
    }
}
