using System;
using System.Collections.Generic;

namespace P1106.orderDB;

public partial class Member
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int Age { get; set; }

    public string Address { get; set; } = null!;

    public virtual ICollection<Porder> Porders { get; set; } = new List<Porder>();
}
