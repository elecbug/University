using System;
using System.Collections.Generic;

namespace P1127.todoDB;

public partial class TodoDetail
{
    public DateTime Id { get; set; }

    public DateTime TodoId { get; set; }

    public string TodoPersonName { get; set; } = null!;

    public string Title { get; set; } = null!;

    public ulong IsDone { get; set; }

    public virtual Todo Todo { get; set; } = null!;
}
