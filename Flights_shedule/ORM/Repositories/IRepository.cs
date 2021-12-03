// <copyright file="IRepository.cs" company="МИИТ">
// Copyright (c) Кононов П.А. All rights reserved.
// </copyright>

namespace ORM.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// Интерфейс для репозиториев.
    /// </summary>
    public interface IRepository<TEntity>
    {
        /// <summary>
        /// Получать сущность по идентификатору.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <returns> Сущность. </returns>
        TEntity Get(int id);

        /// <summary>
        /// Получает (находит) сущность по выражению.
        /// </summary>
        /// <param name="predicate"> Выражение запроса. </param>
        /// <returns> Сущность. </returns>
        TEntity Find(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Возвращает все поля сущности.
        /// </summary>
        /// <returns> Все поля сущности (данные). </returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Фильтрация данных по критерию (выражению).
        /// </summary>
        /// <param name="predicate"> Выражение запроса. </param>
        /// <returns> Данные. </returns>
        IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate);
    }
}