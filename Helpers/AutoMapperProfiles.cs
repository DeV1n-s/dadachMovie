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
            CreateMap<Genre, GenreDTO>();

            CreateMap<Genre, GenreDetailsDTO>()
                .ForMember(dest => dest.MoviesCount, opt => opt.MapFrom(src => src.Movies.Count));

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
                .ForMember(dest => dest.Picture, opt => opt.Ignore())
                .ForMember(dest => dest.BannerImage, opt => opt.Ignore());
            
            CreateMap<Country, CountryDTO>();
            
            CreateMap<Country, MoviesCountriesDTO>();
         
            CreateMap<Movie, MovieDTO>()
                .ForMember(dest => dest.ReleaseDate, opt => opt.MapFrom(src => src.ReleaseDate.Date))
                .ForMember(dest => dest.AverageUserRate, opt => opt.MapFrom(src => src.MoviesRatings.Any() ? src.MoviesRatings.Average(x => x.Rate) : 0))
                .ForMember(dest => dest.TotalUserRatesCount, opt => opt.MapFrom(src => src.MoviesRatings.Count))
                .ForMember(dest => dest.ReleaseDatePersian, opt => opt.MapFrom(src => src.ReleaseDate.ToPeString()));

            CreateMap<Movie, MovieDetailsDTO>()
                .ForMember(dest => dest.ReleaseDate, opt => opt.MapFrom(src => src.ReleaseDate.Date))
                .ForMember(dest => dest.AverageUserRate, opt => opt.MapFrom(src => src.MoviesRatings.Any() ? src.MoviesRatings.Average(x => x.Rate) : 0))
                .ForMember(dest => dest.TotalUserRatesCount, opt => opt.MapFrom(src => src.MoviesRatings.Count))
                .ForMember(dest => dest.ReleaseDatePersian, opt => opt.MapFrom(src => src.ReleaseDate.ToPeString()));

            CreateMap<Movie, MoviePatchDTO>().ReverseMap();

            CreateMap<MoviesCasts, PersonDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PersonId));
                            
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
                .ForMember(dest => dest.BannerPicture, opt => opt.Ignore())
                .ForPath(dest => dest.Country.Id, opt => opt.MapFrom(src => src.CountryId));
            
            CreateMap<CommentCreationDTO, Comment>();
            
            CreateMap<Comment, MovieCommentDTO>()
                .ForMember(dest => dest.UserFullName, opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName))
                .ForMember(dest => dest.UserPicture, opt => opt.MapFrom(src => src.User.Picture))
                .ForMember(dest => dest.UserRate, 
                    opt => opt.MapFrom(dest => dest.User.MoviesRatings.Any(x => x.MovieId == dest.MovieId) ?
                    dest.User.MoviesRatings.FirstOrDefault(x => x.MovieId == dest.MovieId).Rate : 0));

            CreateMap<RequestCreationDTO, Request>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));
            
            CreateMap<Request, RequestDTO>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId.ToString()))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
            
            CreateMap<UserActivity, UserActivityDTO>();

            CreateMap<Comment, SerieCommentDTO>()
                .ForMember(dest => dest.UserFullName, opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName))
                .ForMember(dest => dest.UserPicture, opt => opt.MapFrom(src => src.User.Picture))
                .ForMember(dest => dest.UserRate, 
                    opt => opt.MapFrom(dest => dest.User.SeriesRatings.Any(x => x.SerieId == dest.SerieId) ?
                    dest.User.SeriesRatings.FirstOrDefault(x => x.SerieId == dest.SerieId).Rate : 0));

            CreateMap<SeriesCasts, CastDTO>()
                .ForMember(dest => dest.PersonName, opt => opt.MapFrom(src => src.Person.Name));

            CreateMap<CastCreationDTO, SeriesCasts>();

            CreateMap<SerieCreationDTO, Serie>()
                .ForMember(dest => dest.Picture, opt => opt.Ignore())
                .ForMember(dest => dest.BannerImage, opt => opt.Ignore());
            
            CreateMap<Country, SeriesCountriesDTO>();

            CreateMap<Serie, SerieDTO>()
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate.Date))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate.GetValueOrDefault().Date))
                .ForMember(dest => dest.AverageUserRate, opt => opt.MapFrom(src => src.SeriesRatings.Any() ? src.SeriesRatings.Average(x => x.Rate) : 0))
                .ForMember(dest => dest.TotalUserRatesCount, opt => opt.MapFrom(src => src.SeriesRatings.Count));

            CreateMap<Serie, SerieDetailsDTO>()
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate.Date))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate.GetValueOrDefault().Date))
                .ForMember(dest => dest.AverageUserRate, opt => opt.MapFrom(src => src.SeriesRatings.Any() ? src.SeriesRatings.Average(x => x.Rate) : 0))
                .ForMember(dest => dest.TotalUserRatesCount, opt => opt.MapFrom(src => src.SeriesRatings.Count));

            CreateMap<Serie, SeriePatchDTO>().ReverseMap();

            CreateMap<SeriesCasts, PersonDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PersonId));
                            
            CreateMap<SeriesRating, UserSerieRatingDTO>();

            CreateMap<Serie, FavoriteSerieDTO>();
        }
    }
}