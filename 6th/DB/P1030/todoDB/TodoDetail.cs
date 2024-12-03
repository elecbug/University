using System;
using System.Collections.Generic;

namespace P1030.todoDB;

public partial class TodoDetail
{
    public DateTime Id { get; set; }

    public DateTime TodoId { get; set; }

    public string Descrip { get; set; } = null!;

    public bool IsDone { get; set; }

    public virtual Todo Todo { get; set; } = null!;
}
