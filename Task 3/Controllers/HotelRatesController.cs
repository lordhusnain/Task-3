using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DAL;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Task_3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelRatesController : ControllerBase
    {
        private readonly ILogger<HotelRatesController> _logger;
        private readonly IHotelRateRepository _hotelRateRepository;

        public HotelRatesController(ILogger<HotelRatesController> logger, IHotelRateRepository hotelRateRepository)
        {
            _logger = logger;
            _hotelRateRepository = hotelRateRepository;
        }

        [HttpGet]
        [Produces(typeof(HotelRateModel))]
        public IActionResult Get(int hotelId, DateTime arrivalDate, CancellationToken ct = default(CancellationToken))
        {
            try
            {
                return new ObjectResult(_hotelRateRepository.GetByHotelIdAndArrivalDate(hotelId, arrivalDate, ct));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
