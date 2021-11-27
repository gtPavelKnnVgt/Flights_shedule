﻿// <copyright file="AirplaneTests.cs" company="МИИТ">
// Copyright (c) Кононов П. А. All rights reserved.
// </copyright>
namespace Domain.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class AirplaneTests
    {
        [Test]
        public void ValidData_ToString_Success()
        {
            // arrange
            var airplane = GenerateAirplane();

            // act
            var result = airplane.ToString();

            // assert
            Assert.AreEqual("Common, AA44, 286", result);
        }

        [Test]
        public void Ctor_WrongData_EmptyType_Fail()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = GenerateAirplane(string.Empty));
        }

        [Test]
        public void Ctor_WrongData_TailNumber_Fail()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = GenerateAirplane("Mil", 12.42, string.Empty));
        }

        [Test]
        public void Ctor_ValidData_EmptyPassenger_Success()
        {
            // arrange & act & assert
            Assert.DoesNotThrow(() => _ = GenerateAirplane("MIL", 550.50, "PRE3000"));
        }

        private static Airplane GenerateAirplane(string type = null, double size = 350.29, string tailNumber = null, double totalWeight = 145.2,
           char airplaneClass = 'A', int seatsCount = 286, double flightRange = 10000.252)
        {
            return new Airplane(123, type ?? "Common", size, tailNumber ?? "AA44", totalWeight, airplaneClass, seatsCount, flightRange);
        }
    }
}
