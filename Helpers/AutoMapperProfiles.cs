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
                .ForMember(x => x.Picture, options => options.Ignore());

            CreateMap<Person, PersonPatchDTO>().ReverseMap();

            CreateMap<Movie, MovieDTO>().ReverseMap();

            CreateMap<MoviesGenres, GenreDTO>()
            .ForMember(x => x.Id, options => options.MapFrom(x => x.GenreId))
            .ForMember(x => x.Name, options => options.MapFrom(x => x.Genre.Name));

            CreateMap<MovieCreationDTO, Movie>()
                .ForMember(x => x.Picture, options => options.Ignore())
                .ForMember(x => x.Genres, options => options.MapFrom(MapMoviesGenres))
                .ForMember(x => x.Casters, options => options.MapFrom(MapMovieCasters))
                .ForMember(x => x.Directors, options => options.MapFrom(MapMoviesDirectors));

            CreateMap<Movie, MovieDetailsDTO>()
               //.ForMember(x => x.Genres, options => options.MapFrom(MapMoviesGenres))
               .ForMember(x => x.Casters, options => options.MapFrom(MapMovieCasters))
               .ForMember(x => x.Directors, options => options.MapFrom(MapMoviesDirectors));

            CreateMap<Movie, MoviePatchDTO>().ReverseMap();
        }

        private List<GenreDTO> MapMoviesGenres(Movie movie, MovieDetailsDTO movieDetailsDTO)
        {
            var result = new List<GenreDTO>();
            foreach (var moviegenre in movie.Genres)
            {
                result.Add(new GenreDTO() { Id = moviegenre.GenreId, Name = moviegenre.Genre.Name });
            }
            return result;
        }

        private List<CasterDTO> MapMovieCasters(Movie movie, MovieDetailsDTO movieDetailsDTO)
        {
            var result = new List<CasterDTO>();
            foreach (var caster in movie.Casters)
            {
                result.Add(new CasterDTO() { PersonId = caster.PersonId, Character = caster.Character, PersonName = caster.Person.Name });
            }
            return result;
        }

        private List<DirectorDTO> MapMoviesDirectors(Movie movie, MovieDetailsDTO movieDetailsDTO)
        {
            var result = new List<DirectorDTO>();
            foreach (var director in movie.Directors)
            {
                result.Add(new DirectorDTO() { PersonId = director.PersonId, PersonName = director.Person.Name });
            }
            return result;
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

        private List<MoviesActors> MapMovieCasters(MovieCreationDTO movieCreationDTO, Movie movie)
        {
            var result = new List<MoviesActors>();
            foreach (var caster in movieCreationDTO.Casters)
            {
                result.Add(new MoviesActors() { PersonId = caster.PersonId, Character = caster.Character });
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