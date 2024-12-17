using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product
    {
        //Columns
        [Required] public int ID { get; set; }
        [Required][MaxLength(255)] public string Name { get; set; } = string.Empty;
        [Required] public int CategoryID { get; set; }
        [Required] public int Count { get; set; }
        [Required] public float PricePerItem { get; set; }
        [Required] public int BranchID { get; set; }
        [Required][MaxLength(10)][MinLength(10)] public string ContractID { get; set; } = "X/XX/XX/XX";

        //Relations
        [ForeignKey(nameof(BranchID))] public virtual Branch? Branch { get; set; }
        [ForeignKey(nameof(ContractID))] public virtual Contract? Contract { get; set; }
        [ForeignKey(nameof(CategoryID))] public virtual Category? Category { get; set;}
    }
}
