using POS.Domain.Contracts;
using POS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POS.Domain.Models
{
    public class Customer: Base
    {
        public Customer()
        {
           
            CreatedAt = IDateTime.Now();
            UpdatedAt = IDateTime.Now();
            DateOfBirth = IDateTime.Now().AddYears(-20);
            Terminus = Environment.MachineName;
            //  CreatedBy = null;
            // UpdatedBy = null;
        }
        
        [Key]
        public Guid CustomerId{ get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender  { get; set; }
        public string Address { get; set; }
        public decimal CurrentBalance { get; set; }
        public DateTime DateOfLastDeposit { get; set; }
        public float AmountOfLastDeposit { get; set; }
        public string  OtherDetails { get; set; }
    }
}
