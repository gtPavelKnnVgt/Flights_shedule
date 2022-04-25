// <copyright file="Airplane.cs" company="МИИТ">
// Copyright (c) Дюсов М. А. All rights reserved.
// </copyright>

namespace Domain
{
    using System;
    using System.Collections.Generic;
    using Staff.Extentions;

    /// <summary>
    /// Перечисление классификаторов самолёта
    /// </summary>
    public enum AirplaneClasses
    {
        /// <summary>
        /// Класс А. Размах крыла < 15 м.
        /// </summary>
        A = 'A',

        /// <summary>
        /// Класс B. Размах крыла = 15-24 м.
        /// </summary>
        B = 'B',

        /// <summary>
        /// Класс C. Размах крыла = 24-36 м.
        /// </summary>
        C = 'C',

        /// <summary>
        /// Класс D. Размах крыла = 36-52 м.
        /// </summary>
        D = 'D',

        /// <summary>
        /// Класс E. Размах крыла = 52-65 м.
        /// </summary>
        E = 'E',

        /// <summary>
        /// Класс F. Размах крыла = 65-80 м.
        /// </summary>
        F = 'F',
    }

    /// <summary>
    /// Самолёт.
    /// </summary>
    public class Airplane
    {

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Airplane"/>.
        /// </summary>
        /// <param name="id">Уникальный идентификатор.</param>
        /// <param name="type">Тип самолёта.</param>
        /// <param name="size">Размер самолёта.</param>
        /// <param name="tailNumber">Бортовой номер.</param>
        /// <param name="totalWeight">Общая масса самолёта.</param>
        /// <param name="airplaneClass">Классификатор самолёта.</param>
        /// <param name="seatsCount">Количество мест.</param>
        /// <param name="flightRange">Дальность полёта.</param>
        /// <param name="flights">Рейсы, на которых летает данный самолёт.</param>
        public Airplane(
            int id,
            string type,
            double size,
            string tailNumber,
            double totalWeight,
            AirplaneClasses airplaneClass,
            int seatsCount,
            double flightRange,
            params Flight[] flights)
            : this(id, type, size, tailNumber, totalWeight, airplaneClass, seatsCount, flightRange, new HashSet<Flight>(flights))
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Airplane"/>.
        /// </summary>
        /// <param name="id">Уникальный идентификатор.</param>
        /// <param name="type">Тип самолёта.</param>
        /// <param name="size">Размер самолёта.</param>
        /// <param name="tailNumber">Бортовой номер.</param>
        /// <param name="totalWeight">Общая масса самолёта.</param>
        /// <param name="airplaneClass">Классификатор самолёта.</param>
        /// <param name="seatsCount">Количество мест.</param>
        /// <param name="flightRange">Дальность полёта.</param>
        /// <param name="flights">Рейсы, на которых летает данный самолёт.</param>
        public Airplane(
            int id,
            string type,
            double size,
            string tailNumber,
            double totalWeight,
            AirplaneClasses airplaneClass,
            int seatsCount,
            double flightRange,
            ISet<Flight> flights = null)
        {
            this.Id = id;

            this.Type = type.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(type));

            this.Size = size.IsPassedSizeCheck() ? size : throw new ArgumentOutOfRangeException(nameof(size));

            this.TailNumber = tailNumber.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(tailNumber));

            this.TotalWeight = totalWeight.IsPassedWeightCheck() ? totalWeight : throw new ArgumentOutOfRangeException(nameof(totalWeight));

            this.AirplaneClass = airplaneClass;

            this.SeatsCount = seatsCount.IsPassedSeatRange() ? seatsCount : throw new ArgumentOutOfRangeException(nameof(seatsCount));

            this.FlightRange = flightRange.IsPassedFlightRangeCheck() ? flightRange : throw new ArgumentOutOfRangeException(nameof(flightRange));

            if (flights != null)
            {
                foreach (var flight in flights)
                {
                    this.Flights.Add(flight);
                }
            }
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Airplane"/>.
        /// </summary>
        [Obsolete("For ORM only", true)]
        protected Airplane()
        {
        }

        /// <summary>
        /// Уникальный индентификатор.
        /// </summary>
        public virtual int Id { get; protected set; }

        /// <summary>
        /// Общая информация.
        /// </summary>
        public virtual string CommonInfo => $"{this.Type}, {this.TailNumber},{this.AirplaneClass}, {this.SeatsCount}, {this.TotalWeight} ".Trim();

        /// <summary>
        /// Тип самолёта.
        /// </summary>
        public virtual string Type { get; protected set; }

        /// <summary>
        /// Размер самолёта.
        /// </summary>
        public virtual double Size { get; protected set; }

        /// <summary>
        /// Бортовой номер.
        /// </summary>
        public virtual string TailNumber { get; set; }

        /// <summary>
        /// Общая масса.
        /// </summary>
        public virtual double TotalWeight { get; protected set; }

        /// <summary>
        /// Количество мест в самолёте.
        /// </summary>
        public virtual int SeatsCount { get; protected set; }

        /// <summary>
        /// Дальность полёта.
        /// </summary>
        public virtual double FlightRange { get; protected set; }

        /// <summary>
        /// Коллекция рейсов.
        /// </summary>
        public virtual ISet<Flight> Flights { get; set; } = new HashSet<Flight>();

        /// <summary>
        /// Класс самолета.
        /// </summary>
        public virtual AirplaneClasses AirplaneClass { get; protected set; }

        /// <inheritdoc/>
        public override string ToString() => this.CommonInfo;
    }
}
