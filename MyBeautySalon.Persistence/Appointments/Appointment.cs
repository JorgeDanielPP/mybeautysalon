using System;
using System.Collections.Generic;

namespace MyBeautySalon.Persistence.Appointments;

public partial class Appointment
{
    public int? Id { get; set; }

    public DateTime? Date { get; set; }

    public string? CustomerName { get; set; }
}
