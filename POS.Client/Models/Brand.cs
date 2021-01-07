using POS.Client.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace POS.Client.Models
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

        [Display(AutoGenerateField = false)]
        [Key]
        public Guid BrandId { get; set; }
        [Display(GroupName = "<Brand>", Name = "Name")]
        [Required]
        public string Name { get; set; }
    }
}
