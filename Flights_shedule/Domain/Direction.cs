// <copyright file="Direction.cs" company="МИИТ">
// Copyright (c) Дюсов М. А. All rights reserved.
// </copyright>

namespace Domain
{
    using System;
    using System.Collections.Generic;
    using Staff.Extentions;

    /// <summary>
    /// Класс направления.
    /// </summary>
    public class Direction
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Direction"/>.
        /// </summary>
        /// <param name="id">Уникальный идентификатор.</param>
        /// <param name="startLocation">Город вылета.</param>
        /// <param name="endLocation">Город прилёта.</param>
        /// <param name="flights">Рейсы имеющие данное направление.</param>
        public Direction(
            int id,
            string startLocation,
            string endLocation,
            params Flight[] flights)
            : this(id, startLocation, endLocation, new HashSet<Flight>(flights))
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Direction"/>.
        /// </summary>
        /// <param name="id">Уникальный идентификатор.</param>
        /// <param name="startLocation">Город вылета.</param>
        /// <param name="endLocation">Город прилёта.</param>
        /// <param name="flights">Рейсы имеющие данное направление.</param>
        public Direction(
            int id,
            string startLocation,
            string endLocation,
            ISet<Flight> flights = null)
        {
            this.Id = id;

            this.StartLocation = startLocation.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(startLocation));

            this.EndLocation = endLocation.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(endLocation));

            if (flights != null)
            {
                foreach (var flight in flights)
                {
                    this.Flights.Add(flight);
                }
            }
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Direction"/>.
        /// </summary>
        [Obsolete("For ORM only", true)]
        protected Direction()
        {
        }

        /// <summary>
        /// Уникальный индентификатор.
        /// </summary>
        public virtual int Id { get; protected set; }

        /// <summary>
        /// Город вылета.
        /// </summary>
        public virtual string StartLocation { get; set; }

        /// <summary>
        /// Город прилёта.
        /// </summary>
        public virtual string EndLocation { get; set; }

        /// <summary>
        /// Коллекция Рейсов.
        /// </summary>
        public virtual ISet<Flight> Flights { get; set; } = new HashSet<Flight>();

        /// <inheritdoc/>
        public override string ToString() => $"{this.StartLocation}-{this.EndLocation}";
    }
}
