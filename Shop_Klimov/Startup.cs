using Shop_Klimov.Data.Interfaces;
using Shop_Klimov.Data.Mocks;

namespace Shop_Klimov
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ICategorys, MockCaregorys>();
            services.AddTransient<IItems, MockItems>();

            services.AddMvc(option => option.EnableEndpointRouting = false);
        }
    }
}
