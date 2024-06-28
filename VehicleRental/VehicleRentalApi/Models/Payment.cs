using System;
using System.Collections.Generic;

namespace VehicleRentalApi.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int? InvoiceId { get; set; }

    public decimal? Amount { get; set; }

    public DateTime? PaymentDate { get; set; }

    public virtual Invoice? Invoice { get; set; }
}
