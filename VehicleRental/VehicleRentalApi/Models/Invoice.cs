using System;
using System.Collections.Generic;

namespace VehicleRentalApi.Models;

public partial class Invoice
{
    public int InvoiceId { get; set; }

    public int? RentalId { get; set; }

    public decimal? Amount { get; set; }

    public DateTime? InvoiceDate { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Rental? Rental { get; set; }
}
