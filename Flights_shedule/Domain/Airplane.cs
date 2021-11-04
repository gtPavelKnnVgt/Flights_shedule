// <copyright file="Airplane.cs" company="МИИТ">
// Copyright (c) Дюсов М.А All rights reserved.
// </copyright>
namespace Domain
{
    using System;
    using System.Collections.Generic;
    using Staff.Extentions;

    /// <summary>
    /// Самолёт.
    /// </summary>
    public class Airplane
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Airplane"/> class.
        /// Инициализирует новый экземпляр класса <see cref="Airplane"/>.
        /// </summary>
        /// <param name="id">Уникальный идентификатор.</param>
        /// <param name="type">Тип самолёта.</param>
        /// <param name="size">Размер самолёта.</param>
        /// <param name="tailNumber">Бортовой номер.</param>
        /// <param name="totalWeight">Общая масса самолёта.</param>
        /// <param name="airplaneClass">Класс самолёта.</param>
        /// <param name="seatsCount">Количество мест.</param>
        /// <param name="flightRange">Дальность полёта.</param>
        /// <param name="flights">Рейсы, на которых летает данный самолёт.</param>
        public Airplane(int id, string type, double size, string tailNumber, double totalWeight, char airplaneClass, int seatsCount, double flightRange, ISet<Flight> flights = null)
        {
            this.Id = id;

            this.Type = type.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(type));

            this.Size = size;

            this.TailNumber = tailNumber.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(tailNumber));

            this.TotalWeight = totalWeight;

            this.AirplaneClass = airplaneClass;

            this.SeatsCount = seatsCount;

            this.FlightRange = flightRange;

            if (flights != null)
            {
                foreach (var flight in flights)
                {
                    this.Flights.Add(flight);
                    flight.AddAirplane(this);
                }
            }
        }

        /// <summary>
        /// Gets or sets уникальный индентификатор.
        /// </summary>
        public int Id { get; protected set; }

        /// <summary>
        /// Gets or sets тип самолёта.
        /// </summary>
        public string Type { get; protected set; }

        /// <summary>
        /// Gets or sets размер самолёта.
        /// </summary>
        public double Size { get; protected set; }

        /// <summary>
        /// Gets or sets бортовой номер.
        /// </summary>
        public string TailNumber { get; protected set; }

        /// <summary>
        /// Gets or sets общая масса.
        /// </summary>
        public double TotalWeight { get; protected set; }

        /// <summary>
        /// Gets or sets список классов самолёта.
        /// </summary>
        public char AirplaneClass { get; protected set; }

        /// <summary>
        /// Gets or sets количество мест в самолёте.
        /// </summary>
        public int SeatsCount { get; protected set; }

        /// <summary>
        /// Gets or sets дальность полёта.
        /// </summary>
        public double FlightRange { get; protected set; }

        /// <summary>
        /// Gets or sets коллекция рейсов.
        /// </summary>
        public ISet<Flight> Flights { get; protected set; } = new HashSet<Flight>();
    }
}
