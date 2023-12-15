using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Security.Identity

{
    public abstract class User
    {
        public User(int userId, string name, int nppId, string position, string userType)
        {
            UserId = userId;
            Name = name;
            NPPID = nppId;
            PositionTitle = position;
            UserType = userType;
        }
        public int UserId { get; }
        public string Name { get; }
        public int NPPID { get; }
        public string PositionTitle { get; }
        protected string UserType { get; }
    }
}