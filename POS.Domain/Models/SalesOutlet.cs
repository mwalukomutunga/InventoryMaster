using POS.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POS.Domain.Models
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
        [Key]
        public Guid SalesOutletId { get; set; }
        public string Name { get; set; }
        public string PhysicalAddress { get; set; }
        public string Telephone { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
        public string Email { get; set; }
    }
}
