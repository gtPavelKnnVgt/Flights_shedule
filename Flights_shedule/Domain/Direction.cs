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
        /// <param name="from">Город вылета.</param>
        /// <param name="to">Город прилёта.</param>
        public Direction(int id, string startLocation, string endLocation)
        {
            this.Id = id;

            this.startLocation = startLocation.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(startLocation));

            this.endLocation = endLocation.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(endLocation));
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
        public virtual string startLocation { get; protected set; }

        /// <summary>
        /// Город прилёта.
        /// </summary>
        public virtual string endLocation { get; protected set; }

        /// <summary>
        /// Коллекция Рейсов.
        /// </summary>
        public virtual ISet<Flight> Flights { get; protected set; } = new HashSet<Flight>();

        /// <inheritdoc/>
        public override string ToString() => $"{this.startLocation}-{this.endLocation}";
    }
}
