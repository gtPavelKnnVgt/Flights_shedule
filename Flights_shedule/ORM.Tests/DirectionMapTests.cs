// <copyright file="BaseMapTests.cs" company="МИИТ">
// Copyright (c) Пузаков А.В. All rights reserved.
// </copyright>

namespace ORM.Tests
{
    using Domain;
    using FluentNHibernate.Testing;
    using NUnit.Framework;

    /// <summary>
    /// Модульные тесты для класса <see cref="Mappings.DirectionMap"/>.
    /// </summary>
    [TestFixture]
    public class DirectionMapTests : BaseMapTests
    {
        [Test]
        public void PersistenceSpecification_ValidSimpleData_Success()
        {
            // arrange
            var direction = new Direction(1, "Москва", "Минск");

            // act & assert
            new PersistenceSpecification<Direction>(this.Session)
                .VerifyTheMappings(direction);
        }

        [Test]
        public void PersistenceSpecification_ValidComplexData_Success()
        {
            // arrange
            var passenger = new Passenger(1, "Дюсов", "Михаил");
            var direction = new Direction(1, "Москва", "Минск");

            var flight = new Flight(1, 1000, "12:30", "15:00", passenger);

            // act & assert
            new PersistenceSpecification<Direction>(this.Session)

                .VerifyTheMappings(direction);
        }
    }
}
