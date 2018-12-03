using Cellular.Common.Invoices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cellular.Invoices.BL.Invoices
{
    public class OutOfPackage
    {
        private readonly SingleLineInvoiceData[] linesData;

        public OutOfPackage(params SingleLineInvoiceData[] linesData)
        {
            this.linesData = linesData;
        }

        public double AdditionalMinuets
        {
            get
            {

            }
        }

        public double AdditionalSMSes
        {
            get
            {
            }
        }

        public double TotalAdditionalPrice
        {
            get
            {
            }
        }

    }
}
