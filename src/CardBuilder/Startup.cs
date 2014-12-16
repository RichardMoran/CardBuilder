using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CardBuilder.Startup))]
namespace CardBuilder
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
