namespace VehicleRentalWeb.Models
{
    public class Vehicle
    {
        public int VehicleId { get; set; }

        public string? Make { get; set; }

        public string? Model { get; set; }

        public string? Year { get; set; }

        public decimal? RentalPrice { get; set; }

        public bool? AvailabilityStatus { get; set; }

        //public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();
    }
}
