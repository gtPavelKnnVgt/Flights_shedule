

namespace Domain.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
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

        private static Passenger GeneratePassenger(string secondName = null, string firstName = null)
        {
            return new Passenger(1, secondName ?? "О'Брайен", firstName ?? "Уолтер");
        }

        private static Flight GenerateFlight(int flightNumber = 1, int ticketPrice = 1000, string direction = null,
            string departureTime = null, string arrivalTime = null)
        {
            return new (flightNumber, ticketPrice,
                direction ?? "Москва - Минск",
                departureTime ?? "12:30",
                arrivalTime ?? "15:00");
        }

        private static Airplane GenerateAirplane(string type = null, double size = 350.29, string tailNumber = null, double totalWeight = 145.2,
           char airplaneClass = 'A', int seatsCount = 286, double flightRange = 10000.252)
        {
            return new Airplane(123, type ?? "Common", size, tailNumber ?? "AA44", totalWeight, airplaneClass, seatsCount, flightRange);
        }
    }
}
