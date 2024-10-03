using Company.Data.Contexts;
using Company.Data.Models;
using Company_Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly CompanyDbContext _context;
        public GenericRepository(CompanyDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            // Check if the entity is already being tracked
            var trackedEntity = _context.ChangeTracker.Entries<T>()
                                        .FirstOrDefault(e => e.Entity.Id == entity.Id);

            if (trackedEntity != null)
            {
                // Detach the already tracked 6entity
                _context.Entry(trackedEntity.Entity).State = EntityState.Detached;
            }

            // Attach the new entity and mark it as modified
            //_context.Entry(entity).State = EntityState.Modified;
            _context.Set<T>().Remove(entity);
        }

        public IEnumerable<T> GetAll() => _context.Set<T>().Where(x => x.IsDeleted == false).AsNoTracking().ToList();
        public T GetById(int id) => _context.Set<T>().Find(id);

        public void Update(T entity)
        {
            // Check if the entity is already being tracked
            var trackedEntity = _context.ChangeTracker.Entries<T>()
                                        .FirstOrDefault(e => e.Entity.Id == entity.Id);

            if (trackedEntity != null)
            {
                // Detach the already tracked 6entity
                _context.Entry(trackedEntity.Entity).State = EntityState.Detached;
            }

            // Attach the new entity and mark it as modified
            _context.Entry(entity).State = EntityState.Modified;
        }

    }
}
