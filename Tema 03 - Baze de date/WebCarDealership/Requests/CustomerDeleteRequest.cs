using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Models
{
    public class CustomerDeleteRequestModel
    {
        [Required]
        public int Id { get; set; }
  
    }
}
