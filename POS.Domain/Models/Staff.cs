using POS.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POS.Domain.Models
{
   public class Staff : Base
    {
        public Staff()
        {
            CreatedAt = IDateTime.Now();
            UpdatedAt = IDateTime.Now();
            Terminus = Environment.MachineName;
            IsActive = true;
            //  CreatedBy = null;
            // UpdatedBy = null;
        }
        [Display(AutoGenerateField = false)]
        [Key]
        public Guid StaffId { get; set; }
        public string Name { get; set; }
        public Guid CostCenterId { get; set; }
        [Display(AutoGenerateField = false)]
        public SalesOutlet CostCenter { get; set; }
        public long UserName { get; set; }

        public string Password { get; set; }
        public bool IsActive { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
