using AutoMapper;

namespace KairosDs.Persona
{
    public class PersonaMapper : Profile
    {
        public PersonaMapper() 
        {
            CreateMap<ModelPersona, PersonaDto>();
            CreateMap<SavePersonaDto, ModelPersona>();
        }
    }
}
