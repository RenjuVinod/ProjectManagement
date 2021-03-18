using ProjectManagement.Data.Interfaces;
using ProjectManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Data.Implementation
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {

        private readonly ProjectManagementContext _context;

        public BaseRepository(ProjectManagementContext context)
        {
           _context = context;
        }

        public async Task<T> Add(T entity)
        {
            _context.Add<T>(entity);
            await _context.SaveChangesAsync();
            return Get(entity.ID);
        }

        public async Task<int> Delete(long id)
        {
            _context.Remove<T>(Get(id));
            return await _context.SaveChangesAsync();
        }

        public IQueryable<T> Get()
        {
            return _context.Set<T>();
        }

        public T Get(long id)
        {
            return _context.Set<T>().Where(i => i.ID == id).FirstOrDefault();
        }

        public async Task<T> Update(T entity)
        {
            _context.Update<T>(entity);
            await _context.SaveChangesAsync();
            return Get(entity.ID);
        }
    }
}
