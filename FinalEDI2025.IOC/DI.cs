using FinalEDI2025.Data;
using FinalEDI2025.Data.Interfaces;
using FinalEDI2025.Data.Repositorios;
using FinalEDI2025.Data.UnitOfWork;
using FinalEDI2025.Services.Interfaces;
using FinalEDI2025.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalEDI2025.IOC
{
    public static class DI
    {
        public static void ConfigurarServicios(IServiceCollection servicios, IConfiguration configuration)
        {
            //REPOSITORIOS

            servicios.AddScoped<ITiposDePlantasRepository, TiposDePlantasRepository>();

            servicios.AddScoped<IPlantasRepository, PlantasRepository>();


            //SERVICIOS

            servicios.AddScoped<ITiposDePlantasService, TiposDePlantasService>();

            servicios.AddScoped<IPlantasService, PlantasServices>();

            //UNIT OF WORK
            servicios.AddScoped<IUnitOfWork, UnitOfWork>();

            servicios.AddDbContext<Context>(opciones =>
            {
                opciones.UseSqlServer(configuration.GetConnectionString("MyConn"));
            });
        }
    }
}
