// <copyright file="BaseMapTests.cs" company="МИИТ">
// Copyright (c) Кононов П.А. All rights reserved.
// </copyright>
namespace ORM.Tests
{
    using NHibernate;
    using NUnit.Framework;
    using ORM.Mappings;

    /// <summary>
    /// Базовый класс для тестирования маппингов.
    /// </summary>
    public abstract class BaseMapTests
    {
        /// <summary>
        /// Сессия для тестовой БД.
        /// </summary>
        protected ISession Session { get; private set; }

        [SetUp]
        public void Setup()
        {
            this.Session = NHibernateTestsConfigurator.BuildSessionForTest();
        }

        [TearDown]
        public void CloseSession() => this.Session?.Dispose();
    }
}