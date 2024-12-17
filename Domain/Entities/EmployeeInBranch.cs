using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class EmployeeInBranch
    {
        //Columns
        public int EmployeeID { get; set; }
        public int BranchID { get; set; }

        //Relations
        [ForeignKey(nameof(EmployeeID))] public virtual Employee? Employee { get; set; }
        [ForeignKey(nameof(BranchID))] public virtual Branch? Branch { get; set; }
    }
}
