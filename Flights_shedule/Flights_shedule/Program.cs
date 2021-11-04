﻿// <copyright file="Passenger.cs" company="МИИТ">
// Copyright (c) Дюсов М.А All rights reserved.
// </copyright>
namespace Flights_shedule
{
    using System;
    class Program
    {
        static void Main(string[] args)
        {
            var passenger = new Domain.Passenger(1, "Дюсов", "Михаил");
            var flight = new Domain.Flight(1, 1000, "Москва - Минск", "12:30", "15:00", passenger);
            passenger.AddFlight(flight);

            Console.WriteLine($"{flight}");
            Console.WriteLine($"{ passenger}");
        }
    }
}
