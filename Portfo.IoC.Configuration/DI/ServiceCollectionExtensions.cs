using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Portfo.API.DataContracts.Requests;
using Portfo.Repo.SqlDatabase.Context;
using Portfo.Repo.SqlDatabase.Contracts;
using Portfo.Repo.SqlDatabase.Repositories;
using Portfo.Services;
using Portfo.Services.Contracts;
using Portfo.Services.Validators;

using S = Portfo.Services.Model;
using DC = Portfo.API.DataContracts;

namespace Portfo.IoC.Configuration.DI
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {
            if (services != null)
            {
                services.AddTransient<IAddressService, AddressService>();
                services.AddTransient<IUserService, UserService>();
                services.AddTransient<IPostService, PostService>();
                services.AddTransient<ILikeService, LikeService>();
                services.AddTransient<IActivityService, ActivityService>();
            }
        }

        public static void ConfigureRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            if (services != null)
            {
                services.AddDbContext<PortfoSqlDbContext>();
                
                services.AddTransient<IAddressRepository, AddressRepository>();
                services.AddTransient<IUserRepository, UserRepository>();
                services.AddTransient<IPostRepository, PostRepository>();
                services.AddTransient<ILikeRepository, LikeRepository>();
                services.AddTransient<IActivityRepository, ActivityRepository>();
            }
        }

        public static void ConfigureMappings(this IServiceCollection services)
        {
            if (services != null)
            {
                //Automap settings
                services.AddAutoMapper(cfg => cfg.CreateMap<AddressCreationRequest, S.Address>());
                services.AddAutoMapper(cfg => cfg.CreateMap<AddressUpdateRequest, S.Address>());
                services.AddAutoMapper(cfg => cfg.CreateMap<S.Address, DC.Address>());
                services.AddAutoMapper(cfg => cfg.CreateMap<S.UserAddress, DC.AddressUser>());
                services.AddAutoMapper(cfg => cfg.CreateMap<DC.AddressUser, S.UserAddress>());
                services.AddAutoMapper(cfg => cfg.CreateMap<DC.AddressCreation, S.Address>());

                services.AddAutoMapper(cfg => cfg.CreateMap<UserCreationRequest, S.User>());
                services.AddAutoMapper(cfg => cfg.CreateMap<UserUpdateRequest, S.User>());
                services.AddAutoMapper(cfg => cfg.CreateMap<S.User, DC.User>());
                services.AddAutoMapper(cfg => cfg.CreateMap<S.PostUser, DC.UserPost>());
                services.AddAutoMapper(cfg => cfg.CreateMap<DC.UserPost, S.PostUser>());
                services.AddAutoMapper(cfg => cfg.CreateMap<DC.UserCreation, S.User>());

                services.AddAutoMapper(cfg => cfg.CreateMap<PostCreationRequest, S.Post>());
                services.AddAutoMapper(cfg => cfg.CreateMap<PostUpdateRequest, S.Post>());
                services.AddAutoMapper(cfg => cfg.CreateMap<S.Post, DC.Post>());
                services.AddAutoMapper(cfg => cfg.CreateMap<S.LikePost, DC.PostLike>());
                services.AddAutoMapper(cfg => cfg.CreateMap<DC.PostLike, S.LikePost>());
                services.AddAutoMapper(cfg => cfg.CreateMap<DC.PostCreation, S.Post>());
                services.AddAutoMapper(cfg => cfg.CreateMap<DC.PostUpdate, S.Post>());

                services.AddAutoMapper(cfg => cfg.CreateMap<LikeCreationRequest, S.Like>());
                services.AddAutoMapper(cfg => cfg.CreateMap<LikeUpdateRequest, S.Like>());
                services.AddAutoMapper(cfg => cfg.CreateMap<S.Like, DC.Like>());
                services.AddAutoMapper(cfg => cfg.CreateMap<DC.LikeCreation, S.Like>());

                services.AddAutoMapper(cfg => cfg.CreateMap<S.Activity, DC.Activity>());
            }
        }

        public static void ConfigureValidators(this IServiceCollection services)
        {
            if (services != null)
            {
                services.AddScoped<IValidator<S.Address>, AddressValidator>();
                services.AddScoped<IValidator<S.User>, UserValidator>();
                services.AddScoped<IValidator<S.Post>, PostValidator>();
                services.AddScoped<IValidator<S.Like>, LikeValidator>();
                services.AddScoped<IValidator<S.Activity>, ActivityValidator>();
            }
        }
    }
}
