using AutoMapper;
using banheiro_livre.Domain;
using banheiro_livre.ViewModel;

namespace banheiro_livre.MappingProfiles
{
    public class RequestToDomain : Profile
    {
        public RequestToDomain()
        {
            CreateMap<AdicionarBanheiroPostRequest, Banheiro>();
        }
    }
}