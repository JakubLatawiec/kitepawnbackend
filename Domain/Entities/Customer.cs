using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Customer
    {
        //Columns
        [Key] public int ID { get; set; }
        [Required][MaxLength(255)] public string FirstName { get; set; } = string.Empty;
        [Required][MaxLength(255)] public string LastName { get; set; } = string.Empty;
        [Required][MaxLength(255)] public string Address { get; set; } = string.Empty;
        [Required][Phone] public string PhoneNumber { get; set; } = string.Empty;
        [Required][EmailAddress] public string EmailAddress { get; set;} = string.Empty; 

        //Relations
        public virtual List<Contract>? Contracts { get; set; }

    }
}
