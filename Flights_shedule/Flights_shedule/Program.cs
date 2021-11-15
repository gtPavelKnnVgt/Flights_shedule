// <copyright file="Passenger.cs" company="МИИТ">
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
            var airplane = new Domain.Airplane(888, "Military", 350.29, "AA44", 145.2, 'A', 286, 10000.252);
            Console.WriteLine($"{flight}");
            Console.WriteLine($"{ passenger}");
            Console.WriteLine($"{ airplane}");
        }
    }
}
