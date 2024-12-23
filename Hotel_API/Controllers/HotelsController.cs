using Hotel_API.Models;
using Hotel_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelsController : ControllerBase
    {
        private readonly HotelService _hotelService;

        public HotelsController()
        {
            _hotelService = new HotelService();
        }

        // GET: api/hotels
        [HttpGet]
        public ActionResult<IEnumerable<Hotel>> GetHotels()
        {
            var hotels = _hotelService.GetHotels();
            return Ok(hotels);
        }

        // GET: api/hotels/{id}
        [HttpGet("{id}")]
        public ActionResult<Hotel> GetHotel(int id)
        {
            var hotel = _hotelService.GetHotelById(id);
            if (hotel == null)
            {
                return NotFound(new { error = "Hotel not found" });
            }
            return Ok(hotel);
        }

        // POST: api/hotels
        [HttpPost]
        public ActionResult<Hotel> CreateHotel([FromBody] Hotel hotel)
        {
            hotel.Id = _hotelService.GetHotels().Count() + 1; 
            _hotelService.AddHotel(hotel);
            return CreatedAtAction(nameof(GetHotel), new { id = hotel.Id }, hotel);
        }

        // PUT: api/hotels/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateHotel(int id, [FromBody] Hotel updatedHotel)
        {
            var existingHotel = _hotelService.GetHotelById(id);
            if (existingHotel == null)
            {
                return NotFound(new { error = "Hotel not found" });
            }

            updatedHotel.Id = id; 
            _hotelService.UpdateHotel(id, updatedHotel);
            return NoContent();
        }

        // PATCH: api/hotels/{id}
        [HttpPatch("{id}")]
        public IActionResult PartialUpdateHotel(int id, [FromBody] Hotel updatedHotel)
        {
            var existingHotel = _hotelService.GetHotelById(id);
            if (existingHotel == null)
            {
                return NotFound(new { error = "Hotel not found" });
            }
            if (updatedHotel.Name != null)
            {
                existingHotel.Name = updatedHotel.Name;
            }

            _hotelService.UpdateHotel(id, existingHotel);
            return NoContent();
        }

        // DELETE: api/hotels/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteHotel(int id)
        {
            var existingHotel = _hotelService.GetHotelById(id);
            if (existingHotel == null)
            {
                return NotFound(new { error = "Hotel not found" });
            }

            _hotelService.DeleteHotel(id);
            return NoContent();
        }
    }
}
