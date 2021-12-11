// <copyright file="NHibernateConfigurator.cs" company="МИИТ">
// Copyright (c) Дюсов М.А All rights reserved.
// </copyright>

namespace ORM
{
    using System.Reflection;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using NHibernate;
    using NHibernate.Cfg;
    using NHibernate.Tool.hbm2ddl;

    /// <summary>
    /// Класс для настройки NHibernate.
    /// </summary>
    public static class NHibernateConfigurator
    {
        /// <summary>
        /// Конфигурация.
        /// </summary>
        private static FluentConfiguration fluentConfiguration;

        /// <summary>
        /// Фабрика сессий (<see cref = "ISessionFactory"/>).
        /// </summary>
        /// <param name="assembly"> Целевая сборка. </param>
        /// <param name="showSql"> Показывать генерируемый SQL-код. </param>
        /// <returns> Фабрику сессий. </returns>
        public static ISessionFactory GetSessionFactory(Assembly assembly = null, bool showSql = false)
        {
            return GetConfiguration(assembly ?? Assembly.GetExecutingAssembly(), showSql)
                .BuildSessionFactory();
        }

        private static IPersistenceConfigurer GetDevelopPersistenceConfigurer(bool showSql = false)
        {
            var databaseConfiguration = MsSqlConfiguration.MsSql2012.ConnectionString(
                x => x
                    .Server(@"PAVEL") // вставить наши данные
                    .Database("FlightShedule") // вставить наши данные
                    .TrustedConnection());

            if (showSql)
            {
                databaseConfiguration = databaseConfiguration.ShowSql().FormatSql();
            }

            return databaseConfiguration;
        }

        private static IPersistenceConfigurer GetTestsPersistenceConfigurer(bool showSql = false)
        {
            var databaseConfiguration = SQLiteConfiguration.Standard.InMemory();

            if (showSql)
            {
                databaseConfiguration = databaseConfiguration.ShowSql().FormatSql();
            }

            return databaseConfiguration;
        }

        /// <summary>
        /// Метод, который создает конфигурацию по сборке.
        /// </summary>
        /// <param name="assembly"> Целевая сборка. </param>
        /// <param name="tests"> Флаг, показывающий тест </param>
        /// <param name="showSql"> Показывать ли SQL-код. </param>
        /// <returns> Конфигурацию. </returns>
        private static FluentConfiguration GetConfiguration(Assembly assembly, bool tests = false, bool showSql = false)
        {
            if (fluentConfiguration is not null)
            {
                return fluentConfiguration;
            }

            var databaseConfiguration = tests
                ? GetTestsPersistenceConfigurer(showSql)
                : GetDevelopPersistenceConfigurer(showSql);

            fluentConfiguration = Fluently.Configure()
                .Database(databaseConfiguration)
                .Mappings(m => m.FluentMappings.AddFromAssembly(assembly))
                .ExposeConfiguration(BuildSchema);

            return fluentConfiguration;
        }

        /// <summary>
        /// Метод, который создает таблицы, если их не было в схеме по конфигурации.
        /// </summary>
        /// <param name="configuration"> Конфигурация ORM, которая содержит правила отображения.</param>
        private static void BuildSchema(Configuration configuration)
        {
            new SchemaExport(configuration).Execute(true, true, false);
        }
    }
}
