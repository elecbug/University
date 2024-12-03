using System;
using System.Collections.Generic;

namespace P1101.hospital;

public partial class Patient
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Age { get; set; }

    public virtual ICollection<DoctorPatient> DoctorPatients { get; set; } = new List<DoctorPatient>();
}
