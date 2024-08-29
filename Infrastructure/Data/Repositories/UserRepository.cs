using Application.Data.Repositories;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(User entity)
        {
            _dbContext.Users.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(User entity)
        {
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<User> FindAll()
        {
            return _dbContext.Users.ToList();
        }

        public User GetById(Guid id)
        {
            return _dbContext.Users.Where(x=>x.Id == id).Single();    
        }

        public void Update(User entity)
        {
           _dbContext.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
