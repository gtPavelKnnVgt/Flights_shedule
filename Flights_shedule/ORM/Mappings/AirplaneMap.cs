// <copyright file="AirplaneMap.cs" company="МИИТ">
// Copyright (c) Пузаков А. С. All rights reserved.
// </copyright>
namespace ORM.Mappings
{
    using System;
    using Domain;
    using FluentNHibernate.Mapping;

    /// <summary>
    /// Класс, описывающий правила отображения <see cref="Airplane"/> на таблицу и наоборот.
    /// </summary>
    internal class AirplaneMap : ClassMap<Airplane>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="AirplaneMap"/>.
        /// </summary>
        public AirplaneMap()
        {
            this.Table("Airplanes");

            this.Id(x => x.Id);

            this.Map(x => x.Type);
            this.Map(x => x.Size);
            this.Map(x => x.TailNumber);
            this.Map(x => x.TotalWeight);
            this.Map(x => ((char)x.AirplaneClass));
            this.Map(x => x.SeatsCount);
            this.Map(x => x.FlightRange);

            this.HasMany(x => x.Flights).Not.Inverse();
        }
    }
}
