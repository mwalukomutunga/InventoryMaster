using System;
using System.ComponentModel.DataAnnotations;
using POS.Client.Interfaces;

namespace POS.Client.Models
{
    public class ItemCategory : Base
    {
        public ItemCategory()
        {
            CreatedAt = IDateTime.Now();
            UpdatedAt = IDateTime.Now();
            Terminus = Environment.MachineName;
            //  CreatedBy = null;
            // UpdatedBy = null;

        }
        [Display(AutoGenerateField = false)]
        [Key]
        public Guid CategoryId { get; set; }

        [Display(GroupName = "<ItemCategory>", Name = "Name")]
        public string Name { get; set; }
        [Display(GroupName = "<ItemCategory>", Name = "Description")]
        public string Description { get; set; }
    }
}
