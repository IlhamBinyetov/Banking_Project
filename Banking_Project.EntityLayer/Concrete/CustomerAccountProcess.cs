﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Project.EntityLayer.Concrete
{
    public class CustomerAccountProcess
    {
        public int CustomerAccountProcessId { get; set; }
        public  string ProcessType { get; set; }
        public  decimal Amount { get; set; }
        public  DateTime ProcessDate { get; set; }
        public int? SenderId { get; set; }
        public int? ReceiverId { get; set; }
        public CustomerAccount SenderCustomer { get; set; }
        public CustomerAccount ReceiverCustomer { get; set; }
        public string Description { get; set; }
    }
}
