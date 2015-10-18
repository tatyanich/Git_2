using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProgBlog.Startup))]
namespace ProgBlog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
