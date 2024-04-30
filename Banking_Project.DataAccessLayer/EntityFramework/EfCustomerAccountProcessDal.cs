using Banking_Project.DataAccessLayer.Abstract;
using Banking_Project.DataAccessLayer.Repositories;
using Banking_Project.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Project.DataAccessLayer.EntityFramework
{
    public class EfCustomerAccountProcessDal:GenericRepository<CustomerAccountProcess>, ICustomerAccountProcessDal
    {

    }
}
