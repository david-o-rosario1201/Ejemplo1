using Ejemplo1.Models;
using Microsoft.EntityFrameworkCore;

namespace Ejemplo1.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options)
    {
        
    }

    public DbSet<Estudiantes> Estudiantes { get; set; }
}
