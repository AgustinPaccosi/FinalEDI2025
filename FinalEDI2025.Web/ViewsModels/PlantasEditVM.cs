using AutoMapper.Configuration.Conventions;
using FinalEDI2025.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalEDI2025.Web.ViewsModels
{
    public class PlantasEditVM
    {
        public int PlantaId { get; set; }

        [Required(ErrorMessage = "{0} Es Requerido")]
        [StringLength(50, ErrorMessage = "{0} Debe estar entre {2} y {1} caracteres", MinimumLength = 3)]
        [DisplayName("Descripcion")]

        public string Descripcion { get; set; } = null!;

        [Required(ErrorMessage = "{0} Es Requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un tipo de planta")]
        [DisplayName("Tipo De Planta")]

        public int TipoDePlantaId { get; set; }

        [Required(ErrorMessage = "{0} Es Requerido")]
        [Range(0.5, 10000, ErrorMessage = "{0} must be greater than zero")]
        [DisplayName("Price")]

        public decimal Precio { get; set; }
        [ValidateNever]
        public List<SelectListItem> TiposDePlantas { get; set; } = null!;
    }
}
