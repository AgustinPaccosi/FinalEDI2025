using FinalEDI2025.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinalEDI2025.Services.Interfaces
{
    public interface ITiposDePlantasService
    {
        IEnumerable<TiposDePlantas>? GetAll(Expression<Func<TiposDePlantas,
            bool>>? filter = null,
            Func<IQueryable<TiposDePlantas>,
            IOrderedQueryable<TiposDePlantas>>? orderBy = null,
            string? propertiesNames = null);

        void Guardar(TiposDePlantas tipo);

        void Eliminar(TiposDePlantas tipo);

        TiposDePlantas? Get(Expression<Func<TiposDePlantas,
            bool>>? filter = null,
            string? propertiesNames = null,
            bool tracked = true);

        bool Existe(TiposDePlantas tipo);

        bool EstaRelacionado(int id);
    }
}
