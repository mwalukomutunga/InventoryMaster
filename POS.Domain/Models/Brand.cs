using POS.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POS.Domain.Models
{
   public class Brand: Base
    {
        public Brand()
        {
            CreatedAt = IDateTime.Now();
            UpdatedAt = IDateTime.Now();
            Terminus = Environment.MachineName;
            //  CreatedBy = null;
            // UpdatedBy = null;
        }

        [Key]
        public Guid BrandId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
