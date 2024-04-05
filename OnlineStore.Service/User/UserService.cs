using OnlineStore.Service.CustomServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.Domain.Entities;
using OnlineStore.Repstory.Repostory;

namespace OnlineStore.Service.User
{
    public class UserService : ICustomService<Users>
    {
        private  IRepstory<Users> _repstory;

        public UserService(IRepstory<Users> repstory)
        {
            _repstory = repstory;
        }

        public void Delete(Users entity)
        {
            _repstory.Delete(entity);
        }

        public Users GetById(int Id)
        {
           return _repstory.GetById(Id);
        }

        public IEnumerable<Users> GetAll()
        {
            return _repstory.GetAll();
        }

        public void Insert(Users entity)
        {
           _repstory.Insert(entity);
        }

       

        public void Update(Users entity)
        {
            _repstory.Update(entity);
        }
    }
}
