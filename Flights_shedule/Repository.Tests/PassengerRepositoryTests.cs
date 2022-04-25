// <copyright file="AirplaneRepositoryTests.cs" company="МИИТ">
// Copyright (c) Дюсов М.А. All rights reserved.
// </copyright>

namespace Repository.Tests
{
    using System;
    using System.Linq;
    using Domain;
    using NHibernate;
    using NUnit.Framework;
    using ORM.Mappings;
    using ORM.Repositories;

    [TestFixture]
    public class PassengerRepositoryTests
    {
        [Test]
        public void Add_Passenger()
        {
            var savedPassenger = GeneratePassenger();

            _iRepository.Create(savedPassenger);

            var actual = _iRepository.GetAll().Count();

            var expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Delete_Passenger_By_Id()
        {
            _iRepository.Delete(1);

            var actual = _iRepository.GetAll().Count();

            var expected = 0;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Update_Passenger_By_LastName()
        {
            var savedPassenger = GeneratePassenger();

            _iRepository.Create(savedPassenger);

            var updatePassenger = _iRepository.Get(2);

            updatePassenger.LastName = "Чернов";

            _iRepository.Update(updatePassenger);

            var actual = updatePassenger.LastName;

            var expected = "Чернов";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Get_Passenger_When_No_Entity_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _ = _iRepository.Get(12412));
        }

        [Test]
        public void Delete_Passenger_When_No_Entity_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _iRepository.Delete(12412));
        }

        [Test]
        public void Find_Passenger_By_LastName()
        {
            var savedPerson = GeneratePassenger();

            _iRepository.Create(savedPerson);

            var passengerToBeFind = _iRepository.Find((pas) => pas.LastName == "О'Брайен");

            var actual = passengerToBeFind;

            var expected = savedPerson;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Find_Passenger_By_Uknown_LastName_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _iRepository.Find((pas) => pas.LastName == "Something New"));
        }

        private static Passenger GeneratePassenger(string secondName = null, string firstName = null) => new (1, secondName ?? "О'Брайен", firstName ?? "Уолтер");

        private static readonly ISession _session = NHibernateTestsConfigurator.BuildSessionForTest();

        private static readonly IRepository<Passenger> _iRepository = new PassengerRepository(_session);
    }
}
