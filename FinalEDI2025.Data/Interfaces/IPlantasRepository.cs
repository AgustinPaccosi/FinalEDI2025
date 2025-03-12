using FinalEDI2025.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalEDI2025.Data.Interfaces
{
    public interface IPlantasRepository :IGenericRepository<Plantas>
    {
        void Editar(Plantas planta);
        bool Existe(Plantas planta);
    }
}
