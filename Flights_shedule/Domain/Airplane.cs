// <copyright file="Airplane.cs" company="МИИТ">
// Copyright (c) Дюсов М. А. All rights reserved.
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
        /// Инициализирует новый экземпляр класса <see cref="Airplane"/>.
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

            this.Size = size.NullOrNegative() ?? throw new ArgumentOutOfRangeException(nameof(size));

            this.TailNumber = tailNumber.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(tailNumber));

            this.TotalWeight = totalWeight.NullOrNegative()?.WeightCheck() ?? throw new ArgumentOutOfRangeException(nameof(totalWeight));

            this.AirplaneClass = airplaneClass;

            this.SeatsCount = seatsCount.NullOrNegative()?.SeatRange() ?? throw new ArgumentOutOfRangeException(nameof(seatsCount));

            this.FlightRange = flightRange.NullOrNegative()?.FlightRangeCheck() ?? throw new ArgumentOutOfRangeException(nameof(flightRange));

            if (flights != null)
            {
                foreach (var flight in flights)
                {
                    this.Flights.Add(flight);
                }
            }
        }

        /// <summary>
        /// Уникальный индентификатор.
        /// </summary>
        public int Id { get; protected set; }

        /// <summary>
        /// Общая информация.
        /// </summary>
        public string CommonInfo => $"{this.Type}, {this.TailNumber}, {this.SeatsCount}, {this.TotalWeight} ".Trim();

        /// <summary>
        /// Тип самолёта.
        /// </summary>
        public string Type { get; protected set; }

        /// <summary>
        /// Размер самолёта.
        /// </summary>
        public double Size { get; protected set; }

        /// <summary>
        /// Бортовой номер.
        /// </summary>
        public string TailNumber { get; protected set; }

        /// <summary>
        /// Общая масса.
        /// </summary>
        public double TotalWeight { get; protected set; }

        /// <summary>
        /// Список классов самолёта.
        /// </summary>
        public char AirplaneClass { get; protected set; }

        /// <summary>
        /// Количество мест в самолёте.
        /// </summary>
        public int SeatsCount { get; protected set; }

        /// <summary>
        /// Дальность полёта.
        /// </summary>
        public double FlightRange { get; protected set; }

        /// <summary>
        /// Коллекция рейсов.
        /// </summary>
        public ISet<Flight> Flights { get; protected set; } = new HashSet<Flight>();

        /// <inheritdoc/>
        public override string ToString() => this.CommonInfo;
    }
}
