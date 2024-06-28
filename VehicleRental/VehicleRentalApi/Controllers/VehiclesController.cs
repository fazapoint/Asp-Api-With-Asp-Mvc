using Microsoft.AspNetCore.Mvc;
using VehicleRentalApi.DTO;
using VehicleRentalApi.Interfaces;
using VehicleRentalApi.Models;

namespace VehicleRentalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicle _vehicle;
        public VehiclesController(IVehicle vehicle)
        {
            _vehicle = vehicle;
        }

        [HttpGet]
        public ActionResult<IEnumerable<VehicleDTO>> Get()
        {
            List<VehicleDTO> vehicleDTOs = new List<VehicleDTO>();
            var vehicles = _vehicle.GetAll();

            foreach (var vehicle in vehicles)
            {
                VehicleDTO vehicleDTO = new VehicleDTO
                {
                    VehicleId = vehicle.VehicleId,
                    Make = vehicle.Make,
                    Model = vehicle.Model,
                    Year = vehicle.Year,
                    RentalPrice = vehicle.RentalPrice,
                    AvailabilityStatus = vehicle.AvailabilityStatus
                };
                vehicleDTOs.Add(vehicleDTO);
            }
            return Ok(vehicleDTOs);
        }

        [HttpGet("{id}")]
        public ActionResult<VehicleDTO> GetById(int id)
        {
            var vehicle = _vehicle.GetById(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            VehicleDTO vehicleDTO = new VehicleDTO
            {
                VehicleId = vehicle.VehicleId,
                Make = vehicle.Make,
                Model = vehicle.Model,
                Year = vehicle.Year,
                RentalPrice = vehicle.RentalPrice,
                AvailabilityStatus = vehicle.AvailabilityStatus
            };

            return Ok(vehicleDTO);
        }

        [HttpPost]
        public ActionResult<VehicleDTO> Create([FromBody] VehicleDTO vehicleDTO)
        {
            var vehicle = new Vehicle
            {
                Make = vehicleDTO.Make,
                Model = vehicleDTO.Model,
                Year = vehicleDTO.Year,
                RentalPrice = vehicleDTO.RentalPrice,
                AvailabilityStatus = vehicleDTO.AvailabilityStatus
            };

            _vehicle.Add(vehicle);

            return CreatedAtAction(nameof(GetById), new { id = vehicle.VehicleId }, vehicleDTO);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] VehicleDTO vehicleDTO)
        {
            var vehicle = _vehicle.GetById(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            vehicle.Make = vehicleDTO.Make;
            vehicle.Model = vehicleDTO.Model;
            vehicle.Year = vehicleDTO.Year;
            vehicle.RentalPrice = vehicleDTO.RentalPrice;
            vehicle.AvailabilityStatus = vehicleDTO.AvailabilityStatus;

            _vehicle.Update(vehicle);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var vehicle = _vehicle.GetById(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            _vehicle.Delete(id);

            return NoContent();
        }
    }
}
