using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmployeeStaffing.Startup))]
namespace EmployeeStaffing
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
