using System;
using System.ComponentModel.DataAnnotations;
using POS.Client.Enums;
using POS.Client.Interfaces;

namespace POS.Client.Models
{
    public class Payment:Base
    {
        public Payment()
        {
            CreatedAt = IDateTime.Now();
            UpdatedAt = IDateTime.Now();
            PaymentDate = IDateTime.Now();
            Terminus = Environment.MachineName;
            //  CreatedBy = null;
            // UpdatedBy = null;
        }
        [Display(AutoGenerateField = false)]
        [Key] 
        public Guid PaymentId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public Order Transaction { get; set; }
        public float PaymentAmount { get; set; }

        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string OtherDetails { get; set; }
        [Display(AutoGenerateField = false)]
        public DateTime PaymentDate { get; set; }
        public PaymentStatus Status { get; set; }
    }
}
