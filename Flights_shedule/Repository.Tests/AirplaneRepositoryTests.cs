// <copyright file="AirplaneRepositoryTests.cs" company="����">
// Copyright (c) ������� �.�. All rights reserved.
// </copyright>

namespace Repository.Tests
{
    using Domain;
    using NHibernate;
    using NUnit.Framework;
    using ORM.Mappings;
    using ORM.Repositories;
    using System.Linq;
    [TestFixture]
    public class AirplaneRepositoryTests
    {

        [Test]
        public void Add_Airplane()
        {
            var savedAir = GenerateAirplane();
            _iRep.Create(savedAir);
            Assert.AreEqual(1, _iRep.GetAll().Count());
            Assert.AreEqual("AA44", savedAir.TailNumber);
        }

        [Test]
        public void Delete_AirplaneById()
        {
            var airplane = _iRep.Get(1);
            _iRep.Delete(1);
            Assert.AreEqual(0, _iRep.GetAll().Count());     
        }

        [Test]
        public void UpdateAirplaneByTailNumber()
        {
            var savedAir =GenerateAirplane(2);
            _iRep.Create(savedAir);
            var updateAir = _iRep.Get(2);
            updateAir.TailNumber = "AH21";

            _iRep.Update(updateAir);
            Assert.AreEqual("AH21", updateAir.TailNumber);
        }
        private static Airplane GenerateAirplane(int id= 1, string type = null, double size = 350.29, string tailNumber = null, double totalWeight = 5000.25, AirplaneClasses airplaneClass = AirplaneClasses.A, int seatsCount = 286, double flightRange = 10000.252)
        {
            return new(1, type ?? "Common", size, tailNumber ?? "AA44", totalWeight, airplaneClass, seatsCount, flightRange);
        }

        private static ISession _session = NHibernateTestsConfigurator.BuildSessionForTest();

        private static IRepository<Airplane> _iRep = new AirplaneRepository(_session);
        
    }
}