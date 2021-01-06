using POS.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POS.Domain.Models
{
    public class ItemInventory : Base
    {
        private float quantity;

        public ItemInventory()
        {
            CreatedAt = IDateTime.Now();
            UpdatedAt = IDateTime.Now();
            Terminus = Environment.MachineName;
            InventoryDate = IDateTime.Now();
            //  CreatedBy = null;
            // UpdatedBy = null;
        }
        [Display(AutoGenerateField = false)]
        [Key]
        public Guid InventoryId { get; set; }
        public Guid ItemId { get; set; }
        public Item Item { get; set; }
        public DateTime InventoryDate { get; set; }
        public float Quantity { get => quantity; set { quantity = value;} }
        public float QuantityInStock { get; set; } = 0;
        public string Reference { get; set; }
        public Guid CostCenterId { get; set; }
        public SalesOutlet CostCenter { get; set; }
        public string OtherDetails { get; set; }
    }
}
