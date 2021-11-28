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
        public Direction(string from, string to)
        {
            this.From = from.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(from));

            this.To = to.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(to));
        }

        /// <summary>
        /// Город вылета.
        /// </summary>
        public string From { get; protected set; }

        /// <summary>
        /// Город прилёта.
        /// </summary>
        public string To { get; protected set; }

        /// <inheritdoc/>
        public override string ToString() => $"{this.From}-{this.To}";
    }
}
