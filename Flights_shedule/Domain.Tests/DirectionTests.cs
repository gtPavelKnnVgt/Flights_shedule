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
            var direction = GenerateDirection();

            var result = direction.ToString();

            var expected = "Москва-Рязань";

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Ctor_EmptyFrom_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = GenerateDirection(string.Empty));
        }

        [Test]
        public void Ctor_EmptyTo_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = GenerateDirection("Пенза", string.Empty));
        }

        private static Direction GenerateDirection(string from = null, string to = null) => new (id: 1, from ?? "Москва", to ?? "Рязань");
    }
}
