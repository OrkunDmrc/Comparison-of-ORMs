﻿using DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace DAL.Entities;

public partial class Category : IEntity
{
    public int CategoryID { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? Description { get; set; }

    public byte[]? Picture { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
