using AutoMapper;
using BookExchange.Core.Commands;
using BookExchange.Core.Model;
using BookExchange.Infrastructure.DTO;

namespace BookExchange.Infrastructure.Mappers
{
    public class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<User,AccountDTO>();
                cfg.CreateMap<UserDetails,AccountDTO>();
                cfg.CreateMap<UserDetails,UserDetailsDTO>();
                cfg.CreateMap<User,UserDetails>();
                cfg.CreateMap<Book,BookDTO>();
                cfg.CreateMap<Book,BookDetails>();
                cfg.CreateMap<BookDetails,BookDetailsDTO>();
                cfg.CreateMap<UserDetails, SubscriberDTO>();
                cfg.CreateMap<DivisionDetails, DivisionDTO>();
            })
            .CreateMapper();
    }
}