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
            var direction = new Direction(id: 1, startLocation: "Москва", endLocation: "Минск");

            // act & assert
            new PersistenceSpecification<Direction>(this.Session)
                .VerifyTheMappings(direction);
        }

        [Test]
        public void PersistenceSpecification_ValidComplexData_Success()
        {
            // arrange
            var passenger = new Passenger(id: 1, lastName: "Дюсов", firstName: "Михаил");
            var direction = new Direction(id: 1, startLocation: "Москва", endLocation: "Минск");

            // act & assert
            new PersistenceSpecification<Direction>(this.Session)

                .VerifyTheMappings(direction);
        }
    }
}
