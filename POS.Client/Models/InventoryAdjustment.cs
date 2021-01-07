using DevExpress.Mvvm.DataAnnotations;
using System;
using POS.Client.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace POS.Client.Models
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
        [Display(AutoGenerateField = false)]
        [Key]
        public Guid ID { get; set; }
        [Display(GroupName = "<1>", Name = "Item")]
        [LayoutControlEditor(TemplateKey = "ItemlookUp")]
        public Guid ItemId { get; set; }
        [Display(AutoGenerateField = false)]
        public Item Item { get; set; }
        [Display(GroupName = "<1>", Order=0, Name = "Cost Center")]
        [LayoutControlEditor(TemplateKey = "CostCenterlookUp")]
        public Guid CostCenterId { get; set; }
        [Display(AutoGenerateField = false)]
        public SalesOutlet CostCenter { get; set; }
        [Display(GroupName = "<2>", Name = "Quantity")]
        public int AdjQty { get; set; }
        [Display(AutoGenerateField = false)]
        public DateTime AdjustmentDate { get; set; }
    }
}
