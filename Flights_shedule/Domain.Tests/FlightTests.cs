// <copyright file="FlightTests.cs" company="МИИТ">
// Copyright (c) Кононов П. А. All rights reserved.
// </copyright>
namespace Domain.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]

    public class FlightTests
    {
        [Test]
        public void ValidData_ToString_Success()
        {
            // arrange
            var passenger = GeneratePassenger();
            var testFlight = GenerateFlight(passenger);

            // act
            var result = testFlight.ToString();

            // assert
            Assert.AreEqual("197 О'Брайен У.", result);
        }

        [Test]
        public void Ctor_WrongData_EmptyDirection_Fail()
        {
            var passenger = GeneratePassenger();
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = GenerateFlight(passenger, 1, 1000, string.Empty, "12:30", "15:00"));
        }

        [Test]
        public void Ctor_WrongData_EmptyDepartureTime_Fail()
        {
            var passenger = GeneratePassenger();
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = GenerateFlight(passenger, 1, 1000, "Москва - Минск", string.Empty, "15:00"));
        }

        [Test]
        public void Ctor_WrongData_EmptyArrivalTime_Fail()
        {
            var passenger = GeneratePassenger();
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = GenerateFlight(passenger, 1, 1000, "Москва - Минск", "12:30", string.Empty));
        }

        [Test]
        public void Ctor_WrongData_FlightNumberIsNegative_Fail()
        {
            var passenger = GeneratePassenger();
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = GenerateFlight(passenger, -1, 1000, string.Empty, "12:30", "15:00"));
        }

        [Test]
        public void Ctor_WrongData_FlightNumberIsNull_Fail()
        {
            var passenger = GeneratePassenger();
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = GenerateFlight(passenger, 0, 1000, string.Empty, "12:30", "15:00"));
        }

        [Test]
        public void Ctor_WrongData_TicketPriceisNegative_Fail()
        {
            var passenger = GeneratePassenger();
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = GenerateFlight(passenger, 1, -1000, string.Empty, "12:30", "15:00"));
        }

        [Test]
        public void Ctor_WrongData_TicketPriceIsNull_Fail()
        {
            var passenger = GeneratePassenger();
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = GenerateFlight(passenger, 1, 0, string.Empty, "12:30", "15:00"));
        }

        private static Flight GenerateFlight(Passenger passenger, int flightNumber = 197, int ticketPrice = 1000, string direction = null,
           string departureTime = null, string arrivalTime = null)
        {
            return new Flight(flightNumber, ticketPrice,
               direction ?? "Москва - Минск",
               departureTime ?? "12:30",
               arrivalTime ?? "15:00", passenger);
        }

        private static Passenger GeneratePassenger(string secondName = null, string firstName = null) => new Passenger(1, secondName ?? "О'Брайен", firstName ?? "Уолтер");

        private static Airplane GenerateAirplane(string type = null, double size = 350.29, string tailNumber = null, double totalWeight = 145.2,
            char airplaneClass = 'A', int seatsCount = 286, double flightRange = 10000.252)
        {
            return new Airplane(123, type ?? "Common", size, tailNumber ?? "AA44", totalWeight, airplaneClass, seatsCount, flightRange);
        }
    }
}
