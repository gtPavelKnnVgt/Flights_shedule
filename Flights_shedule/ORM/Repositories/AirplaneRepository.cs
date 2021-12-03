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
    /// Репозиторий для Самолёта.
    /// </summary>
    public class AirplaneRepository : IRepository<Airplane>
    {
        private ISession _session;

        public AirplaneRepository(ISession session)
        {
            this._session = session
                ?? throw new ArgumentNullException(nameof(session));
        }

        /// <inheritdoc/>
        public IQueryable<Airplane> Filter(Expression<Func<Airplane, bool>> predicate)
        {
            return this.GetAll().Where(predicate);
        }

        /// <inheritdoc/>
        public Airplane Find(Expression<Func<Airplane, bool>> predicate)
        {
            return this.GetAll().FirstOrDefault(predicate);
        }

        /// <inheritdoc/>
        public Airplane Get(int id)
        {
            return this._session.Get<Airplane>(id);
        }

        /// <inheritdoc/>
        public IQueryable<Airplane> GetAll()
        {
            return this._session.Query<Airplane>();
        }
    }
}