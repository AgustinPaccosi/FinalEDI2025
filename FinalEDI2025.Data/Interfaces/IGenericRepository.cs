﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinalEDI2025.Data.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>>?
            filter = null,
            Func<IQueryable<T>,
            IOrderedQueryable<T>>? orderBy = null,
            string? propertiesNames = null);

        T? Get(Expression<Func<T,
            bool>>? filter = null,
            string? propertiesNames = null,
            bool tracked = true);

        void Agregar(T entity);

        void Eliminar(T entity);

    }
}
