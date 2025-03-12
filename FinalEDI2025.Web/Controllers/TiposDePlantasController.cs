using AutoMapper;
using FinalEDI2025.Entities;
using FinalEDI2025.Services.Interfaces;
using FinalEDI2025.Web.ViewsModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using X.PagedList.Extensions;

namespace FinalEDI2025.Web.Controllers
{
    public class TiposDePlantasController : Controller
    {

        private readonly ITiposDePlantasService _services;
        private readonly IMapper? _mapper;
        public TiposDePlantasController(ITiposDePlantasService services, IMapper? mapper)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public IActionResult Index(int? page)
        {
            int pageNum = page ?? 1;
            int pageSize = 2;
            var tipos = _services.GetAll();
            var tiposVM = _mapper.Map<List<TiposDePlantasListVM>>(tipos).ToPagedList(pageNum,pageSize);

            return View(tiposVM);
        }
        public IActionResult UpSert(int id)
        {
            if (_services == null || _mapper == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "NO FUNCIONAN LOS SERVICES. HDP");

            }
            TiposDePlantasEditVM tipoEditVM;
            if (id == 0 || id == null)
            {
                tipoEditVM = new TiposDePlantasEditVM();
            }
            else
            {
                try
                {
                    TiposDePlantas tipo = _services.Get(filter: c => c.TipoPlantaId == id);
                    if (tipo == null)
                    {
                        return NotFound();
                    }
                    tipoEditVM = _mapper.Map<TiposDePlantasEditVM>(tipo);
                    return View(tipoEditVM);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return View(tipoEditVM);

        }
        [HttpPost]
        public IActionResult UpSert(TiposDePlantasEditVM tipoEditVM)
        {
            if (!ModelState.IsValid)
            {
                return View(tipoEditVM);
            }

            if (_services == null || _mapper == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "NO FUNCIONAN LOS SERVICES. HDP");

            }
            try
            {
                //countryEditVM=_mapper.Map<CountryEditVM>(country);
                TiposDePlantas tipo = _mapper.Map<TiposDePlantas>(tipoEditVM);
                if (_services.Existe(tipo))
                {
                    ModelState.AddModelError(String.Empty, "Pais Existe");
                    return View(tipoEditVM);
                }
                _services.Guardar(tipo);
                TempData["success"] = "Pais Agregado/Editado puto EXCELENTEMENTE";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "No anda");
                return View(tipoEditVM);
                throw;
            }

        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            if (id is null || id == 0)
            {
                return NotFound();
            }
            TiposDePlantas? tipo = _services?.Get(filter: c => c.TipoPlantaId == id);
            if (tipo is null)
            {
                return NotFound();
            }
            try
            {
                if (_services == null || _mapper == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Dependencias no están configuradas correctamente");
                }

                if (_services.EstaRelacionado(tipo.TipoPlantaId))
                {
                    return Json(new { success = false, message = "Relacionado, no se eliminara" }); ;
                }
                _services.Eliminar(tipo);
                return Json(new { success = true, message = "Eliminado" });
            }
            catch (Exception)
            {

                return Json(new { success = false, message = "NO SE PUEDE " }); ;

            }
        }
    }
}
