using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using dadachMovie.DTOs;
using dadachMovie.Entities;
using Microsoft.AspNetCore.Identity;

namespace dadachMovie.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Genre, GenreDTO>().ReverseMap();

            CreateMap<GenreCreationDTO, Genre>();

            CreateMap<Person, PersonDTO>()
                .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Countries.Country.Name))
                .ForMember(dest => dest.Nationality, opt => opt.MapFrom(src => src.Countries.Country.Nationality));

            CreateMap<PersonCreationDTO, Person>()
                .ForMember(dest => dest.Picture, opt => opt.Ignore());

            CreateMap<Person, PersonPatchDTO>().ReverseMap();

            CreateMap<Movie, MovieDTO>()
                .ForMember(dest => dest.Countries, opt => opt.MapFrom(src => src.Countries.Select(x => x.Country.Name).ToList()));

            CreateMap<MoviesGenres, GenreDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.GenreId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Genre.Name));
            
            CreateMap<MoviesCasts, CastDTO>()
                .ForMember(dest => dest.PersonId, opt => opt.MapFrom(src => src.PersonId))
                .ForMember(dest => dest.Character, opt => opt.MapFrom(src => src.Character))
                .ForMember(dest => dest.PersonName, opt => opt.MapFrom(src => src.Person.Name));

            CreateMap<MoviesDirectors, DirectorDTO>()
                .ForMember(dest => dest.PersonId, opt => opt.MapFrom(src => src.PersonId))
                .ForMember(dest => dest.PersonName, opt => opt.MapFrom(src => src.Person.Name));

            CreateMap<CastCreationDTO, MoviesCasts>()
                .ForMember(dest => dest.PersonId, opt => opt.MapFrom(src => src.PersonId))
                .ForMember(dest => dest.Character, opt => opt.MapFrom(src => src.Character));

            CreateMap<MovieCreationDTO, Movie>()
                .ForMember(dest => dest.Picture, opt => opt.Ignore())
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(MapMoviesGenres))
                .ForMember(dest => dest.Directors, opt => opt.MapFrom(MapMoviesDirectors))
                .ForMember(dest => dest.Countries, opt => opt.MapFrom(MapMoviesCountries));

            CreateMap<PersonCreationDTO, Person>()
                .ForPath(dest => dest.Countries.CountryId, member => member.MapFrom(src => src.CountryId));

            CreateMap<MoviesCountries, CountryDTO>().ReverseMap();

            CreateMap<MoviesCountries, MovieDetailsDTO>()
                .ForPath(dest => dest.Countries, opt => opt.MapFrom(src => src.Country.Name));
            
            CreateMap<PeopleCountries, CountryDTO>().ReverseMap();
            
            CreateMap<PeopleCountries, PersonDTO>().ReverseMap();

            CreateMap<Movie, MovieDetailsDTO>()
                .ForMember(dest => dest.Countries, opt => opt.MapFrom(src => src.Countries.Select(x => x.Country.Name).ToList()));

            CreateMap<Movie, MoviePatchDTO>().ReverseMap();

            CreateMap<MoviesCasts, PersonDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PersonId))
                .ReverseMap();
            
            CreateMap<IdentityUser, UserDTO>()
                .ForMember(dest => dest.EmailAddress, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id));
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

        private List<MoviesCountries> MapMoviesCountries(MovieCreationDTO movieCreationDTO, Movie movie)
        {
            var result = new List<MoviesCountries>();
            foreach (var id in movieCreationDTO.CountriesId)
            {
                result.Add(new MoviesCountries() { CountryId = id });
            }
            return result;
        }
    }
}