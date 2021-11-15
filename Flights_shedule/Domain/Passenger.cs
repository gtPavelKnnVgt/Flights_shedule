// <copyright file="Passenger.cs" company="МИИТ">
// Copyright (c) Дюсов М.А All rights reserved.
// </copyright>
namespace Domain
{
    using System;
    using System.Collections.Generic;
    using Staff.Extentions;

    /// <summary>
    /// Класс пассажира.
    /// </summary>
    public class Passenger
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Passenger"/> class.
        /// Инициализирует новый экземпляр класса <see cref="Passenger"/>.
        /// </summary>
        /// <param name="id">Уникальный идентификатор.</param>
        /// <param name="lastName">Фамилия.</param>
        /// <param name="firstName">Имя.</param>
        public Passenger(int id, string lastName, string firstName)
        {
            this.Id = id;

            this.LastName = lastName.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(lastName));

            this.FirstName = firstName.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(firstName));
        }

        /// <summary>
        /// Gets or sets уникальный идентификатор.
        /// </summary>
        public int Id { get; protected set; }

        /// <summary>
        /// Gets or sets фамилия.
        /// </summary>
        public string LastName { get; protected set; }

        /// <summary>
        /// Gets or sets имя.
        /// </summary>
        public string FirstName { get; protected set; }

        /// <summary>
        /// Gets полное имя.
        /// </summary>
        public string FullName => $"{this.LastName} {this.FirstName[0]}. ".Trim();

        /// <summary>
        /// Gets or sets номер паспорта.
        /// </summary>
        public int Passport { get; protected set; }

        public int FlightId { get; protected set; }
        public Flight Flight { get; protected set; }

        /// <inheritdoc/>
        public override string ToString() => this.FullName;
    }
}
