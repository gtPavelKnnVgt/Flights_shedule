﻿

namespace Repository.Tests
{
    using Domain;
    using NHibernate;
    using NUnit.Framework;
    using ORM.Mappings;
    using ORM.Repositories;
    using System.Linq;
    using System.Collections.Generic;
    [TestFixture]
    class FlightRepositoryTests
    {
        [Test]
        public void Add_FlightWithNoPassengers()
        {
            var savedFlight = GenerateFlight();
            _iRep.Create(savedFlight);
            Assert.AreEqual(1, _iRep.GetAll().Count());
            Assert.AreEqual("12:30", savedFlight.DepartureTime);
        }

        [Test]
        public void Add_FlightWithPassangers()
        {
            var savedFlight = GenerateFlight();
            savedFlight.Passengers = new HashSet<Passenger>()
            {
                new(1, "Дюсов", "Михаил")
            };
            _iRep.Create(savedFlight);
            Assert.AreEqual(2, _iRep.GetAll().Count());
            Assert.AreEqual("12:30", savedFlight.DepartureTime);
        }

        [Test]
        public void Delete_FlightById()
        {
            var Flight = _iRep.Get(1);
            _iRep.Delete(1);
            Assert.AreEqual(1, _iRep.GetAll().Count());
        }

        [Test]
        public void UpdateFlightByArrivalTime()
        {
            //var savedPassenger = GeneratePassenger(2);
            var savedFlight = GenerateFlight();
            _iRep.Create(savedFlight);
            var updateFlight = _iRep.Get(2);
            updateFlight.ArrivalTime = "16:00";

            _iRep.Update(updateFlight);
            Assert.AreEqual("16:00", updateFlight.ArrivalTime);
        }
        private static Flight GenerateFlight(int flightNumber = 1, int ticketPrice = 1000, string departureTime = null, string arrivalTime = null)
        {
            return new(flightNumber, ticketPrice,
               departureTime ?? "12:30",
               arrivalTime ?? "15:00");
        }
        private static Passenger GeneratePassenger(int id = 1, string secondName = null, string firstName = null) => new(1, secondName ?? "О'Брайен", firstName ?? "Уолтер");

        private static ISession _session = NHibernateTestsConfigurator.BuildSessionForTest();

        private static IRepository<Flight> _iRep = new FlightRepository(_session);
    }
}
