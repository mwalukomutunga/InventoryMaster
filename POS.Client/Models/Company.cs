using POS.Client.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POS.Client.Models
{
  public  class Company: Base
    {
        public Company()
        {
            
            CreatedAt = IDateTime.Now();
            UpdatedAt = IDateTime.Now();
            Terminus = Environment.MachineName;
        }
        [Display(AutoGenerateField = false)]
        [Key]
        public Guid ID { get; set; }
        [Display(GroupName = "<1>", Name = "Name")]
        public string Name { get; set; }
        [Display(GroupName = "<1>", Name = "Address")]
        public string Address { get; set; }
        [Display(GroupName = "<2>", Name = "Telephone")]
        public string Telephone { get; set; }
        [Display(GroupName = "<2>", Name = "Email")]
        public string Email { get; set; }
        [Display(GroupName = "<3>", Name = "PIN")]
        public string PIN { get; set; }
        [Display(GroupName = "<3>", Name = "Logo")]
        public byte[] Logo { get; set; }
    }
}
