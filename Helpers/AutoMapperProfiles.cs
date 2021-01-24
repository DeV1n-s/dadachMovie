using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using dadachMovie.DTOs;
using dadachMovie.Entities;

namespace dadachMovie.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Genre, GenreDTO>().ReverseMap();

            CreateMap<GenreCreationDTO, Genre>();

            CreateMap<Person, PersonDTO>()
                .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Country.Name))
                .ForMember(dest => dest.Nationality, opt => opt.MapFrom(src => src.Country.Nationality))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth.Date))
                .ForPath(dest => dest.DateOfBirthPersian, opt => opt.MapFrom(src => src.DateOfBirth.ToPeString()));

            CreateMap<PersonCreationDTO, Person>()
                .ForMember(dest => dest.Picture, opt => opt.Ignore());

            CreateMap<Person, PersonPatchDTO>().ReverseMap();

            CreateMap<Movie, MovieDTO>()
                .ForMember(dest => dest.ReleaseDate, opt => opt.MapFrom(src => src.ReleaseDate.Date))
                .ForPath(dest => dest.ReleaseDatePersian, opt => opt.MapFrom(src => src.ReleaseDate.ToPeString()));

            // CreateMap<MoviesGenres, GenreDTO>()
            //     .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.GenreId))
            //     .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Genre.Name));
            
            CreateMap<MoviesCasts, CastDTO>()
                .ForMember(dest => dest.PersonName, opt => opt.MapFrom(src => src.Person.Name));

            // CreateMap<MoviesDirectors, DirectorDTO>()
            //     .ForMember(dest => dest.PersonName, opt => opt.MapFrom(src => src.Person.Name));

            CreateMap<CastCreationDTO, MoviesCasts>();

            CreateMap<MovieCreationDTO, Movie>()
                .ForMember(dest => dest.Picture, opt => opt.Ignore())
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(MapMoviesGenres))
                .ForMember(dest => dest.Directors, opt => opt.MapFrom(MapMoviesDirectors))
                .ForMember(dest => dest.Countries, opt => opt.MapFrom(MapMoviesCountries));

            CreateMap<PersonCreationDTO, Person>();
            
            CreateMap<Country, CountryDTO>();

            // CreateMap<MoviesCountries, CountryDTO>().ReverseMap();

            // CreateMap<MoviesCountries, MovieDetailsDTO>()
            //     .ForPath(dest => dest.Countries, opt => opt.MapFrom(src => src.Country.Name));            

            CreateMap<Movie, MovieDetailsDTO>()
                .ForMember(dest => dest.Countries, opt => opt.MapFrom(src => src.Countries.Select(x => x.Name).ToList()))
                .ForMember(dest => dest.AverageUserRate, opt => opt.MapFrom(src => src.MoviesRatings.Average(x => x.Rate)))
                .ForMember(dest => dest.TotalUserRatesCount, opt => opt.MapFrom(src => src.MoviesRatings.Count))
                .ForPath(dest => dest.ReleaseDatePersian, opt => opt.MapFrom(src => src.ReleaseDate.ToPeString()));

            CreateMap<Movie, MoviePatchDTO>().ReverseMap();

            CreateMap<MoviesCasts, PersonDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PersonId))
                .ReverseMap();
            
            CreateMap<MoviesRating, UserMovieRatingDTO>();

            CreateMap<Movie, FavoriteMovieDTO>();

            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.EmailAddress, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country.Name));
            
            CreateMap<User, UserDetailsDTO>()
                .ForMember(dest => dest.EmailAddress, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country.Name));

            CreateMap<UserUpdateDTO, User>()
                .ForMember(dest => dest.Picture, opt => opt.Ignore())
                .ForPath(dest => dest.Country.Id, opt => opt.MapFrom(src => src.CountryId));
            
            CreateMap<CommentCreationDTO, Comment>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => Guid.Parse(src.UserId)));

            CreateMap<Comment, CommentDTO>();

            CreateMap<RequestCreationDTO, Request>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));
            
            CreateMap<Request, RequestDTO>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId.ToString()))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
        }

        private List<Genre> MapMoviesGenres(MovieCreationDTO movieCreationDTO, Movie movie) =>
            movieCreationDTO.GenresId.Select(g => new Genre {Id = g}).ToList();
            //movie.Genres = genres;
            // var result = new List<Genre>();
            // foreach (var id in movieCreationDTO.GenresId)
            // {
            //     result.Add(new Genre() { Id = id });
            // }
            // return result;

        private List<Person> MapMoviesDirectors(MovieCreationDTO movieCreationDTO, Movie movie) =>
            movieCreationDTO.DirectorsId.Select(p => new Person {Id = p}).ToList();
        // {
        //     var result = new List<Person>();
        //     foreach (var id in movieCreationDTO.DirectorsId)
        //     {
        //         result.Add(new Person() { Id = id });
        //     }
        //     return result;
        // }

        private List<Country> MapMoviesCountries(MovieCreationDTO movieCreationDTO, Movie movie) =>
            movieCreationDTO.CountriesId.Select(c => new Country {Id = c}).ToList();
        // {
        //     var result = new List<Country>();
        //     foreach (var id in movieCreationDTO.CountriesId)
        //     {
        //         result.Add(new Country() { Id = id });
        //     }
        //     return result;
        // }

        private float AverageUserRating(Movie movie, MovieDetailsDTO movieDetailsDTO)
        {
            var total = 0;
            var userRates = movie.MoviesRatings.Where(x => x.MovieId == movie.Id).Select(mr => mr.Rate);
            foreach (var rate in userRates)
            {
                total += rate;
            }
            return (total / userRates.Count());
        }
    }
}