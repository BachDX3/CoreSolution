using Application.Data.Repositories;
using Application.Models;
using AutoMapper;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implements
{
    public class RegisterService : IRegisterService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public RegisterService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public void Create(RegisterModel entity)
        {
           
        }

        public bool Delete(RegisterModel entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RegisterModel> FindAll()
        {
            throw new NotImplementedException();
        }

        public RegisterModel? GetProducBytId(string Id)
        {
            throw new NotImplementedException();
        }

        public void Update(RegisterModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
