// <copyright file="Passenger.cs" company="МИИТ">
// Copyright (c) Дюсов М.А All rights reserved.
// </copyright>
namespace Domain
{
    using System;
    using System.Collections.Generic;
    using Staff.Extentions;
    /// <summary>
    /// Класс пассажира
    /// </summary>
    public class Passenger
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Passenger"/>.
        /// </summary>
        /// <param name="id">Уникальный идентификатор</param>
        /// <param name="lastName">Фамилия</param>
        /// <param name="firstName">Имя</param>
        public Passenger(int id, string lastName, string firstName)
        {
            this.Id = id;

            this.LastName = lastName.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(lastName));

            this.FirstName = firstName.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(firstName));
        }
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        public int Id { get; protected set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; protected set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; protected set; }
        /// <summary>
        /// Полное имя
        /// </summary>
        public string FullName => $"{this.LastName} {this.FirstName[0]}. ".Trim();
        /// <summary>
        /// Номер паспорта
        /// </summary>
        public int Passport { get; protected set; }
        /// <summary>
        /// Коллекция рейсов
        /// </summary>
        public ISet<Flight> Flights { get; protected set; } = new HashSet<Flight>();
        /// <summary>
        /// Добавление рейса пассажиру
        /// </summary>
        /// <param name="flight">Добавляемый рейс</param>
        /// <returns>
        /// <see langword="true"/> если рейс был добавлен.
        /// </returns>
        public bool AddFlight(Flight flight) 
            => this.Flights.TryAdd(flight) ?? throw new ArgumentNullException(nameof(flight));

        public override string ToString() => this.FullName;
    }
}
