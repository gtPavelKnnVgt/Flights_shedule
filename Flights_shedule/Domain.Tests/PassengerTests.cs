// <copyright file="PassengerTests.cs" company="МИИТ">
// Copyright (c) Кононов П. А. All rights reserved.
// </copyright>

namespace Domain.Tests
{
    using System;
    using Domain;
    using NUnit.Framework;

    [TestFixture]
    public class PassengerTests
    {
        [Test]
        public void ValidData_ToString_Success()
        {
            var passenger = GeneratePassenger();

            var result = passenger.ToString();

            var expected = "О'Брайен У.";

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Ctor_EmptyFirstName_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = GeneratePassenger("О'Брайен", string.Empty));
        }

        [Test]
        public void Ctor_EmptySecondName_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = GeneratePassenger(string.Empty, "Уолтер"));
        }

        [Test]
        public void Ctor_EmptyPassengers_Success()
        {
            Assert.DoesNotThrow(() => _ = GenerateFlight());
        }

        private static Passenger GeneratePassenger(string secondName = null, string firstName = null)
            => new (id: 1, secondName ?? "О'Брайен", firstName ?? "Уолтер");

        private static Flight GenerateFlight(
            int flightNumber = 1,
            int ticketPrice = 2000,
            string departureTime = null,
            string arrivalTime = null)
            => new (flightNumber, ticketPrice, departureTime ?? "12:30", arrivalTime ?? "15:00");
    }
}