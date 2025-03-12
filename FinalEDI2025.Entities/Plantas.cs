using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace FinalEDI2025.Entities
{
    public class Plantas
    {
        public int PlantaId { get; set; }
        public string Descripcion { get; set; }
        public int TipoDePlantaId { get; set; }
        public decimal Precio { get; set; }
        public TiposDePlantas TipoDePlanta { get; set; }
    }
}
