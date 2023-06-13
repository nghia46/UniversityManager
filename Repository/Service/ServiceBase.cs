using Microsoft.EntityFrameworkCore;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Service
{
    public class ServiceBase<T> where T : class
    {
        private readonly UniversityDbContext _context;
        private readonly DbSet<T> _dbSet;
        public ServiceBase()
        {
            _context = new UniversityDbContext();
            _dbSet = _context.Set<T>();
        }
        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }
        public T GetByID(Guid id) {
            return _dbSet.Find(id);
        }
        public bool Add(T entity)
        {
            try
            {
                _dbSet.Add(entity);
                _context.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}
