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
                .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.Categories.Select(x => x.Name).ToList()))
                .ForMember(dest => dest.DateOfBirthPersian, opt => opt.MapFrom(src => src.DateOfBirth.ToPeString()));

            CreateMap<PersonCreationDTO, Person>()
                .ForMember(dest => dest.Picture, opt => opt.Ignore());

            CreateMap<Person, PersonPatchDTO>().ReverseMap();

            CreateMap<PersonCreationDTO, Person>();

            CreateMap<Person, DirectorDTO>()
                .ForMember(dest => dest.PersonId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.PersonName, opt => opt.MapFrom(src => src.Name));
            
            CreateMap<MoviesCasts, CastDTO>()
                .ForMember(dest => dest.PersonName, opt => opt.MapFrom(src => src.Person.Name));

            CreateMap<CastCreationDTO, MoviesCasts>();

            CreateMap<MovieCreationDTO, Movie>()
                .ForMember(dest => dest.Picture, opt => opt.Ignore());
            
            CreateMap<Country, CountryDTO>();
         
            CreateMap<Movie, MovieDTO>()
                .ForMember(dest => dest.ReleaseDate, opt => opt.MapFrom(src => src.ReleaseDate.Date))
                .ForMember(dest => dest.AverageUserRate, opt => opt.MapFrom(src => src.MoviesRatings.Any() ? src.MoviesRatings.Average(x => x.Rate) : 0))
                .ForMember(dest => dest.TotalUserRatesCount, opt => opt.MapFrom(src => src.MoviesRatings.Count))
                .ForMember(dest => dest.ReleaseDatePersian, opt => opt.MapFrom(src => src.ReleaseDate.ToPeString()));

            CreateMap<Movie, MovieDetailsDTO>()
                .ForMember(dest => dest.ReleaseDate, opt => opt.MapFrom(src => src.ReleaseDate.Date))
                .ForMember(dest => dest.AverageUserRate, opt => opt.MapFrom(src => src.MoviesRatings.Any() ? src.MoviesRatings.Average(x => x.Rate) : 0))
                .ForMember(dest => dest.TotalUserRatesCount, opt => opt.MapFrom(src => src.MoviesRatings.Count))
                .ForMember(dest => dest.ReleaseDatePersian, opt => opt.MapFrom(src => src.ReleaseDate.ToPeString()))
                .ForMember(dest => dest.Directors, opt => opt.MapFrom(src => src.Directors.ToList()))
                .ForMember(dest => dest.Countries, opt => opt.MapFrom(src => src.Countries.Select(x => x.Name).ToList()));

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
    }
}