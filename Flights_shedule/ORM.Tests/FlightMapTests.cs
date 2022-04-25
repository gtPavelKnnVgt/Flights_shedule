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
            var passenger = new Passenger(id: 1, lastName: "Дюсов", firstName: "Михаил");

            var flight = new Flight(
                flightNumber: 1,
                ticketPrice: 2000,
                departureTime: "12:30",
                arrivalTime: "15:00",
                passengers: passenger);

            // act & assert
            new PersistenceSpecification<Flight>(this.Session)

                .VerifyTheMappings(flight);
        }
    }
}
