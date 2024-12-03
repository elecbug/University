using System;
using System.Collections.Generic;

namespace P1206.carDB;

public partial class Car
{
    public int Id { get; set; }

    public string ModelName { get; set; } = null!;

    public int MakerId { get; set; }

    public DateTime ProductionDate { get; set; }

    public string Color { get; set; } = null!;

    public int RentalPrice { get; set; }

    public virtual Maker Maker { get; set; } = null!;

    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();
}
