using EstructurasDeDatos.Ejercicio1.Entidades;

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

    //Documento
    while (true)
    {
        Console.Write("Ingrese número de documento.");
        var ingreso = Console.ReadLine();
        //Devuelve true si pudo convertir a long, false si no.
        //En la variable de salida ("out") esta el valor como un long
        //La gracia de los Try... es que NUNCA dan error.
        var valido = long.TryParse(ingreso, out var dni);
        if (!valido) //if "algo está mal" ....
        {
            //Le digo al usuario "lo que está mal" 
            //(que es traducir el if)
            Console.WriteLine("Ingrese un número entero válido.");
            continue; //y lo obligo a reintentar.
        }

        //validar otra cosa...
        if (dni < 1_000_000)
        {
            Console.WriteLine("Ingrese un número mayor o igual a 1 000 000.");
            continue;
        }

        if (dni > 99_999_999)
        {
            Console.WriteLine("Ingrese un número menor o igual a 99 999 999");
            continue;
        }

        //etc... más validaciones si hacen falta....


        persona.NumeroDocumento = dni;
        break;
    }

    //Nombre
    while (true)
    {
        Console.WriteLine("Ingrese su nombre");
        var ingreso = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(ingreso))
        {
            Console.WriteLine("El nombre es requerido.");
            continue;
        }

        if (ingreso.Length > 30)
        {
            Console.WriteLine("Debe ser menor a 30 caracteres");
            continue;
        }

        bool ok = true;
        foreach(char caracter in ingreso.ToLower())
        {
            if((caracter < 'a' || caracter > 'z') && caracter != ' ')
            {
                Console.WriteLine("Utilice letras y espacio solamente.");
                ok = false;
            }
        }
        if (!ok)
        {
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
        if (string.IsNullOrWhiteSpace(ingreso))
        {
            Console.WriteLine("El apellido es requerido.");
            continue;
        }

        if (ingreso.Length > 30)
        {
            Console.WriteLine("Debe ser menor a 30 caracteres");
            continue;
        }

        bool ok = true;
        foreach (char caracter in ingreso.ToLower())
        {
            if ((caracter < 'a' || caracter > 'z') && caracter != ' ')
            {
                Console.WriteLine("Utilice letras y espacio solamente.");
                ok = false;
            }
        }
        if (!ok)
        {
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

        var valido = DateTime.TryParse(ingreso, out var fecha);
        if (!valido)
        {
            Console.WriteLine("Ingrese una fecha válida.");
            continue;
        }

        if(fecha < DateTime.Now)
        {
            Console.WriteLine("La fecha debe ser menor a la actual.");
            continue;
        }

        //sigo validando......

        persona.FechaNacimiento = fecha;
        break;
    }

    return persona;
}
