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
    public class TiposDePlantasService : ITiposDePlantasService
    {
        private readonly ITiposDePlantasRepository _repository;
        private readonly IUnitOfWork    _unitOfWork;

        public TiposDePlantasService(ITiposDePlantasRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void Eliminar(TiposDePlantas tipo)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                _repository.Eliminar(tipo);
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork.RollBack();
                throw;
            }
        }

        public bool EstaRelacionado(int id)
        {
            try
            {
                return _repository.EstaRelacionado(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Existe(TiposDePlantas tipo)
        {
            try
            {
                return _repository.Existe(tipo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TiposDePlantas? Get(Expression<Func<TiposDePlantas, bool>>? filter = null, string? propertiesNames = null, bool tracked = true)
        {
            return _repository!.Get(filter, propertiesNames, tracked);
        }

        public IEnumerable<TiposDePlantas>? GetAll(Expression<Func<TiposDePlantas, bool>>? filter = null, Func<IQueryable<TiposDePlantas>, IOrderedQueryable<TiposDePlantas>>? orderBy = null, string? propertiesNames = null)
        {
            return _repository!.GetAll(filter, orderBy, propertiesNames);
        }

        public void Guardar(TiposDePlantas tipo)
        {
            try
            {
                _unitOfWork.BeginTransaction();

                if (tipo.TipoPlantaId == 0)
                {
                    _repository.Agregar(tipo);
                }
                else
                {
                    _repository.Editar(tipo);
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
