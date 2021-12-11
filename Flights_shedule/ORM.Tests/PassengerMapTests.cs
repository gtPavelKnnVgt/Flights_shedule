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
            var passenger = new Passenger(1, "�����", "������");

            // act & assert
            new PersistenceSpecification<Passenger>(this.Session)
                .VerifyTheMappings(passenger);
        }

        [Test]
        public void PersistenceSpecification_ValidComplexData_Success()
        {
            // arrange
            var passenger = new Passenger(1, "�����", "������");

            var flight = new Flight(1, 1000, "12:30", "15:00", passenger);
            var direction = new Direction(1, "������", "�����", flight);

            // act & assert
            new PersistenceSpecification<Passenger>(this.Session)

                .VerifyTheMappings(passenger);
        }
    }
}