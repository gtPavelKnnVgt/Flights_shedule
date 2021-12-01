// <copyright file="BookMapTest.cs" company="МИИТ">
// Copyright (c) Кононов П.А. All rights reserved.
// </copyright>

namespace ORM.Tests
{
    using Domain;
    using FluentNHibernate.Testing;
    using NUnit.Framework;

    /// <summary>
    /// Модульные тесты для класса <see cref="ORM.Mappings.BookMap"/>.
    /// </summary>
    [TestFixture]
    public class BookMapTest : BaseMapTests
    {
        [Test]
        public void PersistenceSpecification_ValidSimpleData_Success()
        {
            // arrange
            var passenger = new Passenger(1, "Дюсов", "Михаил");

            // act & assert
            new PersistenceSpecification<Passenger>(this.Session)
                .VerifyTheMappings(passenger);
        }

        [Test]
        public void PersistenceSpecification_ValidComplexData_Success()
        {
            // arrange
            var passenger = new Passenger(1, "Дюсов", "Михаил");
            var direction = new Direction(1, "Москва", "Минск");

            var flight = new Flight(1, 1000, direction, "12:30", "15:00", passenger);

            // act & assert
            new PersistenceSpecification<Passenger>(this.Session)
            
                .VerifyTheMappings(passenger);
        }
    }
}