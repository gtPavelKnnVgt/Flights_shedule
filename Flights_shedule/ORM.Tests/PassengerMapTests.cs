// <copyright file="BookMapTest.cs" company="����">
// Copyright (c) ������� �.�. All rights reserved.
// </copyright>

namespace ORM.Tests
{
    using Domain;
    using FluentNHibernate.Testing;
    using NUnit.Framework;

    /// <summary>
    /// ��������� ����� ��� ������ <see cref="Mappings.PassengerMap"/>.
    /// </summary>
    [TestFixture]
    public class PassengerMapTests : BaseMapTests
    {
        [Test]
        public void PersistenceSpecification_ValidSimpleData_Success()
        {
            // arrange
            var passenger = new Passenger(id: 1, lastName: "�����", firstName: "������");

            // act & assert
            new PersistenceSpecification<Passenger>(this.Session)
                .VerifyTheMappings(passenger);
        }

        [Test]
        public void PersistenceSpecification_ValidComplexData_Success()
        {
            // arrange
            var passenger = new Passenger(id: 1, lastName: "�����", firstName: "������");

            var flight = new Flight(
                flightNumber: 1,
                ticketPrice: 2000,
                departureTime: "12:30",
                arrivalTime: "15:00",
                passengers: passenger);

            // act & assert
            new PersistenceSpecification<Passenger>(this.Session)

                .VerifyTheMappings(passenger);
        }
    }
}