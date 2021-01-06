using POS.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POS.Domain.Models
{
   public class Item: Base
    {
        public Item()
        {
            CreatedAt = IDateTime.Now();
            UpdatedAt = IDateTime.Now();
            Terminus = Environment.MachineName;
            VAT = 16;
            ReorderLevel = 5;
            IsActive = true;
            //  CreatedBy = null;
            // UpdatedBy = null;
        }
        [Display(AutoGenerateField = false)]
        [Key]
        public Guid ItemId { get; set; }
        public string BarCode { get; set; }
        public Guid CategoryId { get; set; }
        public ItemCategory Category { get; set; }
        public string Name { get; set; }
        public Guid UOMCodeId { get; set; }
        
        public UnitOfMeasurement UOMCode { get; set; }
        public Guid BrandId { get; set; }
        public Brand Brand { get; set; }
        public float CostPrice { get; set; }
        public float RetailPrice { get; set; }

        public float Discount { get; set; }
        public int VAT { get; set; }

        public int ReorderLevel { get; set; }
        public bool IsActive { get; set; }
        public string OtherDetails { get; set; }

    }
}
