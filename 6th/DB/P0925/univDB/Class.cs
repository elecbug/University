using System;
using System.Collections.Generic;

namespace P0925.univDB;

public partial class Class
{
    public int StudentId { get; set; }

    public int SubjectId { get; set; }

    public DateTime Joined { get; set; }

    public int? MidScore { get; set; }

    public int? FinalScore { get; set; }

    public string? Grade { get; set; }

    public virtual Student Student { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;
}
