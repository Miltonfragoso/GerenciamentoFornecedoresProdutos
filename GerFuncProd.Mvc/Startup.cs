using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GerFuncProd.Mvc.Startup))]
namespace GerFuncProd.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
