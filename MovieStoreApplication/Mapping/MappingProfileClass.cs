using AutoMapper;
using MovieStoreApplication.Business.DTOs.MovieDTOs;
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

        }

    }
}
