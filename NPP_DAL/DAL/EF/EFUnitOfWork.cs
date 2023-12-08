using DAL.Entities;
using DAL.Repositories.Impl;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL.EF
{
    public class EFUnitOfWork
        : IUnitOfWork
    {
        private NPPContext db;
        private NPPRepository nppRepository;
        private EmployeeRepository employeeRepository;
        private RequestRepository requestRepository;

        public EFUnitOfWork(DbContextOptions<NPPContext> options)
        {
            db = new NPPContext(options);
        }
        public INPPRepository NPPs
        {
            get
            {
                if (nppRepository == null)
                    nppRepository = new NPPRepository(db);
                return nppRepository;
            }
        }

        public EmployeeRepository Employees
        {
            get
            {
                if (employeeRepository == null)
                    employeeRepository = new EmployeeRepository(db);
                return employeeRepository;
            }
        }

        public RequestRepository Requests
        {
            get
            {
                if (requestRepository == null)
                    requestRepository = new RequestRepository(db);
                return requestRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}