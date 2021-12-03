// <copyright file="IRepository.cs" company="МИИТ">
// Copyright (c) Кононов П.А. All rights reserved.
// </copyright>

namespace ORM.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Domain;
    using NHibernate;

    /// <summary>
    /// Репозиторий для Рейса.
    /// </summary>
    public class FlightRepository : IRepository<Flight>
    {
        private readonly ISession _session;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="FlightRepository"/>.
        /// </summary>
        /// <param name="session">Сессия для рейсов.</param>
        public FlightRepository(ISession session)
        {
            this._session = session
                ?? throw new ArgumentNullException(nameof(session));
        }

        /// <inheritdoc/>
        public IQueryable<Flight> Filter(Expression<Func<Flight, bool>> predicate)
        {
            return this.GetAll().Where(predicate);
        }

        /// <inheritdoc/>
        public Flight Find(Expression<Func<Flight, bool>> predicate)
        {
            return this.GetAll().FirstOrDefault(predicate);
        }

        /// <inheritdoc/>
        public Flight Get(int id)
        {
            return this._session.Get<Flight>(id);
        }

        /// <inheritdoc/>
        public IQueryable<Flight> GetAll()
        {
            return this._session.Query<Flight>();
        }

        /// <inheritdoc/>
        public bool TryGet(int id, out Flight flight)
        {
            flight = this.GetAll().SingleOrDefault(f => f.FlightNumber == id);
            return flight != null;
        }

        /// <inheritdoc/>
        public Flight Create(Flight flight)
        {
            var id = (int)this._session.Save(flight);
            this._session.Flush();
            return flight;
        }

        /// <inheritdoc/>
        public void Delete(int id)
        {
            if (!this.TryGet(id, out var flight))
            {
                return;
            }

            this._session.Delete(flight);
            this._session.Flush();
        }

        /// <inheritdoc/>
        public void Update(Flight flight)
        {
            this._session.Update(flight);
            this._session.Flush();
        }
    }
}