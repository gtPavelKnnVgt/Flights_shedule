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
        private readonly ISession _session;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="AirplaneRepository"/>.
        /// </summary>
        /// <param name="session">Сессия для самолётов.</param>
        public AirplaneRepository(ISession session)
        {
            this._session = session
                ?? throw new ArgumentNullException(nameof(session));
        }

        /// <inheritdoc/>
        public IQueryable<Airplane> Filter(Expression<Func<Airplane, bool>> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

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
            return this.GetAll().SingleOrDefault<Airplane>(a => a.Id == id);
        }

        /// <inheritdoc/>
        public IQueryable<Airplane> GetAll()
        {
            return this._session.Query<Airplane>();
        }

        /// <inheritdoc/>
        public bool TryGet(int id, out Airplane airplane)
        {
            airplane = this.GetAll().SingleOrDefault(a => a.Id == id);
            return airplane != null;
        }

        /// <inheritdoc/>
        public Airplane Create(Airplane airplane)
        {
            var id = (int)this._session.Save(airplane);
            this._session.Flush();
            return airplane;
        }

        /// <inheritdoc/>
        public void Delete(int id)
        {
            if (!this.TryGet(id, out var airplane))
            {
                return;
            }

            this._session.Delete(airplane);
            this._session.Flush();
        }

        /// <inheritdoc/>
        public void Update(Airplane airplane)
        {
            this._session.Update(airplane);
            this._session.Flush();
        }
    }
}