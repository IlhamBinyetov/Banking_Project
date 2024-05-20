using Banking_Project.DataAccessLayer.Abstract;
using Banking_Project.DataAccessLayer.Concrete;
using Banking_Project.DataAccessLayer.Repositories;
using Banking_Project.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Project.DataAccessLayer.EntityFramework
{
    public class EfCustomerAccountProcessDal : GenericRepository<CustomerAccountProcess>, ICustomerAccountProcessDal
    {
        public List<CustomerAccountProcess> MyLastProcess(int id)
        {
            using var context = new Context();
            var values = context.CustomerAccountProcesses.Include(x=>x.SenderCustomer).Include(y=>y.ReceiverCustomer).ThenInclude(z=>z.AppUser).Where(x => x.ReceiverId == id || x.SenderId == id).ToList();
            return values;
        }
    }
}
