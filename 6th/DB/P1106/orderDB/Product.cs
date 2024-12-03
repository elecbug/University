using System;
using System.Collections.Generic;

namespace P1106.orderDB;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Price { get; set; }

    public virtual ICollection<PorderDetail> PorderDetails { get; set; } = new List<PorderDetail>();
}
