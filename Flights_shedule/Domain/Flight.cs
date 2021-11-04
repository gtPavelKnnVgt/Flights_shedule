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
        /// Initializes a new instance of the <see cref="Flight"/> class.
        /// Инициализирует новый экземпляр класса <see cref="Flight"/>.
        /// </summary>
        /// <param name="flightNumber">Номер рейса.</param>
        /// <param name="ticketPrice">Цена билета.</param>
        /// <param name="direction">Направление.</param>
        /// <param name="departureTime">Время отправления.</param>
        /// <param name="arrivalTime">Время прибытия.</param>
        /// <param name="passengers">Пассажиры рейса.</param>
        public Flight(int flightNumber, int ticketPrice, string direction, string departureTime, string arrivalTime, params Passenger[] passengers)
            : this(flightNumber, ticketPrice, direction, departureTime, arrivalTime, new HashSet<Passenger>(passengers))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Flight"/> class.
        /// Инициализирует новый экземпляр класса <see cref="Flight"/>.
        /// </summary>
        /// <param name="flightNumber">Номер рейса.</param>
        /// <param name="ticketPrice">Цена билета.</param>
        /// <param name="direction">Направление.</param>
        /// <param name="departureTime">Время отправления.</param>
        /// <param name="arrivalTime">Время прибытия.</param>
        /// <param name="passengers">Пассажиры рейса.</param>
        public Flight(int flightNumber, int ticketPrice, string direction, string departureTime, string arrivalTime, ISet<Passenger> passengers = null)
        {
            this.FlightNumber = flightNumber;

            this.TicketPrice = ticketPrice;

            this.Direction = direction.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(direction));

            this.DepartureTime = departureTime.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(departureTime));

            this.ArrivalTime = arrivalTime.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(arrivalTime));

            if (passengers != null)
            {
                foreach (var passenger in passengers)
                {
                    this.Passengers.Add(passenger);
                    passenger.AddFlight(this);
                }
            }
        }

        /// <summary>
        /// Gets or sets номер рейса (уникальный идентификатор).
        /// </summary>
        public int FlightNumber { get; protected set; }

        /// <summary>
        /// Gets or sets список пассажиров.
        /// </summary>
        public ISet<Passenger> Passengers { get; protected set; } = new HashSet<Passenger>();

        /// <summary>
        /// Gets or sets стоимость билета.
        /// </summary>
        public int TicketPrice { get; protected set; }

        /// <summary>
        /// Gets or sets направление.
        /// </summary>
        public string Direction { get; protected set; }

        /// <summary>
        /// Gets or sets время вылета.
        /// </summary>
        public string DepartureTime { get; protected set; }

        /// <summary>
        /// Gets or sets время прилёта.
        /// </summary>
        public string ArrivalTime { get; protected set; }

        /// <summary>
        /// Gets or sets коллекция самолётов.
        /// </summary>
        public ISet<Airplane> Airplanes { get; protected set; } = new HashSet<Airplane>();

        /// <summary>
        /// Добавление самолёта рейсу.
        /// </summary>
        /// <param name="airplane">Добавленный самолёт.</param>
        /// <returns>
        /// <see langword="true"/> если самолёт был добавлен.
        /// </returns>
        public bool AddAirplane(Airplane airplane) =>
            this.Airplanes.TryAdd(airplane) ?? throw new ArgumentNullException(nameof(airplane));

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{this.FlightNumber} {this.Passengers.Join()}";
        }
    }
}
