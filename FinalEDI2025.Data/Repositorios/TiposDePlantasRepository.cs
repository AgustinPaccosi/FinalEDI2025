using FinalEDI2025.Data.Interfaces;
using FinalEDI2025.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalEDI2025.Data.Repositorios
{
    public class TiposDePlantasRepository : GenericRepository<TiposDePlantas>, ITiposDePlantasRepository
    {
        private readonly Context context;
        public TiposDePlantasRepository(Context context) : base(context)
        {
            this.context = context;
        }
        public void Editar(TiposDePlantas tipo)
        {
            context.TiposDePlantas.Update(tipo);
        }

        public bool EstaRelacionado(int id)
        {
            return context.Plantas.Any(t=>t.TipoDePlantaId == id);
        }

        public bool Existe(TiposDePlantas tipo)
        {
            if (tipo.TipoPlantaId==0)
            {
                return context.TiposDePlantas.Any(t => t.Descripcion == tipo.Descripcion);
            }
            return context.TiposDePlantas.Any(t => t.Descripcion == tipo.Descripcion && t.TipoPlantaId != tipo.TipoPlantaId);
        }
    }
}
