using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Contract
    {
        //Columns
        [Key] [MinLength(10)] [MaxLength(10)] public string ID { get; set; } = "X/XX/XX/XX";
        [Required] public int CustomerID { get; set; }
        [Required] public DateTime DateStart { get; set; }
        [Required] public DateTime DateEnd { get; set; }
        [Required] public int EmployeeID { get; set; }
        [Required] public float InterestPerDay { get; set; } = 0.05f;

        //Relations
        [ForeignKey(nameof(CustomerID))] public virtual Customer? Customer { get; set; }
        [ForeignKey(nameof(EmployeeID))] public virtual Employee? Employee { get; set; }
        public virtual List<Product>? Products { get; set; }
    }
}
