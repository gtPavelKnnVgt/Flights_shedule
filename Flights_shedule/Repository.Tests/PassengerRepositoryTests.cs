﻿
namespace Repository.Tests
{
    using Domain;
    using NHibernate;
    using NUnit.Framework;
    using ORM.Mappings;
    using ORM.Repositories;
    using System.Linq;
    [TestFixture]
    class PassengerRepositoryTests
    {
        [Test]
        public void Add_Passenger()
        {
            var savedPassenger = GeneratePassenger();
            _iRep.Create(savedPassenger);
            Assert.AreEqual(1, _iRep.GetAll().Count());
            Assert.AreEqual("Уолтер", savedPassenger.FirstName);
        }

        [Test]
        public void Delete_PassengerById()
        {
            var Passenger = _iRep.Get(1);
            _iRep.Delete(1);
            Assert.AreEqual(0, _iRep.GetAll().Count());
        }

        [Test]
        public void UpdatePassengerByLastName()
        {
            var savedPassenger = GeneratePassenger(2);
            _iRep.Create(savedPassenger);
            var updatePassenger = _iRep.Get(2);
            updatePassenger.LastName = "Чернов";

            _iRep.Update(updatePassenger);
            Assert.AreEqual("Чернов", updatePassenger.LastName);
        }
        private static Passenger GeneratePassenger(int id = 1, string secondName = null, string firstName = null) => new(1, secondName ?? "О'Брайен", firstName ?? "Уолтер");

        private static ISession _session = NHibernateTestsConfigurator.BuildSessionForTest();

        private static IRepository<Passenger> _iRep = new PassengerRepository(_session);
    }
}
