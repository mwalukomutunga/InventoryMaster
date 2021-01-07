using DevExpress.Mvvm.DataAnnotations;
using System;
using POS.Client.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace POS.Client.Models
{
    public class SalesOutlet:Base
    {
        public SalesOutlet()
        {
            CreatedAt = IDateTime.Now();
            UpdatedAt = IDateTime.Now();
            Terminus = Environment.MachineName;
            //  CreatedBy = null;
            // UpdatedBy = null;
        }
        [Display(AutoGenerateField = false)]
        [Key]
        public Guid SalesOutletId { get; set; }
        [Display(GroupName = "<1>", Name = "Name")]
        public string Name { get; set; }
        [Display(GroupName = "<1>", Name = "Address")]
        public string PhysicalAddress { get; set; }
        [Display(GroupName = "<2>", Name = "Telephone")]
        public string Telephone { get; set; }
        [Display(GroupName = "<2>", Name = "Company")]
        [LayoutControlEditor(TemplateKey = "CompanylookUp")]
        public Guid CompanyId { get; set; }
        [Display(AutoGenerateField = false)]
        public Company Company { get; set; }
        [Display(GroupName = "<3>", Name = "Email")]
        public string Email { get; set; }
    }
}
