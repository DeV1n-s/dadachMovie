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
    public class PeopleService : IPeopleService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IFileStorageService _fileStorageService;
        private readonly string _containerName = "people";

        public PeopleService(AppDbContext dbContext, 
                            IMapper mapper,
                            IFileStorageService fileStorageService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _fileStorageService = fileStorageService;
        }

        public async Task<List<PersonDTO>> GetPeopleListAsync(PaginationDTO paginationDTO)
        {
            var people = await _dbContext.People.AsNoTracking().ToListAsync();
            return _mapper.Map<List<PersonDTO>>(people);
        }

        public async Task<PersonDTO> GetPersonByIdAsync(int id)
        {
            var person = await _dbContext.People.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
            return _mapper.Map<PersonDTO>(person);
        }

        public IQueryable<Person> GetPeopleQueryable() =>
            _dbContext.People.AsNoTracking().AsQueryable();

        public async Task<List<MovieDetailsDTO>> GetCastMoviesListAsync(int id) =>
            await _dbContext.Movies.ProjectTo<MovieDetailsDTO>(_mapper.ConfigurationProvider)
                                .Where(x => x.Casts.Any(x => x.PersonId == id))
                                .ToListAsync();

        public async Task<List<MovieDetailsDTO>> GetDirectorMoviesListAsync(int id) =>
            await _dbContext.Movies.ProjectTo<MovieDetailsDTO>(_mapper.ConfigurationProvider)
                                .Where(x => x.Directors.Any(x => x.PersonId == id))
                                .ToListAsync();
        
        public async Task<Paging<PersonDTO>> FilterPeopleListAsync(GridifyQuery gridifyQuery)
        {
            var queryable = await _dbContext.People.GridifyQueryableAsync(gridifyQuery,null);
            return new Paging<PersonDTO> {Items = queryable.Query.ProjectTo<PersonDTO>(_mapper.ConfigurationProvider).ToList(),
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
            await this.SaveChangesAsync();
            return _mapper.Map<PersonDTO>(person);
        }

        public async Task<bool> UpdatePersonAsync(int id, PersonCreationDTO personCreationDTO)
        {
            var personDb = await _dbContext.People.FirstOrDefaultAsync(p => p.Id == id);
            if (personDb == null)
                return false;

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

            await this.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePersonAsync(int id)
        {
            var exists = await this.GetPersonByIdAsync(id);
            if (exists == null)
                return false;

            _dbContext.Remove(new Person() {Id = id});
            await this.SaveChangesAsync();
            return true;
        }

        public void SaveChanges() =>
            _dbContext.SaveChanges();

        public async Task SaveChangesAsync() =>
            await _dbContext.SaveChangesAsync();
    }
}