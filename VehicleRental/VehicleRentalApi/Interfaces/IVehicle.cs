using VehicleRentalApi.Models;

namespace VehicleRentalApi.Interfaces
{
    public interface IVehicle : ICrud<Vehicle>
    {
        IEnumerable<Vehicle> GetByMakeName(string make);
    }
}
