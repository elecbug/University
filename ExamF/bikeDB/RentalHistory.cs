using System;
using System.Collections.Generic;

namespace ExamF.bikeDB;

public partial class RentalHistory
{
    public int Id { get; set; }

    public int BikeId { get; set; }

    public int MemberId { get; set; }

    public DateTime RentalTime { get; set; }

    public DateTime? ReturnTime { get; set; }

    public virtual Bike Bike { get; set; } = null!;

    public virtual Member Member { get; set; } = null!;
}
