using FinalEDI2025.Data.Interfaces;
using FinalEDI2025.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalEDI2025.Data.Repositorios
{
    public class PlantasRepository : GenericRepository<Plantas>, IPlantasRepository
    {
        private readonly Context context;
        public PlantasRepository(Context context) : base(context)
        {
            this.context = context;
        }
        public void Editar(Plantas planta)
        {
            context.Plantas.Update(planta);
        }

        public bool Existe(Plantas planta)
        {
            if (planta.PlantaId==0)
            {
                return context.Plantas.Any(p => p.Descripcion == planta.Descripcion
                                            && p.TipoDePlantaId == planta.TipoDePlantaId);

            }
            return context.Plantas.Any(p => p.Descripcion == planta.Descripcion
                                           && p.TipoDePlantaId == planta.TipoDePlantaId
                                           && p.PlantaId != planta.PlantaId);
        }
    }
}
