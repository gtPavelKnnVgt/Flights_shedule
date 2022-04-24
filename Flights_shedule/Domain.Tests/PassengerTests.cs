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
            // arrange
            var passenger = GeneratePassenger();

            // act
            var result = passenger.ToString();

            // assert
            Assert.AreEqual("О'Брайен У.", result);
        }

        [Test]
        public void Ctor_WrongData_EmptyFirstName_Fail()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = GeneratePassenger("О'Брайен", string.Empty));
        }

        [Test]
        public void Ctor_WrongData_EmptySecondName_Fail()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = GeneratePassenger(string.Empty, "Уолтер"));
        }

        [Test]
        public void Ctor_ValidData_EmptyPassenger_Success()
        {
            // arrange & act & assert
            Assert.DoesNotThrow(() => _ = GenerateFlight(900));
        }

        private static Passenger GeneratePassenger(string secondName = null, string firstName = null) => new (1, secondName ?? "О'Брайен", firstName ?? "Уолтер");

        private static Flight GenerateFlight(int flightNumber = 1, int ticketPrice = 2000, string departureTime = null, string arrivalTime = null)
        {
            return new (
                    flightNumber, ticketPrice,
                    departureTime ?? "12:30",
                    arrivalTime ?? "15:00");
        }
    }
}