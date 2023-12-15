using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Security.Identity
{
    public class Head
        : User
    {
        public Head(int userId, string name, int nppId, string position)
            : base(userId, name, nppId, position, nameof(Head))
        {
        }
    }
}
