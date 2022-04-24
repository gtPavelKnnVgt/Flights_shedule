// <copyright file="AirplaneTests.cs" company="МИИТ">
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
            var airplane = GenerateAirplane();

            var result = airplane.ToString();

            var expected = "Common, AA44,A, 286, 5000,25";

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Ctor_EmptyType_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = GenerateAirplane(string.Empty));
        }

        [Test]
        public void Ctor_Empty_TailNumber_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(()
                => _ = GenerateAirplane(
                    type: "Mil",
                    size: 12.42,
                    tailNumber: string.Empty));
        }

        [Test]

        public void Ctor_TotalWeight_LessThenMinimum_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(()
                => _ = GenerateAirplane(
                    type: "Mil",
                    size: 359.24,
                    tailNumber: "ABE231",
                    totalWeight: -590));
        }

        [Test]

        public void Ctor_TotalWeight_BiggerThenMaximum_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(()
                => _ = GenerateAirplane(
                    type: "Mil",
                    size: 359.24,
                    tailNumber: "ABE231",
                    totalWeight: 10000));
        }

        [Test]

        public void Ctor_FlightRange_LessThenMinimum_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(()
                => _ = GenerateAirplane(
                    type: "Mil",
                    size: 359.24,
                    tailNumber: "ABE231",
                    totalWeight: 5000,
                    airplaneClass: AirplaneClasses.B,
                    seatsCount: 300,
                    flightRange: -52155));
        }

        [Test]

        public void Ctor_FlightRange_BiggerThenMaximum_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(()
                => _ = GenerateAirplane(
                    type: "Mil",
                    size: 359.24,
                    tailNumber: "ABE231",
                    totalWeight: 5000,
                    airplaneClass: AirplaneClasses.C,
                    seatsCount: 300,
                    flightRange: 30000));
        }

        [Test]

        public void Ctor_SeatsCount_LessThenMinimum_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(()
                => _ = GenerateAirplane(
                    type: "Mil",
                    size: 359.24,
                    tailNumber: "ABE231",
                    totalWeight: 5000,
                    airplaneClass: AirplaneClasses.D,
                    seatsCount: -300));
        }

        [Test]

        public void Ctor_SeatsCount_BiggerThenMaximum_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(()
                => _ = GenerateAirplane(
                    type: "Mil",
                    size: 359.24,
                    tailNumber: "ABE231",
                    totalWeight: 5000,
                    airplaneClass: AirplaneClasses.A,
                    seatsCount: 2000));
        }

        [Test]

        public void Ctor_Size_LessThenMinimum_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(()
                => _ = GenerateAirplane(
                    type: "Mil",
                    size: -359.24,
                    tailNumber: "ABE231",
                    totalWeight: 5000));
        }

        [Test]

        public void Ctor_Size_BiggerThenMaximum_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(()
                => _ = GenerateAirplane(
                    type: "Mil",
                    size: 0,
                    tailNumber: "ABE231",
                    totalWeight: 10000));
        }

        [Test]
        public void Ctor_ValidData_EmptyPassenger_Success()
        {
            Assert.DoesNotThrow(()
                => _ = GenerateAirplane(
                    type: "MIL",
                    size: 550.50,
                    tailNumber: "PRE3000"));
        }

        private static Airplane GenerateAirplane(
            string type = null,
            double size = 350.29,
            string tailNumber = null,
            double totalWeight = 5000.25,
            AirplaneClasses airplaneClass = AirplaneClasses.A,
            int seatsCount = 286,
            double flightRange = 10000.252)
            => new
            (id: 123, type ?? "Common", size, tailNumber ?? "AA44", totalWeight, airplaneClass, seatsCount, flightRange);
    }
}
