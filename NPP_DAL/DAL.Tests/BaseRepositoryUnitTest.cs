using System;
using Xunit;
using DAL.Repositories.Impl;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using System.Linq;
using Moq;

namespace DAL.Tests
{
    class TestEmployeeRepository
        : BaseRepository<Employee>
    {
        public TestEmployeeRepository(DbContext context)
            : base(context)
        {

        }
    }

    public class BaseRepositoryUnitTests
    {
        


    }
}