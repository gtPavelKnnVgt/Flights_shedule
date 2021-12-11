// <copyright file="Passenger.cs" company="МИИТ">
// Copyright (c) МИИТ. All rights reserved.
// </copyright>

namespace Domain
{
    using System;
    using Staff.Extentions;

    /// <summary>
    /// Класс пассажира.
    /// </summary>
    public class Passenger
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Passenger"/>.
        /// Initializes a new instance of the <see cref="Passenger"/> class.
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
        /// Инициализирует новый экземпляр класса <see cref="Passenger"/>.
        /// </summary>
        [Obsolete("For ORM only", true)]
        protected Passenger()
        {
        }

        /// <summary>
        /// Идентификационный номер пассажира.
        /// </summary>
        public virtual int Id { get; protected set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public virtual string LastName { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public virtual string FirstName { get; set; }

        /// <summary>
        /// Полное имя.
        /// </summary>
        public virtual string FullName => $"{this.LastName} {this.FirstName[0]}. ".Trim();

        /// <summary>
        /// Номер паспорта.
        /// </summary>
        public virtual int Passport { get; protected set; }

        /// <summary>
        /// Рейс.
        /// </summary>
        public virtual Flight Flight { get; protected set; }

        /// <inheritdoc/>
        public override string ToString() => this.FullName;
    }
}
