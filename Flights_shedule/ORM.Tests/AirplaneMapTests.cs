// <copyright file="BaseMapTests.cs" company="МИИТ">
// Copyright (c) Пузаков А.В. All rights reserved.
// </copyright>

namespace ORM.Tests
{
    using Domain;
    using FluentNHibernate.Testing;
    using NUnit.Framework;

    /// <summary>
    /// Модульные тесты для класса <see cref="Mappings.AirplaneMap"/>.
    /// </summary>
    [TestFixture]
    public class AirplaneMapTests : BaseMapTests
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

            var airplane = new Airplane(
                id: 888,
                type: "Military",
                size: 350.29,
                tailNumber: "AA44",
                totalWeight: 5000.532,
                airplaneClass: AirplaneClasses.A,
                seatsCount: 286,
                flightRange: 10000.252,
                flights: flight);

            // act & assert
            new PersistenceSpecification<Airplane>(this.Session)

                .VerifyTheMappings(airplane);
        }
    }
}
