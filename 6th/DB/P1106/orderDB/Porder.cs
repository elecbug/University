using System;
using System.Collections.Generic;

namespace P1106.orderDB;

public partial class Porder
{
    public int Id { get; set; }

    public DateTime Created { get; set; }

    public string MemberId { get; set; } = null!;

    public virtual Member Member { get; set; } = null!;

    public virtual ICollection<PorderDetail> PorderDetails { get; set; } = new List<PorderDetail>();
}
