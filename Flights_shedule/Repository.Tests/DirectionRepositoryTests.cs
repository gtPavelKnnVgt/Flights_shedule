// <copyright file="AirplaneRepositoryTests.cs" company="МИИТ">
// Copyright (c) Дюсов М.А. All rights reserved.
// </copyright>

namespace Repository.Tests
{
    using System.Linq;
    using Domain;
    using NHibernate;
    using NUnit.Framework;
    using ORM.Mappings;
    using ORM.Repositories;

    [TestFixture]
    public class DirectionRepositoryTests
    {
        [Test]
        public void Add_DirectionWithNoFlights()
        {
            var savedDirection = GenerateDirection();
            _iRep.Create(savedDirection);
            Assert.AreEqual(1, _iRep.GetAll().Count());
            Assert.AreEqual("Москва", savedDirection.StartLocation);
        }

        [Test]
        public void Delete_DirectionById()
        {
            var deleteDirection = _iRep.Get(1);
            _iRep.Delete(1);
            Assert.AreEqual(0, _iRep.GetAll().Count());
        }

        [Test]
        public void UpdateDirectionByStartLocation()
        {
            var savedDirection = GenerateDirection(2);
            _iRep.Create(savedDirection);
            var updateDirection = _iRep.Get(2);
            updateDirection.StartLocation = "Самара";

            _iRep.Update(updateDirection);
            Assert.AreEqual("Самара", updateDirection.StartLocation);
        }

        private static Direction GenerateDirection(int id = 1, string startLocation = null, string endLocation = null)
        {
            return new (1, startLocation ?? "Москва", endLocation ?? "Рязань");
        }

        private static Flight GenerateFlight(int flightNumber = 1, int ticketPrice = 1000, string departureTime = null, string arrivalTime = null)
        {
            return new (flightNumber, ticketPrice,
               departureTime ?? "12:30",
               arrivalTime ?? "15:00");
        }

        private static readonly ISession _session = NHibernateTestsConfigurator.BuildSessionForTest();

        private static readonly IRepository<Direction> _iRep = new DirectionRepository(_session);
    }
}
