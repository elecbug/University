using System;
using System.Collections.Generic;

namespace HW01.univDB;

public partial class Subject
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Room { get; set; }

    public string? Dept { get; set; }

    public int Credit { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();
}
