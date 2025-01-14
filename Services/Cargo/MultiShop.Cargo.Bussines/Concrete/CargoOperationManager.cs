using MultiShop.Cargo.Bussines.Abstract;
using MultiShop.Cargo.DataAccesLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.Bussines.Concrete
{
    public class CargoOperationManager : ICargoOperationService
    {
        private readonly ICargoOperationDal _cargoOperation;

        public CargoOperationManager(ICargoOperationDal cargoOperation)
        {
            _cargoOperation = cargoOperation;
        }

        public void TDelete(int Id)
        {
            _cargoOperation.Delete(Id);
        }

        public List<CargoOperation> TGetAll()
        {
            return _cargoOperation.GetAll();
        }

        public CargoOperation TGetbyId(int Id)
        {
            return _cargoOperation.GetbyId(Id);
        }

        public void TInsert(CargoOperation entity)
        {
            _cargoOperation.Insert(entity);

        }

        public void TUpdate(CargoOperation entity)
        {
            _cargoOperation.Update(entity);
        }
    }
}
