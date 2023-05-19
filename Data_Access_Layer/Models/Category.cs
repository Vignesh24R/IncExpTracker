using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [ForeignKey("User")] 
        public int UserRefId { get; set; }
        public User User { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
