using EstructurasDeDatos.Ejercicio1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructurasDeDatos.Ejercicio1;
internal static class ModuloPersonas
{
    internal static void Alta()
    {
        var personas = new List<PersonaEnt>();

        while (true)
        {
            //1) Pedir los datos para construir un objeto persona
            //2) agregarlo a la lista
            //3)preguntarle al usuario si quiere seguir o no,
            //4)si no, por ahora terminamos.
            //5)si si, seguimos

            var nuevaPersona = IngresarPersona();
            personas.Add(nuevaPersona);
            Console.WriteLine("Se ha agregado una nueva persona.");
            Console.WriteLine($"Cantidad: {personas.Count}");

            Console.WriteLine("¿Desea continuar? [S/N]");
            string continuar = null;
            while (continuar != "S" && continuar != "N")
            {
                continuar = Console.ReadLine();
            }

            if (continuar == "N")
            {
                break;
            }
        }


        PersonaEnt IngresarPersona()
        {
            var persona = new PersonaEnt();

            while (true)
            {

                //Documento
                while (true)
                {
                    Console.Write("Ingrese número de documento.");
                    var ingreso = Console.ReadLine();

                    if (!Validaciones.ValidarEnteroLargo(ingreso, 1_000_000, 99_999_999, out long dni, out string errorEntero))
                    {
                        Console.WriteLine(errorEntero);
                        continue;
                    }

                    persona.NumeroDocumento = dni;
                    break;
                }

                //Nombre
                while (true)
                {
                    Console.WriteLine("Ingrese su nombre");
                    var ingreso = Console.ReadLine();
                    if (!Validaciones.ValidarCadena(ingreso, 1, 50, soloLetras: true, out string errorNombre))
                    {
                        Console.WriteLine(errorNombre);
                        continue;
                    }

                    //sigo validando......

                    persona.Nombre = ingreso;
                    break;
                }

                //Apellido
                while (true)
                {
                    Console.WriteLine("Ingrese su apellido");
                    var ingreso = Console.ReadLine();
                    if (!Validaciones.ValidarCadena(ingreso, 1, 30, soloLetras: true, out string errorApellido))
                    {
                        Console.WriteLine(errorApellido);
                        continue;
                    }

                    //sigo validando......
                    persona.Apellido = ingreso;
                    break;
                }

                //Fecha de nacimiento
                while (true)
                {
                    Console.WriteLine("Ingrese su fecha de nacimiento");
                    var ingreso = Console.ReadLine();
                    if (!Validaciones.ValidarFecha(ingreso, min: null, max: DateTime.Now, out DateTime fecha, out string errorFechaNac))
                    {
                        Console.WriteLine(errorFechaNac);
                        continue;
                    }

                    persona.FechaNacimiento = fecha;
                    break;
                }

                ///etc...
                ///

                if (!persona.Validar(out string error))
                {
                    Console.WriteLine(error);
                    continue;
                }
            }

            return persona;
        }
    }




    internal static void Baja() => throw new NotImplementedException();
    internal static void Modificar() => throw new NotImplementedException();
}
