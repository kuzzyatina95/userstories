using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(user_stories.Startup))]
namespace user_stories
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
