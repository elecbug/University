using System;
using System.Collections.Generic;

namespace P0927.quizDB;

public partial class Student
{
    public int Number { get; set; }

    public string Name { get; set; } = null!;

    public int? Korean { get; set; }

    public int? Math { get; set; }

    public int? English { get; set; }
}
