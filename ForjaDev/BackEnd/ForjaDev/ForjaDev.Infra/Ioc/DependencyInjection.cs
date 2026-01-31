using ForjaDev.Application.Query.Interfaces;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories;
using ForjaDev.Infra.Query;
using ForjaDev.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ForjaDev.Infra.Ioc;

public static class DependencyInjection
{
    public static IServiceCollection AddInfra(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
        services.AddScoped<IMemberQuery,MemberQuery>();

        
        return services;   
    }
}