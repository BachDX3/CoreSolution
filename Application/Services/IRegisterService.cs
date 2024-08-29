using Application.Models;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IRegisterService
    {
        void Create(RegisterModel entity);
        void Update(RegisterModel entity);
        bool Delete(RegisterModel entity);
        IEnumerable<RegisterModel> FindAll();
        RegisterModel? GetProducBytId(string Id);
    }
}
