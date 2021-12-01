// <copyright file="DirectionTests.cs" company="МИИТ">
// Copyright (c) Кононов П. А. All rights reserved.
// </copyright>
namespace Domain.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    internal class DirectionTests
    {
        [Test]
        public void ValidData_ToString_Success()
        {
            // arrange
            var direction = GenerateDirection();

            // act
            var result = direction.ToString();

            // assert
            Assert.AreEqual("Москва-Рязань", result);
        }

        [Test]
        public void Ctor_WrongData_EmptyFrom_Fail()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = GenerateDirection(string.Empty));
        }

        [Test]
        public void Ctor_WrongData_EmptyTo_Fail()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = GenerateDirection("Пенза", string.Empty));
        }

        [Test]

        public void Ctor_WrongData__EmptyDirection_Fail()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = GenerateDirection(string.Empty, string.Empty));
        }

        private static Direction GenerateDirection(string from = null, string to = null) => new (1, from ?? "Москва", to ?? "Рязань");
    }
}
