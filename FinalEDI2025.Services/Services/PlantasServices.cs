using FinalEDI2025.Data.Interfaces;
using FinalEDI2025.Data.UnitOfWork;
using FinalEDI2025.Entities;
using FinalEDI2025.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinalEDI2025.Services.Services
{
    public class PlantasServices : IPlantasService
    {
        private readonly IPlantasRepository _repository;

        private readonly IUnitOfWork _unitOfWork;

        public PlantasServices(IPlantasRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void Eliminar(Plantas plantas)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                _repository.Eliminar(plantas);
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork.RollBack();
                throw;
            }
        }

        public bool Existe(Plantas plantas)
        {
            try
            {
                return _repository.Existe(plantas);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Plantas? Get(Expression<Func<Plantas, bool>>? filter = null, string? propertiesNames = null, bool tracked = true)
        {
            return _repository!.Get(filter, propertiesNames, tracked);
        }

        public IEnumerable<Plantas>? GetAll(Expression<Func<Plantas, bool>>? filter = null, Func<IQueryable<Plantas>, IOrderedQueryable<Plantas>>? orderBy = null, string? propertiesNames = null)
        {
            return _repository!.GetAll(filter, orderBy, propertiesNames);
        }

        public void Guardar(Plantas plantas)
        {
            try
            {
                _unitOfWork.BeginTransaction();

                if (plantas.PlantaId == 0)
                {
                    _repository.Agregar(plantas);
                }
                else
                {
                    _repository.Editar(plantas);
                }

                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork.RollBack();
                throw;
            }
        }
    }
}
