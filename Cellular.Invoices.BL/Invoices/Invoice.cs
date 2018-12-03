using Cellular.Common.Invoices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cellular.Invoices.BL.Invoices
{
    class Invoice
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
                double result = 0;
                foreach (var item in Packages)
                {
                    result += item.TotalPrice;
                }



                return result;
            }
        }
    }
}

