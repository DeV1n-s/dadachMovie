using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using dadachMovie.Contracts;
using dadachMovie.DTOs;
using dadachMovie.Entities;
using Gridify;
using Gridify.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace dadachMovie.Services
{
    public class PeopleService : BaseService, IPeopleService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IFileStorageService _fileStorageService;
        private readonly ILoggerService _logger;
        private readonly string _containerName = "people";

        public PeopleService(AppDbContext dbContext, 
                            IMapper mapper,
                            IFileStorageService fileStorageService,
                            ILoggerService logger)
            : base(dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _fileStorageService = fileStorageService;
            _logger = logger;
        }

        public async Task<Paging<PersonDTO>> GetPeoplePagingAsync(GridifyQuery gridifyQuery)
        {
            var queryable = await _dbContext.People.GridifyQueryableAsync(gridifyQuery,null);
            return new Paging<PersonDTO> {Items = queryable.Query.ProjectTo<PersonDTO>(_mapper.ConfigurationProvider).ToList(),
                                        TotalItems = queryable.TotalItems};
        }

        public async Task<PersonDTO> GetPersonByIdAsync(int id)
        {
            var person = await _dbContext.People.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
            return _mapper.Map<PersonDTO>(person);
        }

        public IQueryable<Person> GetPeopleQueryable() =>
            _dbContext.People.AsNoTracking().AsQueryable();

        public async Task<Paging<MovieDetailsDTO>> GetCastMoviesListAsync(int id, GridifyQuery gridifyQuery)
        {
            var queryable = await _dbContext.Movies.Where(x => x.Casts.Any(y => y.PersonId == id))
                                                .GridifyQueryableAsync(gridifyQuery, null);

            return new Paging<MovieDetailsDTO> {Items = queryable.Query
                                                                .ProjectTo<MovieDetailsDTO>(_mapper.ConfigurationProvider)
                                                                .ToList(),
                                                TotalItems = queryable.TotalItems};
        }

        public async Task<Paging<MovieDetailsDTO>> GetDirectorMoviesListAsync(int id, GridifyQuery gridifyQuery)
        {
            var queryable = await _dbContext.Movies.Where(x => x.Directors.Any(y => y.PersonId == id))
                                                .GridifyQueryableAsync(gridifyQuery, null);

            return new Paging<MovieDetailsDTO> {Items = queryable.Query
                                                                .ProjectTo<MovieDetailsDTO>(_mapper.ConfigurationProvider)
                                                                .ToList(),
                                                TotalItems = queryable.TotalItems};
        }

        public async Task<PersonDTO> AddPersonAsync(PersonCreationDTO personCreationDTO)
        {
            var person = _mapper.Map<Person>(personCreationDTO);

            if (personCreationDTO.Picture != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await personCreationDTO.Picture.CopyToAsync(memoryStream);
                    var content = memoryStream.ToArray();
                    var extension = Path.GetExtension(personCreationDTO.Picture.FileName);
                    person.Picture = await _fileStorageService.SaveFile(content, 
                                                                    extension, 
                                                                    _containerName, 
                                                                    personCreationDTO.Picture.ContentType);
                }
            }

            _dbContext.Add(person);
            try
            {
                await this.SaveChangesAsync();
                _logger.LogInfo($"Person \"{personCreationDTO.Name}\" was added successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogWarn($"Failed to add person \"{personCreationDTO.Name}\". Exception: {ex}");
            }
            
            return _mapper.Map<PersonDTO>(person);
        }

        public async Task<int> UpdatePersonAsync(int id, PersonCreationDTO personCreationDTO)
        {
            var personDb = await _dbContext.People.FirstOrDefaultAsync(p => p.Id == id);
            if (personDb == null)
            {
                _logger.LogWarn($"Person with ID {id} was not found");
                return -1;
            }

            personDb = _mapper.Map(personCreationDTO, personDb);

            if (personCreationDTO.Picture != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await personCreationDTO.Picture.CopyToAsync(memoryStream);
                    var content = memoryStream.ToArray();
                    var extension = Path.GetExtension(personCreationDTO.Picture.FileName);
                    personDb.Picture = await _fileStorageService.EditFile(content,
                                                                        extension,
                                                                        _containerName, 
                                                                        personDb.Picture, 
                                                                        personCreationDTO.Picture.ContentType);
                }
            }

            try
            {
                await this.SaveChangesAsync();
                _logger.LogInfo($"Person with ID {id} was updated successfully");
                return 1;
            }
            catch(Exception ex)
            {
                _logger.LogWarn($"Failed to update person with ID {id}. Exception: {ex}");
                return 0;
            }
        }

        public async Task<int> DeletePersonAsync(int id)
        {
            var exists = await this.GetPersonByIdAsync(id);
            if (exists == null)
            {
                _logger.LogWarn($"Person with ID {id} was not found");
                return -1;
            }

            _dbContext.Remove(new Person() {Id = id});
            try
            {
                await this.SaveChangesAsync();
                _logger.LogInfo($"Person with ID {id} was removed successfully");
                return 1;
            }
            catch(Exception ex)
            {
                 _logger.LogWarn($"Failed to remove person with ID {id}. Exception: {ex}");
                return 0;
            }
        }
    }
}