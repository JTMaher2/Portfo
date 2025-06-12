using AutoMapper;
using DC = Portfo.API.DataContracts;
using S = Portfo.Services.Model;

namespace Portfo.IoC.Configuration.AutoMapper.Profiles
{
    public class APIMappingProfile : Profile
    {
        public APIMappingProfile()
        {
            // data type mappings
            CreateMap<DC.Requests.Request<string>, S.Requests.Request<string>>().ReverseMap();
            CreateMap<DC.Responses.Response<DC.Requests.Request<string>, int>, S.Responses.Response<S.Requests.Request<string>, int>>().ReverseMap();
        
            // address mappings
            CreateMap<DC.AddressUser, S.UserAddress>().ReverseMap();
            CreateMap<DC.Requests.Request<DC.AddressUser>, S.Requests.Request<S.UserAddress>>().ReverseMap();
            CreateMap<DC.Responses.Response<DC.Requests.Request<DC.Address>, DC.Address>, S.Responses.Response<S.Requests.Request<S.Address>, S.Address>>().ReverseMap();
            CreateMap<DC.Responses.Response<DC.Requests.Request<DC.AddressUser>, DC.AddressUser>, S.Responses.Response<S.Requests.Request<S.UserAddress>, S.UserAddress>>().ReverseMap();
            
            // user mappings
            CreateMap<DC.UserPost, S.PostUser>().ReverseMap();
            CreateMap<DC.Requests.Request<DC.UserPost>, S.Requests.Request<S.PostUser>>().ReverseMap();
            CreateMap<DC.Responses.Response<DC.Requests.Request<DC.User>, DC.User>, S.Responses.Response<S.Requests.Request<S.User>, S.User>>().ReverseMap();
            CreateMap<DC.Responses.Response<DC.Requests.Request<DC.UserPost>, DC.UserPost>, S.Responses.Response<S.Requests.Request<S.PostUser>, S.PostUser>>().ReverseMap();
            
            // post mappings
            CreateMap<DC.PostLike, S.LikePost>().ReverseMap();
            CreateMap<DC.Requests.Request<DC.PostLike>, S.Requests.Request<S.LikePost>>().ReverseMap();
            CreateMap<DC.Responses.Response<DC.Requests.Request<DC.Post>, DC.Post>, S.Responses.Response<S.Requests.Request<S.Post>, S.Post>>().ReverseMap();
            CreateMap<DC.Responses.Response<DC.Requests.Request<DC.PostLike>, DC.PostLike>, S.Responses.Response<S.Requests.Request<S.LikePost>, S.LikePost>>().ReverseMap();
            
            // activity mapping
            CreateMap<DC.Responses.Response<DC.Requests.Request<DC.Activity>, DC.Activity>, S.Responses.Response<S.Requests.Request<S.Activity>, S.Activity>>().ReverseMap();

            // like mapping
            CreateMap<DC.Responses.Response<DC.Requests.Request<DC.Like>, DC.Like>, S.Responses.Response<S.Requests.Request<S.Like>, S.Like>>().ReverseMap();

            // CreateMap<DC.PostCreation, S.Post>().ReverseMap();
            // CreateMap<DC.PostUpdate, S.Post>().ReverseMap();
            // CreateMap<DC.LikeCreation, S.Like>().ReverseMap();
            // CreateMap<DC.Requests.Request<DC.PostCreation>, S.Requests.Request<S.Post>>().ReverseMap();
            // CreateMap<DC.Requests.Request<DC.PostUpdate>, S.Requests.Request<S.Post>>().ReverseMap();
            // CreateMap<DC.Responses.Response<DC.Requests.Request<DC.PostUpdate>, DC.Post>, S.Responses.Response<S.Requests.Request<S.Post>, S.Post>>().ReverseMap();
            // CreateMap<DC.Requests.Request<DC.LikeCreation>, S.Requests.Request<S.Like>>().ReverseMap();
        }
    }
}
