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
    public class CargoCompanyManager : ICargoCompanyservice
    {
        private readonly ICargoCompanyDal _cargoCompanyDal;

        public CargoCompanyManager(ICargoCompanyDal cargoCompanyDal)
        {
            _cargoCompanyDal = cargoCompanyDal;
        }

        public void TDelete(int Id)
        {
            _cargoCompanyDal.Delete(Id);
        }

        public List<CargoComponay> TGetAll()
        {
            return _cargoCompanyDal.GetAll();

        }

        public CargoComponay TGetbyId(int Id)
        {
            return _cargoCompanyDal.GetbyId(Id);
        }

        public void TInsert(CargoComponay entity)
        {
            _cargoCompanyDal.Insert(entity);
        }

        public void TUpdate(CargoComponay entity)
        {
            _cargoCompanyDal.Update(entity);
        }
    }
}
