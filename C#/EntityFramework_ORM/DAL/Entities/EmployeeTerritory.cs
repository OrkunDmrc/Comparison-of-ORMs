using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class EmployeeTerritories : IEntity
    {
        public int EmployeeID { get; set; }

        public string TerritoryID { get; set; } = null!;

        public virtual Employee Employee { get; set; } = null!;

        public virtual Territory Territory { get; set; } = null!;
    }
}
