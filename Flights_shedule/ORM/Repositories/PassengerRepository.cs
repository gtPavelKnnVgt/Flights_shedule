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
    /// Репозиторий для Пассажиров.
    /// </summary>
    public class PassengerRepository : IRepository<Passenger>
    {
        private ISession session;

        public PassengerRepository(ISession session)
        {
            this.session = session
                ?? throw new ArgumentNullException(nameof(session));
        }

        /// <inheritdoc/>
        public IQueryable<Passenger> Filter(Expression<Func<Passenger, bool>> predicate)
        {
            return this.GetAll().Where(predicate);
        }

        /// <inheritdoc/>
        public Passenger Find(Expression<Func<Passenger, bool>> predicate)
        {
            return this.GetAll().FirstOrDefault(predicate);
        }

        /// <inheritdoc/>
        public Passenger Get(int id)
        {
            return this.session.Get<Passenger>(id);
        }

        /// <inheritdoc/>
        public IQueryable<Passenger> GetAll()
        {
            return this.session.Query<Passenger>();
        }
    }
}