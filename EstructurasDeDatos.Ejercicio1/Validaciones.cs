using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructurasDeDatos.Ejercicio1;
internal static class Validaciones
{
    //UNA de estas para cada tipo, estricto.
    public static bool ValidarEnteroLargo(string ingreso, long? minimo, long? maximo, out long valor, out string error)
    {
        var valido = long.TryParse(ingreso, out valor);
        if (!valido)
        {
            error = "Ingrese un número entero válido.";
            return false;
        }

        //validar mínimo...
        if (minimo.HasValue && valor < minimo.Value)
        {
            error = $"Ingrese un número mayor o igual a {minimo}.";
            return false;
        }

        //validar máximo
        if (maximo.HasValue && valor > maximo.Value)
        {
            error = $"Ingrese un número menor o igual a {maximo}";
            return false;
        }

        //otras validaciones.... ???

        //si todo OK:
        error = null;
        return true;
    }

    public static bool ValidarFecha(string ingreso, DateTime? min, DateTime? max, out DateTime valor, out string error)
    {
        throw new NotImplementedException("Les queda de ejercicio");
    }

    public static bool ValidarCadena(string ingreso, int? minCaracteres, int? maxCaracteres, bool soloLetras, out string mensajeError)
    {
        if (minCaracteres.HasValue && (ingreso == null || ingreso.Length < minCaracteres))
        {
            mensajeError = $"Debe ingresar al menos {minCaracteres} caracteres.";
            return false;
        }

        if (maxCaracteres.HasValue && ingreso.Length > maxCaracteres)
        {
            mensajeError = "Debe ser menor a 30 caracteres";
            return false;
        }

        if (soloLetras)
        {
            foreach (char caracter in ingreso.ToLower())
            {
                if ((caracter < 'a' || caracter > 'z') && caracter != ' ')
                {
                    mensajeError = "Utilice letras y espacio solamente.";
                    return false;
                }
            }
        }

        //puedo agregar mas condiciones...

        mensajeError = null;
        return true;
    }

}
