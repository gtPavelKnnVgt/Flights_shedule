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
        private readonly ISession _session;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="PassengerRepository"/>.
        /// </summary>
        /// <param name="session">Сессия для Пассажиров.</param>
        public PassengerRepository(ISession session)
        {
            this._session = session
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
            return this.GetAll().FirstOrDefault(predicate)
                ?? throw new ArgumentNullException(nameof(predicate));
        }

        /// <inheritdoc/>
        public Passenger Get(int id)
        {
            return this._session.Get<Passenger>(id)
                ?? throw new ArgumentNullException(nameof(id));
        }

        /// <inheritdoc/>
        public IQueryable<Passenger> GetAll()
        {
            return this._session.Query<Passenger>();
        }

        /// <inheritdoc/>
        public bool TryGet(int id, out Passenger passenger)
        {
            passenger = this.GetAll().SingleOrDefault(p => p.Id == id);
            return passenger != null;
        }

        /// <inheritdoc/>
        public Passenger Create(Passenger passenger)
        {
            var id = (int)this._session.Save(passenger);
            this._session.Flush();
            return passenger;
        }

        /// <inheritdoc/>
        public void Delete(int id)
        {
            if (!this.TryGet(id, out var passenger))
            {
                throw new ArgumentNullException(nameof(id));
            }

            this._session.Delete(passenger);
            this._session.Flush();
        }

        /// <inheritdoc/>
        public void Update(Passenger passenger)
        {
            this._session.Update(passenger);
            this._session.Flush();
        }
    }
}