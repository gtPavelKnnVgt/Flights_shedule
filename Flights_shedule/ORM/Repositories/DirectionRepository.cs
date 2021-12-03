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
    /// Репозиторий для Направления.
    /// </summary>
    public class DirectionRepository : IRepository<Direction>
    {
        private ISession _session;

        public DirectionRepository(ISession session)
        {
            this._session = session
                ?? throw new ArgumentNullException(nameof(session));
        }

        /// <inheritdoc/>
        public IQueryable<Direction> Filter(Expression<Func<Direction, bool>> predicate)
        {
            return this.GetAll().Where(predicate);
        }

        /// <inheritdoc/>
        public Direction Find(Expression<Func<Direction, bool>> predicate)
        {
            return this.GetAll().FirstOrDefault(predicate);
        }

        /// <inheritdoc/>
        public Direction Get(int id)
        {
            return this._session.Get<Direction>(id);
        }

        /// <inheritdoc/>
        public IQueryable<Direction> GetAll()
        {
            return this._session.Query<Direction>();
        }
    }
}