using InvoiceManager.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceManager.Models.Repositories
{
    public class InvoiceRepository
    {
        public List<Invoice> GetInvoices(string userId)
        {
            throw new NotImplementedException();
        }

        public Invoice GetInvoice(int id, string userId)
        {
            throw new NotImplementedException();
        }

        public List<MethodOfPayment> GetMethodsOfPayment()
        {
            throw new NotImplementedException();
        }
    }
}