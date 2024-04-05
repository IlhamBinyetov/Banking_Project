using Banking_Project.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Project.DataAccessLayer.Abstract
{
    public interface ICustomerAccountDal: IGenericDal<CustomerAccount>
    {
    }
}
