using OnlineStore.Domain.Entities;
using OnlineStore.Repstory.Repostory;
using OnlineStore.Service.CustomServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Service.Product
{
    public class ProudctsServices : ICustomService<Products>
    {
        private IRepstory<Products> _repstory;

        public ProudctsServices(IRepstory<Products> repstory)
        {
            _repstory = repstory;
        }

        public void Delete(Products entity)
        {
            _repstory.Delete(entity);
        }

        public Products GetById(int Id)
        {
            return _repstory.GetById(Id);
        }

        public IEnumerable<Products> GetAll()
        {
           return _repstory.GetAll();
        }

        public void Insert(Products entity)
        {
            _repstory.Insert(entity);
        }

        public void Update(Products entity)
        {
            _repstory.Update(entity);
        }
    }
}
