using DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace DAL.Entities;

public partial class Shipper : IEntity
{
    public int ShipperID { get; set; }

    public string CompanyName { get; set; } = null!;

    public string? Phone { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
