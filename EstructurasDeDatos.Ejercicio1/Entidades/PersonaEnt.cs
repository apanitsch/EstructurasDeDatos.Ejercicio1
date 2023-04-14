using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructurasDeDatos.Ejercicio1.Entidades;

internal class PersonaEnt
{
    public long NumeroDocumento { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public DateTime FechaNacimiento { get; set; }

    //Hay veces que en vez de un Validar tenemos
    //varios, uno para cada operacion. Por ejemplo:
    //ValidarAlta y ValidarModificacion.
    //De todas maneras SIEMPRE empezamos con UNO, y vamos complejizando
    //a medida que aparece.
    internal bool Validar(out string error)
    {
        //validaciones que sólo sentido para una persona
        //(y no, por ejemplo, para otras entidades talos como un viaje o una factura)

        if (FechaNacimiento < DateTime.Today.AddYears(-120))
        {
            error = "Una persona no puede tener más de 120 años.";
            return false;
        }

        error = null;
        return true;
    }
}
