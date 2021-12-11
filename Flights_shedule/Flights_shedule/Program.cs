// <copyright file="Passenger.cs" company="МИИТ">
// Copyright (c) Дюсов М.А All rights reserved.
// </copyright>

namespace Flights_shedule
{
    using ORM;

    /// <summary>
    /// Исполняемый класс.
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var db = NHibernateConfigurator.GetSessionFactory())
            {
            }
        }
    }
}
