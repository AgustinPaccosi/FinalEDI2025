using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace FinalEDI2025.Web.ViewsModels
{
    public class PlantasFilterVM
    {
        public IPagedList<PlantasListVM>? Plantas { get; set; }

        public List<SelectListItem> TiposDePlantas { get; set; }
    }
}
