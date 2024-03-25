namespace KairosDs.Persona
{
    public class SavePersonaDto
    {
        public int? Id { get; set; }

        public string? Name { get; set; }

        public string? LastName { get; set; }

        public string? DNI { get; set; }

        public string? Birthdate { get; set; }

        public char LowMark { get; set; }
    }
}
