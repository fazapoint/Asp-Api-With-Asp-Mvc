using VehicleRentalApi.Interfaces;
using VehicleRentalApi.Models;

namespace VehicleRentalApi.DAL
{
    public class VehicleEF : IVehicle
    {
        private readonly VehicleRentalDbContext _vehicleRentalDbContext;
        public VehicleEF(VehicleRentalDbContext vehicleRentalDbContext)
        {
            _vehicleRentalDbContext = vehicleRentalDbContext;
        }

        public Vehicle Add(Vehicle entity)
        {
            _vehicleRentalDbContext.Vehicles.Add(entity);
            _vehicleRentalDbContext.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            var deleteVehicle = GetById(id);
            if (deleteVehicle != null)
            {
                _vehicleRentalDbContext.Vehicles.Remove(deleteVehicle);
                _vehicleRentalDbContext.SaveChanges();
            }
        }

        public IEnumerable<Vehicle> GetAll()
        {
            return _vehicleRentalDbContext.Vehicles.ToList();
        }

        public Vehicle GetById(int id)
        {
            return _vehicleRentalDbContext.Vehicles.Find(id);
        }

        public IEnumerable<Vehicle> GetByMakeName(string make)
        {
            return _vehicleRentalDbContext.Vehicles.Where(v => v.Make == make).ToList();
        }

        public Vehicle Update(Vehicle entity)
        {
            var updateVehicle = GetById(entity.VehicleId);
            if (updateVehicle != null)
            {
                updateVehicle.Make = entity.Make;
                updateVehicle.Model = entity.Model;
                updateVehicle.Year = entity.Year;
                updateVehicle.RentalPrice = entity.RentalPrice;
                updateVehicle.AvailabilityStatus = entity.AvailabilityStatus;
                _vehicleRentalDbContext.SaveChanges();
            }
            return updateVehicle;
        }
    }
}
