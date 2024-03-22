using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using CleanArchMvc.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchMvc.Infra.IoC
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>                              //Registra o contexto
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")     //Define o Banco de dados e string de conexão
                ,b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));   //Informa que a migração vai ficar no arquivo de contexto (ApplicationDbContext)

            //Registrando os serviços de repositório
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
