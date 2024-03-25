using AutoMapper;

namespace KairosDs.Persona
{
    public class PersonaService : IPersonaService
    {
        private readonly ModelDbContext _dbContext;

        private readonly IMapper _mapper;

        public PersonaService(ModelDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IList<PersonaDto> Get()
        {
            var list = _dbContext.Personas
                                        .ToList();

            return _mapper.Map<IList<PersonaDto>>(list);
        }

        public void Save(SavePersonaDto dto)
        {
            var Persona = _mapper.Map<ModelPersona>(dto);
            _dbContext.Personas.Add(Persona);
            _dbContext.SaveChanges();
        }

        public void Update(int id, SavePersonaDto dto)
        {
            var currentPersona = _dbContext.Personas.Find(id);

            if (currentPersona != null && currentPersona.Id == dto.Id)
            {
                _mapper.Map(dto, currentPersona);
                _dbContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var currentPersona = _dbContext.Personas.Find(id);

            if (currentPersona != null)
            {
                var deletePersona = currentPersona;
                deletePersona.LowMark = '9';
                _mapper.Map(deletePersona, currentPersona);
                _dbContext.SaveChanges();
            }
        }

    }

    public interface IPersonaService
    {
        IList<PersonaDto> Get();

        void Save(SavePersonaDto dto);

        void Update(int id, SavePersonaDto dto);

        void Delete(int id);
    }
}
