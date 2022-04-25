// <copyright file="AirplaneRepositoryTests.cs" company="МИИТ">
// Copyright (c) Кононов П.А. All rights reserved.
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
    public class AirplaneRepositoryTests
    {
        [Test]
        public void Add_Airplane_With_Flights()
        {
            var savedAir = GenerateAirplane();

            savedAir.Flights = new HashSet<Flight>()
            {
                new (1, 2000, "10:00", "18:00"),
                new (2, 2000, "11:00", "19:00"),
            };

            _iRepository.Create(savedAir);

            var actual = _iRepository.GetAll().Count();

            var expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_Airplane_With_NoFlights()
        {
            var savedAir = GenerateAirplane();

            _iRepository.Create(savedAir);

            var actual = _iRepository.GetAll().Count();

            var expected = 2;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Delete_Airplane_By_Id()
        {
            _iRepository.Delete(1);

            var actual = _iRepository.GetAll().Count();

            var expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Update_Airplane_By_TailNumber()
        {
            var updatedAir = _iRepository.Get(2);

            updatedAir.TailNumber = "AH21";

            _iRepository.Update(updatedAir);

            var actual = updatedAir.TailNumber;

            var expected = "AH21";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Get_Airplane_When_No_Entity_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _ = _iRepository.Get(12412));
        }

        [Test]
        public void Delete_Airplane_When_No_Entity_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _iRepository.Delete(12412));
        }

        [Test]
        public void Find_Airplane_By_TailNumber()
        {
            var airplaneToBeFind = _iRepository.Find((air) => air.TailNumber == "AA44");

            var actual = airplaneToBeFind;

            var expected = _iRepository.Get(2);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Find_Airplane_By_Uknown_TailNumber_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _iRepository.Find((air) => air.TailNumber == "UUUUUU"));
        }

        private static Airplane GenerateAirplane(
            string type = null,
            double size = 350.29,
            string tailNumber = null,
            double totalWeight = 5000.25,
            AirplaneClasses airplaneClass = AirplaneClasses.A,
            int seatsCount = 286,
            double flightRange = 10000.252)
            => new (1, type ?? "Common", size, tailNumber ?? "AA44", totalWeight, airplaneClass, seatsCount, flightRange);

        private static readonly ISession _session = NHibernateTestsConfigurator.BuildSessionForTest();

        private static readonly IRepository<Airplane> _iRepository = new AirplaneRepository(_session);
    }
}