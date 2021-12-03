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
        private ISession _session;

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
    }
}