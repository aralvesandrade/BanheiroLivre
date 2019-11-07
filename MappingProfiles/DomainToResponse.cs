using AutoMapper;
using banheiro_livre.Domain;
using banheiro_livre.ViewModel;

namespace banheiro_livre.MappingProfiles
{
    public class DomainToResponse : Profile
    {
        public DomainToResponse()
        {
            CreateMap<Banheiro, AdicionarBanheiroPostResponse>();
        }
    }
}