// <copyright file="FlightTests.cs" company="МИИТ">
// Copyright (c) Кононов П. А. All rights reserved.
// </copyright>

namespace Domain.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]

    public class FlightTests
    {
        [Test]
        public void ValidData_MultipulPassengers_ToString_Success()
        {
            var passengers = GeneratePassengers();

            var testFlight = GenerateFlight(passengers);

            var result = testFlight.ToString();

            var expected = "197 KSEA A., AAA B., BBB C.";

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Ctor_EmptyDepartureTime_ThrowsArgumentOutOfRangeException()
        {
            var passengers = GeneratePassengers();
            Assert.Throws<ArgumentOutOfRangeException>(()
                => _ = GenerateFlight(
                    passengers: passengers,
                    flightNumber: 1,
                    ticketPrice: 2000,
                    departureTime: string.Empty,
                    arrivalTime: "15:00"));
        }

        [Test]
        public void Ctor_EmptyArrivalTime_ThrowsArgumentOutOfRangeException()
        {
            var passengers = GeneratePassengers();
            Assert.Throws<ArgumentOutOfRangeException>(()
                => _ = GenerateFlight(
                    passengers: passengers,
                    flightNumber: 1,
                    ticketPrice: 2000,
                    departureTime: "12:30",
                    arrivalTime: string.Empty));
        }

        [Test]
        public void Ctor_FlightNumber_LessThenMinimum_ThrowsArgumentOutOfRangeException()
        {
            var passengers = GeneratePassengers();
            Assert.Throws<ArgumentOutOfRangeException>(()
                => _ = GenerateFlight(
                    passengers: passengers,
                    flightNumber: -1,
                    ticketPrice: 2000,
                    departureTime: "12:30",
                    arrivalTime: "15:00"));
        }

        [Test]
        public void Ctor_TicketPrice_LessThenMinimum_ThrowsArgumentOutOfRangeException()
        {
            var passengers = GeneratePassengers();
            Assert.Throws<ArgumentOutOfRangeException>(()
                => _ = GenerateFlight(
                    passengers: passengers,
                    flightNumber: 1,
                    ticketPrice: -1000,
                    departureTime: "12:30",
                    arrivalTime: "15:00"));
        }

        [Test]
        public void Ctor_TicketPrice_BiggerThenMaximum_ThrowsArgumentOutOfRangeException()
        {
            var passengers = GeneratePassengers();
            Assert.Throws<ArgumentOutOfRangeException>(()
                => _ = GenerateFlight(
                    passengers: passengers,
                    flightNumber: 23,
                    ticketPrice: 200000,
                    departureTime: "12:30",
                    arrivalTime: "15:00"));
        }

        private static Flight GenerateFlight(
            HashSet<Passenger> passengers,
            int flightNumber = 197,
            int ticketPrice = 2000,
            string departureTime = null,
            string arrivalTime = null)
            => new (flightNumber, ticketPrice, departureTime ?? "12:30", arrivalTime ?? "15:00", passengers);

        private static HashSet<Passenger> GeneratePassengers()
        {
            return new HashSet<Passenger>
            {
                new Passenger (id: 1, lastName: "KSEA", firstName: "ASRQW"),
                new Passenger (id: 2, lastName: "AAA", firstName: "BBBB"),
                new Passenger (id: 3, lastName: "BBB", firstName: "CCC"),
            };
        }
    }
}
