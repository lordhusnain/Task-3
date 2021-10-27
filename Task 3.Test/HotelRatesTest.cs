using DAL;
using Domain;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Linq;
using Task_3.Controllers;

namespace Task_3.Test
{
    public class HotelRatesTest
    {
        private HotelRatesController _hotelRatesController;
        [SetUp]
        public void Setup()
        {
            _hotelRatesController = new HotelRatesController(null, new HotelRateRepository());
        }

        [Test]
        public void HotelRates_ShouldReturnJSONFileExists()
        {
            var response = _hotelRatesController.Get(7294, DateTime.Parse("2016-03-15T00:00:00.000+01:00")) as ObjectResult;
            Assert.AreEqual((int)response.StatusCode, 200);
        }


        [Test]
        public void HotelRates_ShouldReturnNotNullResult()
        {
            var response = _hotelRatesController.Get(7294, DateTime.Parse("2016-03-15T00:00:00.000+01:00")) as ObjectResult;
            var result = response.Value as HotelRateModel;
            Assert.IsNotNull(result.Hotel);
        }

        [Test]
        public void HotelRates_ShouldReturnNullResult()
        {
            var response = _hotelRatesController.Get(72941, DateTime.Parse("2016-03-15T00:00:00.000+01:00")) as ObjectResult;
            Assert.IsNull(response.Value);
        }

        [Test]
        public void HotelRates_ShouldReturnNoRatesButHotel()
        {
            var response = _hotelRatesController.Get(7294, DateTime.Parse("2023-03-15T00:00:00.000+01:00")) as ObjectResult;
            var result = response.Value as HotelRateModel;
            Assert.AreEqual((int)result.HotelRates.Count() , 0);
        }
    }
}