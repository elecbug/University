using System;
using System.Collections.Generic;

namespace P1018.todoDB;

public partial class Todo
{
    public DateTime Dateid { get; set; }

    public string Descryp { get; set; } = null!;

    public int? Checked { get; set; }
}
