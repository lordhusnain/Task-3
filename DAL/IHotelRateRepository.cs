using Domain;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DAL
{
    public interface IHotelRateRepository : IDisposable
    {
        HotelRateModel GetByHotelIdAndArrivalDate(int hotelId, DateTime arrivalDate, CancellationToken ct = default(CancellationToken));
    }
}
