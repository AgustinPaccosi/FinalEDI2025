using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Diagnostics;

namespace FinalEDI2025.Web.ViewsModels
{
    public class TiposDePlantasEditVM
    {
        public int TipoPlantaId { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50, ErrorMessage = "{0} must have between {2} and {1} characters", MinimumLength = 3)]
        [DisplayName("Descripcion")]
        public string Descripcion { get; set; } = null!;
    }
}
