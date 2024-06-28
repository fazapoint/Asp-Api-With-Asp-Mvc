using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VehicleRentalWeb.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;


namespace VehicleRentalWeb.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly HttpClient _httpClient;

        public VehiclesController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("VehicleClient");
        }

        public async Task<IActionResult> Index()
        {
            
            var response = await _httpClient.GetAsync("api/Vehicles");
            if (!response.IsSuccessStatusCode)
            {
                // Handle error response
                return View("Error");
            }

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var vehicles = JsonConvert.DeserializeObject<List<Vehicle>>(jsonResponse);

            return View(vehicles);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var vehicle = new Vehicle(); // Initialize a new Vehicle object
            return View(vehicle);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Vehicle vehicle)
        {

            if (!ModelState.IsValid)
            {
                return View(vehicle); // Return the view with validation errors
            }

            // Convert the vehicle object to JSON
            var json = JsonConvert.SerializeObject(vehicle);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Send the POST request to create a new vehicle
            var response = await _httpClient.PostAsync("api/Vehicles", content);

            if (response.IsSuccessStatusCode)
            {
                // Redirect to Index action if the vehicle was successfully created
                return RedirectToAction(nameof(Index));
            }
            else
            {
                // Handle error response
                return View("Error");
            }
        }
    }
}
