using System;
using System.Collections.Generic;

namespace P1023.db1023;

public partial class Table2
{
    public DateTime Date { get; set; }

    public DateTime Fkdate { get; set; }

    public string Menu { get; set; } = null!;

    public int Num { get; set; }

    public virtual Table1 FkdateNavigation { get; set; } = null!;
}
