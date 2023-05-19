using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Models
{
    public class Income
    {
        [Key]
        public int IncomeId { get; set; }

        [ForeignKey("User")]
        public int UserRefId { get; set; }
        public User User { get; set; }

        public Int64 IncomeAmt { get; set; }

        public string Source { get; set; }

        public DateTime UpdatedDate { get; set; }


    }
}
