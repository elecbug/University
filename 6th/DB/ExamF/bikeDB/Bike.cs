using System;
using System.Collections.Generic;

namespace ExamF.bikeDB;

public partial class Bike
{
    public int Id { get; set; }

    public bool Used { get; set; }

    public int Battery { get; set; }

    public virtual ICollection<RechargeHistory> RechargeHistories { get; set; } = new List<RechargeHistory>();

    public virtual ICollection<RentalHistory> RentalHistories { get; set; } = new List<RentalHistory>();
}
