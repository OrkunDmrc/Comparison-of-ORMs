using DAL.Interfaces;

namespace DAL.Entities;

public partial class Territory : IEntity
{
    public string TerritoryID { get; set; } = null!;

    public string TerritoryDescription { get; set; } = null!;

    public int RegionID { get; set; }

    public virtual Region Region { get; set; } = null!;

    public virtual ICollection<EmployeeTerritories> EmployeeTerritories { get; set; } = new List<EmployeeTerritories>();

    //public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
