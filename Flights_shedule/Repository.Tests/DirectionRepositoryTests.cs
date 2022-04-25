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
    public class DirectionRepositoryTests
    {
        [Test]
        public void Add_Direction_With_No_Flights()
        {
            var savedDirection = GenerateDirection();

            _iRepository.Create(savedDirection);

            var actual = _iRepository.GetAll().Count();

            var expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Delete_Direction_By_Id()
        {
            _iRepository.Delete(1);

            var actual = _iRepository.GetAll().Count();

            var expected = 0;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Update_Direction_By_StartLocation()
        {
            var savedDirection = GenerateDirection();

            _iRepository.Create(savedDirection);

            var updateDirection = _iRepository.Get(2);

            updateDirection.StartLocation = "Самара";

            _iRepository.Update(updateDirection);

            var actual = updateDirection.StartLocation;

            var expected = "Самара";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Get_Direction_When_No_Entity_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _ = _iRepository.Get(412));
        }

        [Test]
        public void Delete_Direction_When_No_Entity_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _iRepository.Delete(12312));
        }

        [Test]
        public void Find_Direction_By_StartLocation()
        {
            var savedDirection = GenerateDirection();

            _iRepository.Create(savedDirection);

            var directionToBeFind = _iRepository.Find((dir) => dir.StartLocation == "Москва");

            var actual = directionToBeFind;

            var expected = _iRepository.Get(2);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Find_Direction_By_Uknown_StartLocation_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _iRepository.Find((dir) => dir.StartLocation == "ASDSAD"));
        }

        private static Direction GenerateDirection(string startLocation = null, string endLocation = null)
            => new (1, startLocation ?? "Москва", endLocation ?? "Рязань");

        private static readonly ISession _session = NHibernateTestsConfigurator.BuildSessionForTest();

        private static readonly IRepository<Direction> _iRepository = new DirectionRepository(_session);
    }
}
