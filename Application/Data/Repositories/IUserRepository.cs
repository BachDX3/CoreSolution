using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Data.Repositories
{
    public interface IUserRepository
    {
         void Create(User entity);
        void Update(User entity);
        void Delete(User entity);
        IEnumerable<User> FindAll();
        User GetById(Guid id);
    }
}
