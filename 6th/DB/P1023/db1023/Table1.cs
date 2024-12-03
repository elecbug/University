using System;
using System.Collections.Generic;

namespace P1023.db1023;

public partial class Table1
{
    public DateTime Date { get; set; }

    public string Phone { get; set; } = null!;

    public int Type { get; set; }

    public int State { get; set; }

    public virtual ICollection<Table2> Table2s { get; set; } = new List<Table2>();
}
