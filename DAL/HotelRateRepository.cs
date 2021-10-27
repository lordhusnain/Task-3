using Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAL
{
    public class HotelRateRepository : IHotelRateRepository
    {
        public HotelRateModel GetByHotelIdAndArrivalDate(int hotelId, DateTime arrivalDate, CancellationToken ct = default)
        {
            HotelRateModel hotel = null;
            try
            {
                string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\task 3 - hotelsrates.json");
                string allText = System.IO.File.ReadAllText(path);
                var hotelRateModel = JsonConvert.DeserializeObject<List<HotelRateModel>>(allText);

                hotel = hotelRateModel.FirstOrDefault(c => c.Hotel.HotelID == hotelId);

                if (hotel != null)
                    hotel.HotelRates = hotel.HotelRates.Where(c => c.TargetDay.Date == arrivalDate.Date).ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return hotel;
        }

        public void Dispose()
        {
            //Dispose any unmanaged resource
        }
    }
}
