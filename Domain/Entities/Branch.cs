using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Branch
    {
        //Columns
        [Required] public int ID { get; set; }
        [Required][MaxLength(255)] public string Name { get; set; } = string.Empty;
        [Required][MaxLength(255)] public string Address { get; set; } = string.Empty;

        //Relations
        public virtual List<EmployeeInBranch>? EmployeesInBranches { get; set; }
        public virtual List<Product>? Products { get; set; }
    }
}
