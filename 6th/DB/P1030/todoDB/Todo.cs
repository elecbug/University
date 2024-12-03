using System;
using System.Collections.Generic;

namespace P1030.todoDB;

public partial class Todo
{
    public DateTime Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<TodoDetail> TodoDetails { get; set; } = new List<TodoDetail>();
}
