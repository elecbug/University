using System;
using System.Collections.Generic;

namespace ExamF.bikeDB;

public partial class Member
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<RentalHistory> RentalHistories { get; set; } = new List<RentalHistory>();
}
