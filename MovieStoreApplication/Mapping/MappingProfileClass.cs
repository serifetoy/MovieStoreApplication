using AutoMapper;
using MovieStoreApplication.Business.DTOs.ActorDTOs;
using MovieStoreApplication.Business.DTOs.CustomerDTOs;
using MovieStoreApplication.Business.DTOs.DirectorDTOs;
using MovieStoreApplication.Business.DTOs.GenreDTOs;
using MovieStoreApplication.Business.DTOs.MovieDTOs;
using MovieStoreApplication.Business.DTOs.OrderDTOs;
using MovieStoreApplication.Data.Entity;

namespace MovieStoreApplication.Mapping
{
    public class MappingProfileClass : Profile
    {
        public MappingProfileClass()
        {
            CreateMap<CreateMovieDto, Movie>().ReverseMap();

            CreateMap<UpdateMovieDto, Movie>().ReverseMap();

            CreateMap<GetMovieDto,Movie > ().ReverseMap();
            
            CreateMap<ActorDto,Actor > ().ReverseMap();

            CreateMap<CustomerDto,Customer > ().ReverseMap();

            CreateMap<DirectorDto, Director > ().ReverseMap();

            CreateMap<GenreDto,Genre > ().ReverseMap();

            CreateMap<OrderDto,Order > ().ReverseMap();
            

        }

    }
}
