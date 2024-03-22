using InvoiceManager.Models.Domains;
using InvoiceManager.Models.Repositories;
using InvoiceManager.Models.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvoiceManager.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private InvoiceRepository _invoiceRepository = new InvoiceRepository();
        private ClientRepository _clientRepository = new ClientRepository();
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var invoices = _invoiceRepository.GetInvoices(userId);

            //var invoices = new List<Invoice>()
            //{
            //    new Invoice
            //    {
            //        Id = 1,
            //        Title = "Fa/01/2024",
            //        CreatedDate = DateTime.Now,
            //        PaymentDate = DateTime.Now,
            //        Value = 999,
            //        Client = new Client{ Name = "Klient 1"}
            //    },
            //    new Invoice
            //    {
            //        Id = 2,
            //        Title = "Fa/02/2024",
            //        CreatedDate = DateTime.Now,
            //        PaymentDate = DateTime.Now,
            //        Value = 91199,
            //        Client = new Client{ Name = "Klient 2"}
            //    }

            //};

            return View(invoices);
        }

        public ActionResult Invoice(int id = 0)
        {
            //EditInvoiceViewModel vm = null;

            //if (id == 0)
            //{
            //    vm = new EditInvoiceViewModel()
            //    {
            //        Clients = new List<Client>()
            //    {
            //        new Client { Id = 1, Name = "Klient 1" }
            //    },
            //        MethodOfPayments = new List<MethodOfPayment>
            //    {
            //        new MethodOfPayment { Id = 1, Name = "Przelew" }
            //    },
            //        Heading = "Edycja faktury",
            //        Invoice = new Invoice()
            //    };
            //}
            //else
            //{
            //    vm = new EditInvoiceViewModel()
            //    {
            //        Clients = new List<Client>()
            //        {
            //            new Client { Id = 1, Name = "Klient 1" }
            //        },
            //        MethodOfPayments = new List<MethodOfPayment>
            //        {
            //            new MethodOfPayment { Id = 1, Name = "Przelew" }
            //        },
            //        Heading = "Edycja faktury",
            //        Invoice = new Invoice()
            //        {
            //            ClientId = 1,
            //            Comments = "Uwagi",
            //            CreatedDate = DateTime.Now,
            //            PaymentDate = DateTime.Now,
            //            MethodOfPaymentId = 1,
            //            Id = 1,
            //            Value = 100,
            //            Title = "FA/01/2024",
            //            InvoicePositions = new List<InvoicePosition>()
            //            {
            //                new InvoicePosition()
            //                {
            //                    Id = 1,
            //                    Lp = 1,
            //                    Product = new Product(){ Name = "Produkt"},
            //                    Quantity = 2,
            //                    Value = 50,
            //                },
            //                new InvoicePosition()
            //                {
            //                    Id = 2,
            //                    Lp = 2,
            //                    Product = new Product(){ Name = "Produkt 32"},
            //                    Quantity = 223,
            //                    Value = 501,
            //                },
            //            }
            //        }
            //    };
            //}

            var userId = User.Identity.GetUserId();

            var invoice = id == 0 ?
                GetNewInvoice(userId) :
                _invoiceRepository.GetInvoice(id, userId);

            var vm = PrepareInvoiceVm(invoice, userId);

            return View(vm);
        }

        private EditInvoiceViewModel PrepareInvoiceVm(Invoice invoice, string userId)
        {
            return new EditInvoiceViewModel
            {
                Invoice = invoice,
                Heading = invoice.Id == 0 ? "Dodawanie nowej faktury" : "Faktura",
                Clients = _clientRepository.GetClients(userId),
                MethodOfPayments = _invoiceRepository.GetMethodsOfPayment()
            };
        }

        private Invoice GetNewInvoice(string userId)
        {
            return new Invoice
            {
                UserId = userId,
                CreatedDate = DateTime.Now,
                PaymentDate = DateTime.Now.AddDays(7)
            };
        }

        public ActionResult InvoicePosition(int invoiceId = 0, int invoicePositionId = 0)
        {

            EditInvoicePositionViewModel vm = null;

            if (invoicePositionId == 0)
            {
                vm = new EditInvoicePositionViewModel()
                {
                    InvoicePosition = new InvoicePosition(),
                    Heading = "Dodawanie nowej pozycji",
                    Products = new List<Product>()
                    { new Product { Id = 1, Name = "Produkt 1" } }
                };
            }
            else
            {
                vm = new EditInvoicePositionViewModel()
                {
                    InvoicePosition = new InvoicePosition()
                    {
                        Lp = 11, Value = 100, Quantity = 2, ProductId = 1 
                    },
                    Heading = "Edytowanie pozycji",
                    Products = new List<Product>()
                    { new Product { Id = 1, Name = "Produkt 1" } }
                };
            }

            return View(vm);
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}