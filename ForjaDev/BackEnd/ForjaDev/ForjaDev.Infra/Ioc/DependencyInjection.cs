using ForjaDev.Application.Query.Interfaces;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories.Categories;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories.Likes;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories.Members;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories.Posts;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories.Users;
using ForjaDev.Infra.Query;
using ForjaDev.Infra.Repositories;
using ForjaDev.Infra.Repositories.Categories;
using ForjaDev.Infra.Repositories.Likes;
using ForjaDev.Infra.Repositories.Members;
using ForjaDev.Infra.Repositories.Posts;
using ForjaDev.Infra.Repositories.Users;
using Microsoft.Extensions.DependencyInjection;

namespace ForjaDev.Infra.Ioc;

public static class DependencyInjection
{
    public static IServiceCollection AddInfra(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
        services.AddScoped<IMemberQuery,MemberQuery>();
        services.AddScoped<IPostQuery,PostQuery>();
        services.AddScoped<IUserRepository,UserRepository>();
        services.AddScoped<IMemberRepository,MemberRepository>();
        services.AddScoped<IPostRepository,PostRepository>();
        services.AddScoped<ICategoryRepository,CategoryRepository>();
        services.AddScoped<ILikeRepository,LikeRepository>();

        
        return services;   
    }
}