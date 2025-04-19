using DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace DAL.Entities;

public partial class Region : IEntity
{
    public int RegionID { get; set; }

    public string RegionDescription { get; set; } = null!;
}
