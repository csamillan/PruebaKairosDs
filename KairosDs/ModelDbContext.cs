using KairosDs.Persona;
using Microsoft.EntityFrameworkCore;

namespace KairosDs
{
    public class ModelDbContext : DbContext
    {
        public ModelDbContext(DbContextOptions options) : base(options) { }

        public DbSet<ModelPersona> Personas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<ModelPersona> personaInit = new List<ModelPersona>();

            personaInit.Add(new ModelPersona
            {
                Id = 1,
                Name = "Carlos",
                LastName = "Samillan",
                DNI = "72842671",
                Birthdate = "02/05/1995",
                LowMark = '0',
            });

            modelBuilder.Entity<ModelPersona>(Persona =>
            {
                Persona.ToTable("Persona");
                Persona.HasKey(p => p.Id);

                Persona.Property(p => p.Name)
                                        .IsRequired()
                                        .HasMaxLength(50);
                Persona.Property(p => p.LastName)
                                        .IsRequired()
                                        .HasMaxLength(100);
                Persona.Property(p => p.DNI)
                                        .IsRequired()
                                        .HasMaxLength(8);
                Persona.Property(p => p.Birthdate)
                                        .IsRequired()
                                        .HasMaxLength(10);
                Persona.Property(p => p.LowMark)
                                        .IsRequired()
                                        .HasMaxLength(1);

                Persona.HasData(personaInit);
            });
        }
    }
}
