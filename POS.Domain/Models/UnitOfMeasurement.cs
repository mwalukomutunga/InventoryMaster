using POS.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POS.Domain.Models
{
   public class UnitOfMeasurement : Base
    {
        public UnitOfMeasurement()
        {
            ID = Guid.NewGuid();
            CreatedAt = IDateTime.Now();
            UpdatedAt = IDateTime.Now();
            Terminus = Environment.MachineName;
            //  CreatedBy = null;
            // UpdatedBy = null;
        }
        [Display(AutoGenerateField = false)]
        [Key]
        public Guid ID { get; set; }
        public string UOMCode { get; set; }
        public string UOMDescription { get; set; }

    }
}
