// <copyright file="FlightMap.cs" company="МИИТ">
// Copyright (c) Пузаков А. С. All rights reserved.
// </copyright>

namespace ORM.Mappings
{
    using Domain;
    using FluentNHibernate.Mapping;

    /// <summary>
    /// Класс, описывающий правила отображения <see cref="Flight"/> на таблицу и наоборот.
    /// </summary>
    internal class FlightMap : ClassMap<Flight>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="FlightMap"/>.
        /// </summary>
        public FlightMap()
        {
            this.Table("Flights");

            this.Id(x => x.FlightNumber);

            this.Map(x => x.DepartureTime);
            this.Map(x => x.ArrivalTime);
            this.Map(x => x.TicketPrice);

            this.References(x => x.Direction);

            this.References(x => x.Airplane);

            this.HasMany(x => x.Passengers).Inverse();
        }
    }
}
