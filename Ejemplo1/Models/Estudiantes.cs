using System.ComponentModel.DataAnnotations;

namespace Ejemplo1.Models;

public class Estudiantes
{
    [Key]
    public int EstudianteId { get; set; }

    [Required(ErrorMessage = "Debe ingresar un número de matricula")]
    [RegularExpression(@"\d{4}-\d{4}", ErrorMessage = "El formato de la matricula debe ser xxxx-xxxx")]
    public int Matricula { get; set; }

    [Required(ErrorMessage = "Debe ingresar un nombre")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "Debe ingresar un apellido")]
    public string Apellido { get; set; }

    [Required(ErrorMessage = "Debe ingresar una carrera")]
    public string Carrera { get; set; }

    [Range(17,45, ErrorMessage = "La edad debe ser mayor a 16 y menor a 46")]
    public int Edad { get; set; }
}
