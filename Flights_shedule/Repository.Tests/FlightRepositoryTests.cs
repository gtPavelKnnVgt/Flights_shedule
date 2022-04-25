// <copyright file="AirplaneRepositoryTests.cs" company="МИИТ">
// Copyright (c) Дюсов М.А. All rights reserved.
// </copyright>

namespace Repository.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Domain;
    using NHibernate;
    using NUnit.Framework;
    using ORM.Mappings;
    using ORM.Repositories;

    [TestFixture]
    public class FlightRepositoryTests
    {
        [Test]
        public void Add_Flight_With_No_Passengers()
        {
            var savedFlight = GenerateFlight();

            _iRepository.Create(savedFlight);

            var actual = _iRepository.GetAll().Count();

            var expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_Flight_With_Passangers()
        {
            var savedFlight = GenerateFlight();

            savedFlight.Passengers = new HashSet<Passenger>()
            {
                new (1, "Дюсов", "Михаил"),
            };

            _iRepository.Create(savedFlight);

            var actual = _iRepository.GetAll().Count();

            var expected = 2;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Delete_Flight_By_Id()
        {
            _iRepository.Delete(1);

            var actual = _iRepository.GetAll().Count();

            var expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Update_Flight_By_ArrivalTime()
        {
            var savedFlight = GenerateFlight();

            _iRepository.Create(savedFlight);

            var updateFlight = _iRepository.Get(2);

            updateFlight.ArrivalTime = "16:00";

            var actual = updateFlight.ArrivalTime;

            var expected = "16:00";

            _iRepository.Update(updateFlight);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Get_Flight_When_No_Entity_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _ = _iRepository.Get(12412));
        }

        [Test]
        public void Delete_Flight_When_No_Entity_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _iRepository.Delete(12412));
        }

        [Test]
        public void Find_Flight_By_ArrivalTime()
        {
            var flightToBeFind = _iRepository.Find((fl) => fl.ArrivalTime == "15:00");

            var actual = flightToBeFind;

            var expected = _iRepository.Get(2);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Find_Flight_By_Uknown_ArrivalTime_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _iRepository.Find((fl) => fl.ArrivalTime == "11:00"));
        }

        private static Flight GenerateFlight(
            int flightNumber = 1,
            int ticketPrice = 2000,
            string departureTime = null,
            string arrivalTime = null)
            => new (flightNumber, ticketPrice, departureTime ?? "12:30", arrivalTime ?? "15:00");

        private static readonly ISession _session = NHibernateTestsConfigurator.BuildSessionForTest();

        private static readonly IRepository<Flight> _iRepository = new FlightRepository(_session);
    }
}
