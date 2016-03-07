using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PESA.Startup))]
namespace PESA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
