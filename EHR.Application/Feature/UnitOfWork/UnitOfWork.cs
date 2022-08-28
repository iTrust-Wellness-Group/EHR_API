using EHR.Application.Contract.ReferralSystem.Office;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Application.Feature.UnitOfWork
{
    internal class UnitOfWork : IUnitOfWork, IDisposable
    {
        //private context
        //public IOrderRepository orderRepo { get; private set; }


        //public UnitOfWork()
        //{
        //    //orderRepo = new OrderRepository(_context);
            
        //}
        //public bool Complete()
        //{
        //    // _context.SaveChanges();
        //    return true;
        //}

        //public void Dispose()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
