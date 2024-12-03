using System;
using System.Collections.Generic;

namespace ExamF.bikeDB;

public partial class RechargeHistory
{
    public int Id { get; set; }

    public int BikeId { get; set; }

    public DateTime RechargeTime { get; set; }

    public virtual Bike Bike { get; set; } = null!;
}
