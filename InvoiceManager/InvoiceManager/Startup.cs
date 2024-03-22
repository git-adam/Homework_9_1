using InvoiceManager.Models;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InvoiceManager.Startup))]
namespace InvoiceManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            //using (var context = new ApplicationDbContext())
            //{
            //    context.Database.Connection.Open();
            //    context.Database.Connection.Close();
            //}
        }
    }
}
