using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BuscaProfesores.Startup))]
namespace BuscaProfesores
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
