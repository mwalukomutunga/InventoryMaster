using System;
using System.ComponentModel.DataAnnotations;

namespace POS.Domain.Models
{
    public abstract  class Base 
    {
        public DateTime CreatedAt { get; set; }
        // public Staff CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        //  public Staff UpdatedBy { get; set; }
        public string Terminus { get; set; }
    }
}
