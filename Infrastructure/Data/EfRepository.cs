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

        public EfRepository(CoffeeDbContext coffeeDbContext)
        {
            _coffeeDbContext = coffeeDbContext;
        }

        public T Add(T entity)
        {
            _coffeeDbContext.Set<T>().Add(entity);
            _coffeeDbContext.SaveChanges();

            return entity;
        }

        public void Delete(T entity)
        {
            _coffeeDbContext.Set<T>().Remove(entity);
            _coffeeDbContext.SaveChanges();
        }

        public T GetById(int id)
        {
            return _coffeeDbContext.Set<T>().Find(id);
        }

        public IEnumerable<T> ListAll()
        {
            return _coffeeDbContext.Set<T>().AsEnumerable();
        }

        public void Update(T entity)
        {
            _coffeeDbContext.Entry(entity).State = EntityState.Modified;
            _coffeeDbContext.SaveChanges();
        }
    }
}
