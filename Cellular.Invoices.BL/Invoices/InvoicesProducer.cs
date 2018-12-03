﻿using Cellular.Common.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellular.Invoices.BL.Invoices
{
    public class InvoicesProducer : IInvoicesProducer
    {
        private readonly IInvoicesRepository repository;
        private readonly IPriceList priceList;

        public InvoicesProducer(IInvoicesRepository repository, IPriceList priceList)
        {
            this.repository = repository;
            this.priceList = priceList;
        }

        public IInvoice Createinvoice(int clientId, DateTime from, DateTime until)
        {
            throw new NotImplementedException();
        }
    }
}
