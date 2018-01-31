using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Data
{
    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly CoffeeDbContext _coffeeDbContext;
        private DbSet<T> _entities;

        public EfRepository(CoffeeDbContext coffeeDbContext)
        {
            _coffeeDbContext = coffeeDbContext;
            _entities = _coffeeDbContext.Set<T>();
        }

        public T Add(T entity)
        {
            _entities.Add(entity);
            _coffeeDbContext.SaveChanges();

            return entity;
        }

        public void Delete(T entity)
        {
            _entities.Remove(entity);
            _coffeeDbContext.SaveChanges();
        }

        public T GetById(Guid id)
        {
            return _entities.SingleOrDefault(p=>p.Id == id);
        }

        public IEnumerable<T> ListAll()
        {
            return _entities.AsEnumerable();
        }

        public void Update(T entity)
        {
            _coffeeDbContext.Entry(entity).State = EntityState.Modified;
            _coffeeDbContext.SaveChanges();
        }
    }
}
