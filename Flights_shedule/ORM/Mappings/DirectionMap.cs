// <copyright file="AirplaneMap.cs" company="МИИТ">
// Copyright (c) Кононов П. А. All rights reserved.
// </copyright>

namespace ORM.Mappings
{
    using Domain;
    using FluentNHibernate.Mapping;

    /// <summary>
    /// Класс, описывающий правила отображения <see cref="Direction"/> на таблицу и наоборот.
    /// </summary>
    internal class DirectionMap : ClassMap<Direction>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="DirectionMap"/>.
        /// </summary>
        public DirectionMap()
        {
            this.Table("Direction");
            this.Id(x => x.Id);
            this.Map(x => x.startLocation);
            this.Map(x => x.endLocation);

            this.HasMany(x => x.Flights);
        }
    }
}
