using System;
using System.Collections.Generic;

namespace P1106.orderDB;

public partial class PorderDetail
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public virtual Porder Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
