using Hotel_API.Models;
using System.Text.Json;

namespace Hotel_API.Services
{
    public class HotelService
    {
        private readonly string _filePath = "hotels.json";
        private List<Hotel> _hotels;

        public HotelService()
        {
            LoadJsonHotels();
        }

        private void LoadJsonHotels()
        {
            var json = File.ReadAllText(_filePath);
            _hotels = JsonSerializer.Deserialize<List<Hotel>>(json);
        }
        private void SaveJsonHotels()
        {
            var json = JsonSerializer.Serialize(_hotels);
            File.WriteAllText(_filePath, json);
        }
        // GET
        public IEnumerable<Hotel> GetHotels()
        {
            return _hotels;
        }
        // GET By ID
        public Hotel GetHotelById(int id)
        {
            return _hotels.FirstOrDefault(h => h.Id == id);
        }
        // POST
        public void AddHotel(Hotel hotel)
        {
            _hotels.Add(hotel);
            SaveJsonHotels();
        }
        // PATCH - PUT
        public void UpdateHotel(int id, Hotel updatedHotel)
        {
            var hotelIndex = _hotels.FindIndex(h => h.Id == id);
            if (hotelIndex >= 0)
            {
                _hotels[hotelIndex] = updatedHotel;
                SaveJsonHotels();
            }
        }
        // DELETE
        public void DeleteHotel(int id)
        {
            var hotel = GetHotelById(id);
            if (hotel != null)
            {
                _hotels.Remove(hotel);
                SaveJsonHotels();
            }
        }
    }
}
