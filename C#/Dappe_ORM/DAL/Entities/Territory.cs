using DAL.Interfaces;

namespace DAL.Entities;

public partial class Territory : IEntity
{
    public string TerritoryID { get; set; } = null!;

    public string TerritoryDescription { get; set; } = null!;

    public int RegionID { get; set; }

}
