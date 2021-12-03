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
        private readonly ISession _session;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="DirectionRepository"/>.
        /// </summary>
        /// <param name="session">Сессия для направлений.</param>
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

        /// <inheritdoc/>
        public bool TryGet(int id, out Direction direction)
        {
            direction = this.GetAll().SingleOrDefault(d => d.Id == id);
            return direction != null;
        }

        /// <inheritdoc/>
        public Direction Create(Direction direction)
        {
            var id = (int)this._session.Save(direction);
            this._session.Flush();
            return direction;
        }

        /// <inheritdoc/>
        public void Delete(int id)
        {
            if (!this.TryGet(id, out var direction))
            {
                return;
            }

            this._session.Delete(direction);
            this._session.Flush();
        }
        /// <inheritdoc/>
        public void Update(Direction direction)
        {
            this._session.Update(direction);
            this._session.Flush();
        }
    }
}