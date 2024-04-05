using OnlineStore.Domain.Entities;
using OnlineStore.Repstory.Repostory;
using OnlineStore.Service.CustomServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Service.User
{
    public class UserTypeServies : ICustomService<UserType>
    {
        private IRepstory<UserType> _repstory;

        public UserTypeServies(IRepstory<UserType> repstory)
        {
            _repstory = repstory;
        }
        public void Delete(UserType entity)
        {
            _repstory.Delete(entity);
        }

        public UserType GetById(int Id)
        {
            return _repstory.GetById(Id);
        }

        public IEnumerable<UserType> GetAll()
        {
            return _repstory.GetAll();
        }

        public void Insert(UserType entity)
        {
            _repstory.Insert(entity);
        }

        public void Update(UserType entity)
        {
          _repstory.Update(entity);
        }
    }
}
