using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructurasDeDatos.Ejercicio1.Entidades;

internal class PersonaEnt
{
    public long NumeroDocumento { get; set; }
    public string Nombre { get; set;}
    public string Apellido { get; set; }
    public DateTime FechaNacimiento { get; set; }
}
