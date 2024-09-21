using hiastHRApi.Domain.Interfaces;
using hiastHRApi.Repository.Interfaces;
using hiastHRApi.Repository.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sieve.Services;

namespace hiastHRApi.Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services, string SqlConnectionStr )
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork.UnitOfWork>();
            //services.AddDbContextPool<HrmappContext>(options => options.UseSqlServer(SqlConnectionStr));
            services.AddScoped<SieveProcessor>();
            return services;
        }
    }
}
