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
            // arrange
            var airplane = GenerateAirplane();

            // act
            var result = airplane.ToString();

            // assert
            Assert.AreEqual("Common, AA44,A, 286, 5000,25", result);
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

        public void Ctor_WrongData_TotalWeightIsNegative_Fail()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = GenerateAirplane("Mil", 359.24, "ABE231", -590));
        }

        [Test]

        public void Ctor_WrongData_TotalWeightIsNull_Fail()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = GenerateAirplane("Mil", 359.24, "ABE231", 0));
        }

        [Test]

        public void Ctor_WrongData_TotalWeightNotInRange_Fail()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = GenerateAirplane("Mil", 359.24, "ABE231", 100000));
        }

        [Test]

        public void Ctor_WrongData_FlightRangeIsNegative_Fail()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = GenerateAirplane("Mil", 359.24, "ABE231", 100000, 0, 300, -52155));
        }

        [Test]

        public void Ctor_WrongData_FlightRangeIsNull_Fail()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = GenerateAirplane("Mil", 359.24, "ABE231", 100000, 0, 300, 0));
        }

        [Test]

        public void Ctor_WrongData_FlightRangeNotInRange_Fail()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = GenerateAirplane("Mil", 359.24, "ABE231", 100000, 0, 300, 500));
        }

        [Test]

        public void Ctor_WrongData_SeatsCountIsNegative_Fail()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = GenerateAirplane("Mil", 359.24, "ABE231", 100000, 0, -300));
        }

        [Test]

        public void Ctor_WrongData_SeatsCountIsNull_Fail()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = GenerateAirplane("Mil", 359.24, "ABE231", 100000, 0, 0));
        }

        [Test]

        public void Ctor_WrongData_SeatsCountNotInRange_Fail()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = GenerateAirplane("Mil", 359.24, "ABE231", 100000, 0, 50));
        }

        [Test]

        public void Ctor_WrongData_SizeIsNegative_Fail()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = GenerateAirplane("Mil", -359.24, "ABE231", 0));
        }

        [Test]

        public void Ctor_WrongData_SizeIsNull_Fail()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = GenerateAirplane("Mil", 0, "ABE231", 0));
        }

        [Test]
        public void Ctor_ValidData_EmptyPassenger_Success()
        {
            // arrange & act & assert
            Assert.DoesNotThrow(() => _ = GenerateAirplane("MIL", 550.50, "PRE3000"));
        }

        private static Airplane GenerateAirplane(string type = null, double size = 350.29, string tailNumber = null, double totalWeight = 5000.25, AirplaneClasses airplaneClass = AirplaneClasses.A, int seatsCount = 286, double flightRange = 10000.252)
        {
            return new (123, type ?? "Common", size, tailNumber ?? "AA44", totalWeight, airplaneClass, seatsCount, flightRange);
        }
    }
}
