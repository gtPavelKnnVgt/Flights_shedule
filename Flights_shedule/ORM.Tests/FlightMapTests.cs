// <copyright file="BaseMapTests.cs" company="МИИТ">
// Copyright (c) Пузаков А.В. All rights reserved.
// </copyright>

namespace ORM.Tests
{
    using Domain;
    using FluentNHibernate.Testing;
    using NUnit.Framework;

    /// <summary>
    /// Модульные тесты для класса <see cref="Mappings.FlightMap"/>.
    /// </summary>
    [TestFixture]
    public class FlightMapTests : BaseMapTests
    {
        [Test]
        public void PersistenceSpecification_ValidData_Success()
        {
            // arrange
            var passenger = new Passenger(1, "Дюсов", "Михаил");

            var flight = new Flight(1, 1000, "12:30", "15:00", passenger);
            var direction = new Direction(1, "Москва", "Минск", flight);
            var airplane = new Airplane(888, "Military", 350.29, "AA44", 5000.532, AirplaneClasses.A, 286, 10000.252, flight);

            // act & assert
            new PersistenceSpecification<Flight>(this.Session)

                .VerifyTheMappings(flight);
        }
    }
}
