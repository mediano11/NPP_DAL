using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using CCL.Security.Identity;
namespace DAL.Repositories.Impl
{
    public class UserRepository
          : BaseRepository<User>
    {
        public UserRepository(NPPContext context) : base(context)
        {
        }
    }
}


