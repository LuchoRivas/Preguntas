using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Preguntas.Startup))]
namespace Preguntas
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
