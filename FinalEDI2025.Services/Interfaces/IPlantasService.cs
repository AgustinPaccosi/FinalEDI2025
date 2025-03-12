using FinalEDI2025.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinalEDI2025.Services.Interfaces
{
    public interface IPlantasService
    {
        IEnumerable<Plantas>? GetAll(Expression<Func<Plantas,
            bool>>? filter = null,
            Func<IQueryable<Plantas>,
            IOrderedQueryable<Plantas>>? orderBy = null,
            string? propertiesNames = null);

        void Guardar(Plantas plantas);

        void Eliminar(Plantas plantas);

        Plantas? Get(Expression<Func<Plantas,
            bool>>? filter = null,
            string? propertiesNames = null,
            bool tracked = true);

        bool Existe(Plantas plantas);
    }
}
