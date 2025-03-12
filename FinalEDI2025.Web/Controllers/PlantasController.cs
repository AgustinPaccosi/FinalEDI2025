using AutoMapper;
using FinalEDI2025.Entities;
using FinalEDI2025.Services.Interfaces;
using FinalEDI2025.Web.ViewsModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList.Extensions;

namespace FinalEDI2025.Web.Controllers
{
    public class PlantasController : Controller
    {

        private readonly IPlantasService _services;
        private readonly IMapper? _mapper;
        private readonly ITiposDePlantasService? _plantasService;

        public PlantasController(IPlantasService services, IMapper? mapper, ITiposDePlantasService? countriesService)
        {
            _services = services;
            _mapper = mapper;
            _plantasService = countriesService;
        }

        public IActionResult Index(int? page, int? filterId, int pageSize = 10, bool viewAll = false, string orderBy = "Ascendente")
        {
            int pageNum = page ?? 1;
            ViewBag.currentPageSize = pageSize;
            ViewBag.currentOrderBy = orderBy;
            ViewBag.currentFilterId = filterId;
            IEnumerable<Plantas>? plantas;
            if (filterId ==0 || viewAll || filterId is null)
            {
                filterId = 0; 
                ViewBag.currentFilterId = filterId;
                plantas = _services!
                    .GetAll(orderBy: o => o.OrderBy(s => s.Descripcion),
                    propertiesNames: "TipoDePlanta");
            }
            else
            {
                plantas = _services!
                     .GetAll(orderBy: o => o.OrderBy(s => s.Descripcion),
                             filter: s => s.TipoDePlantaId == filterId,
                     propertiesNames: "TipoDePlanta");
                ViewBag.currentFilterBrandId = filterId;
            }
            var plantasListVM = _mapper!
                .Map<List<PlantasListVM>>(plantas);
            if (orderBy == "Ascendente")
            {
                plantasListVM = plantasListVM.OrderBy(s => s.Precio).ToList();
            }
            if (orderBy == "Descendente")
            {
                plantasListVM = plantasListVM.OrderByDescending(s => s.Precio).ToList();

            }
            var plantaFilerVm = new PlantasFilterVM
            {
                Plantas = plantasListVM.ToPagedList(pageNum, pageSize),
                TiposDePlantas = LlenarCombo()
            };
            return View(plantaFilerVm);
        }

        public IActionResult UpSert(int? id, string? returnurl = null)
        {
            PlantasEditVM? plantaEditVM;
            if (id is null || id.Value == 0)
            {
                plantaEditVM = new PlantasEditVM();
                plantaEditVM.TiposDePlantas=LlenarCombo();
            }
            else
            {
                try
                {
                    Plantas? planta = _services?.Get(s => s.PlantaId == id.Value, propertiesNames: "TipoDePlanta");
                    if (planta == null)
                    {
                        return NotFound();
                    }
                    plantaEditVM = _mapper?.Map<PlantasEditVM>(planta);
                    plantaEditVM.TiposDePlantas = LlenarCombo();

                    return View(plantaEditVM);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return View(plantaEditVM);
        }


        [HttpPost]
        public IActionResult UpSert(PlantasEditVM plantaEditVM)
        {
            if (!ModelState.IsValid)
            {
                plantaEditVM.TiposDePlantas=LlenarCombo();
                return View(plantaEditVM);
            }
            try
            {
                Plantas planta = _mapper!.Map<Plantas>(plantaEditVM);
                var tiposDePlantas = _plantasService!.Get(filter: filter => filter.TipoPlantaId == planta.TipoDePlantaId);
                planta.TipoDePlanta = tiposDePlantas;
                if (planta == null)
                {
                    ModelState.AddModelError(string.Empty, "No se ha podido cargar la Planta");
                    return View(plantaEditVM);
                }
                if (_services!.Existe(planta))
                {
                    ModelState.AddModelError(string.Empty, "Ya existe");
                    plantaEditVM.TiposDePlantas = LlenarCombo();
                    return View(plantaEditVM);
                }
                _services.Guardar(planta);
                TempData["success"] = "Se ha Agregado/Editado Satisfactoriamente";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                plantaEditVM.TiposDePlantas = LlenarCombo();
                ModelState.AddModelError(string.Empty, "Ha ocurrido un error en este Momento");
                return View(plantaEditVM);
            }
        }




        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Plantas? planta = _services?.Get(filter: g => g.PlantaId == id);
            if (planta == null)
            {
                return NotFound();
            }
            _services.Eliminar(planta);
            return Json(new { success = true, message = "Borrado Satisfactoriamente" });


        }

        private List<SelectListItem> LlenarCombo()
        {
            return _plantasService!.GetAll(orderBy: o => o.OrderBy(c => c.Descripcion))!
                                .Select(c => new SelectListItem
                                {
                                    Text = c.Descripcion,
                                    Value = c.TipoPlantaId.ToString()
                                })
                                .ToList();
        }
    }

    
}

