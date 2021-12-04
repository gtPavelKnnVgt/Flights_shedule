

namespace Repository.Tests
{
    using Domain;
    using NHibernate;
    using NUnit.Framework;
    using ORM.Mappings;
    using ORM.Repositories;
    using System.Linq;
    [TestFixture]
    class DirectionRepositoryTests
    {
        [Test]
        public void Add_Direction()
        {
            var savedDirection = GenerateDirection();
            _iRep.Create(savedDirection);
            Assert.AreEqual(1, _iRep.GetAll().Count());
            Assert.AreEqual("Москва",savedDirection.startLocation);
        }

        [Test]
        public void Delete_DirectionById()
        {
            var Direction = _iRep.Get(1);
            _iRep.Delete(1);
            Assert.AreEqual(0, _iRep.GetAll().Count());
        }

        [Test]
        public void UpdateDirectionByStartLocation()
        {
            var savedDirection = GenerateDirection(2);
            _iRep.Create(savedDirection);
            var updateDirection = _iRep.Get(2);
            updateDirection.startLocation = "Рязань";

            _iRep.Update(updateDirection);
            Assert.AreEqual("Рязань", updateDirection.startLocation);
        }
        private static Direction GenerateDirection(int id=1, string from = null, string to = null) => new(1, from ?? "Москва", to ?? "Рязань");

        private static ISession _session = NHibernateTestsConfigurator.BuildSessionForTest();

        private static IRepository<Direction> _iRep = new DirectionRepository(_session);
    }
}
