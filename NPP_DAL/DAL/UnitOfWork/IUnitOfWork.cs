using DAL.Entities;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        INPPRepository NPPs { get; }
        IEmployeeRepository Employees { get; }
        IRequestRepository Requests { get; }
        void Save();
    }
}