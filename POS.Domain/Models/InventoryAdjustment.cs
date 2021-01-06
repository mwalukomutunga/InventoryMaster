using POS.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POS.Domain.Models
{
    public class InventoryAdjustment:Base
    {
        public InventoryAdjustment()
        {
            
            CreatedAt = IDateTime.Now();
            UpdatedAt = IDateTime.Now();
            AdjustmentDate = IDateTime.Now();
            Terminus = Environment.MachineName;
        }
        [Key]
        public Guid ID { get; set; }
        public Guid ItemId { get; set; }
        public Item Item { get; set; }
        public Guid CostCenterId { get; set; }
        public SalesOutlet CostCenter { get; set; }
        public int AdjQty { get; set; }
        public DateTime AdjustmentDate { get; set; }
    }
}
