using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain.Data;
using OnlineStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Repstory.Repostory
{
    public class Repository<T> : IRepstory<T> where T : BaseEntity
    {
        #region Data Inatanstions
        private readonly ApplicationContext _context;
        private readonly DbSet<T> _dbSet;
        #endregion
        #region Constructor
        public Repository(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        #endregion
        #region Delete
        public void Delete(T entity)
        {
            if (entity is null)
                throw new ArgumentNullException();
            _dbSet.Remove(entity); 
            _context.SaveChanges();
        }
        #endregion
        #region Get 
        public T GetById(int Id)
        {
            return _dbSet.SingleOrDefault(e => e.Id == Id);
        }
        public IEnumerable<T> GetAll()
        {
            return _dbSet;
        }
        #endregion
        #region InsertData
        public void Insert(T entity)
        {
            if(entity is null)
                throw new ArgumentNullException();
           _dbSet.Add(entity);
           _context.SaveChanges();
        }
        #endregion
        #region Update
        public void Update(T entity)
        {
           if(entity is null)
                throw new ArgumentNullException();
            _dbSet.Update(entity);
            _context.SaveChanges();
        }
        #endregion
    }
}
