using System;
using System.ComponentModel.DataAnnotations;
using POS.Client.Interfaces;

namespace POS.Client.Models
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
        [Display(GroupName = "<1>", Name = "UOM Code")]
        public string UOMCode { get; set; }
        [Display(GroupName = "<1>", Name = "UOM Description")]
        public string UOMDescription { get; set; }

    }
}
