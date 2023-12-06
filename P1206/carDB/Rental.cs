using System;
using System.Collections.Generic;

namespace P1206.carDB;

public partial class Rental
{
    public int Id { get; set; }

    public int CarId { get; set; }

    public int CustomerId { get; set; }

    public DateTime RentalDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    public virtual Car Car { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;
}
