using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalEDI2025.Entities
{
    public class TiposDePlantas
    {
        public int TipoPlantaId { get; set; }
        public string Descripcion { get; set; }
        public ICollection<Plantas> Plantas { get; set; }= new List<Plantas>();
    }
}
