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
    public class CargoDetailManager : ICargoDetailService
    {
        private readonly ICargoDetailDal _cargoDetailal;

        public CargoDetailManager(ICargoDetailDal cargoDetailal)
        {
            _cargoDetailal = cargoDetailal;
        }

        public void TDelete(int Id)
        {
            _cargoDetailal.Delete(Id);
        }

        public List<CargoDetail> TGetAll()
        {
            return _cargoDetailal.GetAll();
        }

        public CargoDetail TGetbyId(int Id)
        {
            return _cargoDetailal.GetbyId(Id);
        }

        public void TInsert(CargoDetail entity)
        {
            _cargoDetailal.Insert(entity);
        }

        public void TUpdate(CargoDetail entity)
        {
            _cargoDetailal.Update(entity);
        }
    }
}
