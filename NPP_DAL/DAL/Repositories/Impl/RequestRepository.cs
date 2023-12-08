using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DAL.Repositories.Impl
{
    public class RequestRepository
        : BaseRepository<Request>, IRequestRepository
    {

        internal RequestRepository(NPPContext context)
            : base(context)
        {
        }
    }
}
