using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyFirstBankUI.Startup))]
namespace MyFirstBankUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
