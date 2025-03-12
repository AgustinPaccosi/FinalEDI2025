using AutoMapper;
using FinalEDI2025.Entities;
using FinalEDI2025.Web.ViewsModels;

namespace FinalEDI2025.Web.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            LoadTiposDePlantasMap();
            LoadPlantasMap();
        }

        private void LoadPlantasMap()
        {
            CreateMap<Plantas, PlantasListVM>().ForMember(dest => dest.TipoDePlanta, opt => opt.MapFrom(t => t.TipoDePlanta.Descripcion));
            CreateMap<Plantas, PlantasEditVM>().ReverseMap();
        }

        private void LoadTiposDePlantasMap()
        {
            CreateMap<TiposDePlantas, TiposDePlantasListVM>();
            CreateMap<TiposDePlantas, TiposDePlantasEditVM>().ReverseMap();
        }
    }
}
