using DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace MyApp.DAL.Entities;

public partial class Region : IEntity
{
    public int RegionID { get; set; }

    public string RegionDescription { get; set; } = null!;

    public virtual ICollection<Territory> Territories { get; set; } = new List<Territory>();
}
