using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCL.Security.Identity;
using DAL.Repositories.Interfaces;

namespace CCL.Security
{
    public interface IUserRepository
        : IRepository<User>
    {
    }
}