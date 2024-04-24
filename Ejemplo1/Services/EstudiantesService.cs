using Ejemplo1.DAL;
using Ejemplo1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ejemplo1.Services;

public class EstudiantesService
{
    private readonly Contexto _contexto;

    public EstudiantesService(Contexto contexto)
    {
        _contexto = contexto;
    }

    public async Task<bool> Crear(Estudiantes estudiante)
    {
        if (!await Existe(estudiante.EstudianteId))
            return await Insertar(estudiante);
        else
            return await Modificar(estudiante);
    }

    public async Task<bool> Insertar(Estudiantes estudiante)
    {
        _contexto.Estudiantes.Add(estudiante);
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Estudiantes estudiante)
    {
		_contexto.Estudiantes.Update(estudiante);
		var modifico = await _contexto.SaveChangesAsync() > 0;
		_contexto.Entry(estudiante).State = EntityState.Detached;
		return modifico;
	}

    public async Task<bool> Existe(int id)
    {
        return await _contexto.Estudiantes
            .AnyAsync(e => e.EstudianteId == id);
    }

    public async Task<bool> Eliminar(int id)
    {
        var elimino = await _contexto.Estudiantes
            .Where(e => e.EstudianteId == id)
            .ExecuteDeleteAsync();

        return elimino > 0;

        //_contexto.Estudiantes.Where(e => e.EstudianteId == id).ExecuteDeleteAsync();
        //return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<Estudiantes?> BuscarId(int id)
    {
        return await _contexto.Estudiantes
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.EstudianteId == id);
    }

    public async Task<List<Estudiantes>> Listar(Expression<Func<Estudiantes,bool>> criterio)
    {
        return await _contexto.Estudiantes
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}
