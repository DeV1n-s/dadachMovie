using System.Collections.Generic;
using AutoMapper;
using dadachAPI.DTOs;
using dadachAPI.Entities;

namespace dadachAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Genre, GenreDTO>().ReverseMap();

            CreateMap<GenreCreationDTO, Genre>();

            CreateMap<Person, PersonDTO>().ReverseMap();

            CreateMap<PersonCreationDTO, Person>()
                .ForMember(x => x.Picture, opt => opt.Ignore());

            CreateMap<Person, PersonPatchDTO>().ReverseMap();

            CreateMap<Movie, MovieDTO>().ReverseMap();

            CreateMap<MoviesGenres, GenreDTO>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.GenreId))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Genre.Name));
            
            CreateMap<MoviesCasters, CasterDTO>()
                .ForMember(x => x.PersonId, opt => opt.MapFrom(x => x.PersonId))
                .ForMember(x => x.Character, opt => opt.MapFrom(x => x.Character))
                .ForMember(x => x.PersonName, opt => opt.MapFrom(x => x.Person.Name));

            CreateMap<MoviesDirectors, DirectorDTO>()
                .ForMember(x => x.PersonId, opt => opt.MapFrom(x => x.PersonId))
                .ForMember(x => x.PersonName, opt => opt.MapFrom(x => x.Person.Name));

            CreateMap<CasterCreationDTO, MoviesCasters>()
                .ForMember(x => x.PersonId, opt => opt.MapFrom(x => x.PersonId))
                .ForMember(x => x.Character, opt => opt.MapFrom(x => x.Character));

            CreateMap<MovieCreationDTO, Movie>()
                .ForMember(x => x.Picture, opt => opt.Ignore())
                .ForMember(x => x.Genres, opt => opt.MapFrom(MapMoviesGenres))
                .ForMember(x => x.Directors, opt => opt.MapFrom(MapMoviesDirectors));

            CreateMap<Movie, MovieDetailsDTO>();

            CreateMap<Movie, MoviePatchDTO>().ReverseMap();
        }

        private List<MoviesGenres> MapMoviesGenres(MovieCreationDTO movieCreationDTO, Movie movie)
        {
            var result = new List<MoviesGenres>();
            foreach (var id in movieCreationDTO.GenresId)
            {
                result.Add(new MoviesGenres() { GenreId = id });
            }
            return result;
        }

        private List<MoviesDirectors> MapMoviesDirectors(MovieCreationDTO movieCreationDTO, Movie movie)
        {
            var result = new List<MoviesDirectors>();
            foreach (var id in movieCreationDTO.DirectorsId)
            {
                result.Add(new MoviesDirectors() { PersonId = id });
            }
            return result;
        }
    }
}