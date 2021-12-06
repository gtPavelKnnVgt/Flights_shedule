// <copyright file=Flight.cs" company="МИИТ">
// Copyright (c) Дюсов М.А All rights reserved.
// </copyright>
namespace Domain
{
    using System;
    using System.Collections.Generic;
    using Staff.Extentions;

    /// <summary>
    /// Класс рейса.
    /// </summary>
    public class Flight
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Flight"/>.
        /// Initializes a new instance of the <see cref="Flight"/> class.
        /// Инициализирует новый экземпляр класса <see cref="Flight"/>.
        /// </summary>
        /// <param name="flightNumber">Номер рейса.</param>
        /// <param name="ticketPrice">Цена билета.</param>
        /// <param name="departureTime">Время отправления.</param>
        /// <param name="arrivalTime">Время прибытия.</param>
        /// <param name="passengers">Пассажиры рейса.</param>
        public Flight(int flightNumber, int ticketPrice, string departureTime, string arrivalTime, params Passenger[] passengers)
            : this(flightNumber, ticketPrice, departureTime, arrivalTime, new HashSet<Passenger>(passengers))
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Flight"/>.
        /// Initializes a new instance of the <see cref="Flight"/> class.
        /// Инициализирует новый экземпляр класса <see cref="Flight"/>.
        /// </summary>
        /// <param name="flightNumber">Номер рейса.</param>
        /// <param name="ticketPrice">Цена билета.</param>
        /// <param name="departureTime">Время отправления.</param>
        /// <param name="arrivalTime">Время прибытия.</param>
        /// <param name="passengers">Пассажиры рейса.</param>
        public Flight(int flightNumber, int ticketPrice, string departureTime, string arrivalTime, ISet<Passenger> passengers = null)
        {
            this.FlightNumber = flightNumber.NullOrNegative() ?? throw new ArgumentOutOfRangeException(nameof(flightNumber));

            this.TicketPrice = ticketPrice.NullOrNegative() ?? throw new ArgumentOutOfRangeException(nameof(ticketPrice));


            this.DepartureTime = departureTime.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(departureTime));

            this.ArrivalTime = arrivalTime.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(arrivalTime));

            if (passengers != null)
            {
                foreach (var passenger in passengers)
                {
                    this.Passengers.Add(passenger);
                }
            }
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Flight"/>.
        /// </summary>
        [Obsolete("For ORM only", true)]
        protected Flight()
        {
        }

        /// <summary>
        /// Номер рейса (уникальный идентификатор).
        /// </summary>
        public virtual int FlightNumber { get; protected set; }

        /// <summary>
        /// Список пассажиров.
        /// </summary>
        public virtual ISet<Passenger> Passengers { get; set; } = new HashSet<Passenger>();

        /// <summary>
        /// Стоимость билета.
        /// </summary>
        public virtual int TicketPrice { get; protected set; }

        /// <summary>
        /// Направление.
        /// </summary>
        public virtual Direction Direction { get; protected set; }

        /// <summary>
        /// Время вылета.
        /// </summary>
        public virtual string DepartureTime { get; set; }

        /// <summary>
        /// Время прилёта.
        /// </summary>
        public virtual string ArrivalTime { get; set; }

        /// <summary>
        /// Самолёт.
        /// </summary>
        public virtual Airplane Airplane { get; protected set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{this.FlightNumber} {this.Passengers.Join()}";
        }
    }
}
