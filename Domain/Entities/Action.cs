using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Action
    {
        //Columns
        [Key] public int ID { get; set; }
        [Required][MaxLength(255)] public string Name { get; set; } = string.Empty;
        [Required] public DateTime Date { get; set; }
        [Required] public int EmployeeID { get; set; }

        //Relations
        [ForeignKey(nameof(EmployeeID))] public virtual Employee? Employee { get; set; }
    }
}
