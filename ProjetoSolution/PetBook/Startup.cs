using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PetBook.Startup))]
namespace PetBook
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
