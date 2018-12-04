using Cellular.Common.Invoices;
using System;

namespace Cellular.Invoices.BL.Invoices
{
    class Invoice : IInvoice
    {
        private readonly SingleLineInvoiceData[] linesData;

        public Invoice(params SingleLineInvoiceData[] linesData)
        {
            this.linesData = linesData;
        }

        public double AdditionalPrice
        {
            get
            {
                //TODO: calculate by cirntType
                throw new NotImplementedException();
            }
        }

        public double TotalPrice
        {
            get
            {
                throw new Exception();

            }
        }
    }
}

