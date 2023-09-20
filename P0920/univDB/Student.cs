using System;
using System.Collections.Generic;

namespace P0920.univDB;

public partial class Student
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public int Grade { get; set; }

    public int? Age { get; set; }

    public string Gender { get; set; } = null!;

    public string? Phone { get; set; }

    public string Dept { get; set; } = null!;

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();
}
