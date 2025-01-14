using MultiShop.Cargo.DataAccesLayer.Abstract;
using MultiShop.Cargo.DataAccesLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DataAccesLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly CargoContext _context;

        public GenericRepository(CargoContext context)
        {
            _context = context;
        }

        public void Delete(int Id)
        {
            var values = _context.Set<T>().Find(Id);
            _context.Set<T>().Remove(values);
            _context.SaveChangesAsync();
        }

        public List<T> GetAll()
        {
            var values = _context.Set<T>().ToList();
            return values;
        }

        public T GetbyId(int Id)
        {
            var values = _context.Set<T>().Find(Id);
            return values;
        }

        public void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public async void Update(T entity)
        {
           var values= _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
    }
}
