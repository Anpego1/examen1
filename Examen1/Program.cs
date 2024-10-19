using System;
using System.Collections.Generic;
using System.Linq;

class Empleado
{
    public string Cedula { get; set; }
    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public double Salario { get; set; }

    public Empleado(string cedula, string nombre, string direccion, string telefono, double salario)
    {
        Cedula = cedula;
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
        Salario = salario;
    }

    public override string ToString()
    {
        return $"Cédula: {Cedula}, Nombre: {Nombre}, Dirección: {Direccion}, Teléfono: {Telefono}, Salario: {Salario}";
    }
}

class Menu
{
    private List<Empleado> empleados = new List<Empleado>();

    public void MostrarMenu()
    {
        while (true)
        {
            Console.WriteLine("\nMenú Principal");
            Console.WriteLine("1. Agregar Empleados");
            Console.WriteLine("2. Consultar Empleados");
            Console.WriteLine("3. Modificar Empleados");
            Console.WriteLine("4. Borrar Empleados");
            Console.WriteLine("5. Inicializar Arreglos");
            Console.WriteLine("6. Reportes");
            Console.WriteLine("7. Salir");
            Console.Write("Seleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out int opcion))
            {
                Console.WriteLine("Opción inválida.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    AgregarEmpleado();
                    break;
                case 2:
                    ConsultarEmpleados();
                    break;
                case 3:
                    ModificarEmpleado();
                    break;
                case 4:
                    BorrarEmpleado();
                    break;
                case 5:
                    InicializarArreglos();
                    break;
                case 6:
                    Reportes();
                    break;
                case 7:
                    return;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }
    }

    private void AgregarEmpleado()
    {
        Console.Write("Ingrese cédula: ");
        string cedula = Console.ReadLine();
        Console.Write("Ingrese nombre: ");
        string nombre = Console.ReadLine();
        Console.Write("Ingrese dirección: ");
        string direccion = Console.ReadLine();
        Console.Write("Ingrese teléfono: ");
        string telefono = Console.ReadLine();
        Console.Write("Ingrese salario: ");

        if (!double.TryParse(Console.ReadLine(), out double salario))
        {
            Console.WriteLine("Salario inválido.");
            return;
        }

        Empleado empleado = new Empleado(cedula, nombre, direccion, telefono, salario);
        empleados.Add(empleado);
        Console.WriteLine("Empleado agregado.");
    }

    private void ConsultarEmpleados()
    {
        if (empleados.Count == 0)
        {
            Console.WriteLine("No hay empleados registrados.");
            return;
        }

        foreach (var empleado in empleados)
        {
            Console.WriteLine(empleado);
        }
    }

    private void ModificarEmpleado()
    {
        Console.Write("Ingrese cédula del empleado a modificar: ");
        string cedula = Console.ReadLine();

        var empleado = empleados.FirstOrDefault(e => e.Cedula == cedula);
        if (empleado != null)
        {
            Console.Write("Nuevo nombre: ");
            empleado.Nombre = Console.ReadLine();
            Console.Write("Nueva dirección: ");
            empleado.Direccion = Console.ReadLine();
            Console.Write("Nuevo teléfono: ");
            empleado.Telefono = Console.ReadLine();
            Console.Write("Nuevo salario: ");

            if (!double.TryParse(Console.ReadLine(), out double salario))
            {
                Console.WriteLine("Salario inválido.");
                return;
            }
            empleado.Salario = salario;

            Console.WriteLine("Empleado modificado.");
        }
        else
        {
            Console.WriteLine("Empleado no encontrado.");
        }
    }

    private void BorrarEmpleado()
    {
        Console.Write("Ingrese cédula del empleado a borrar: ");
        string cedula = Console.ReadLine();

        var empleado = empleados.FirstOrDefault(e => e.Cedula == cedula);
        if (empleado != null)
        {
            empleados.Remove(empleado);
            Console.WriteLine("Empleado borrado.");
        }
        else
        {
            Console.WriteLine("Empleado no encontrado.");
        }
    }

    private void InicializarArreglos()
    {
        empleados.Clear();
        Console.WriteLine("Arreglos inicializados.");
    }

    private void Reportes()
    {
        while (true)
        {
            Console.WriteLine("\nSubmenú de Reportes");
            Console.WriteLine("1. Consultar empleados por cédula");
            Console.WriteLine("2. Listar empleados por nombre");
            Console.WriteLine("3. Promedio de salarios");
            Console.WriteLine("4. Salario más alto y más bajo");
            Console.WriteLine("5. Regresar");
            Console.Write("Seleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out int opcion))
            {
                Console.WriteLine("Opción inválida.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    ConsultarEmpleadoPorCedula();
                    break;
                case 2:
                    ListarEmpleadosPorNombre();
                    break;
                case 3:
                    PromedioSalarios();
                    break;
                case 4:
                    SalarioMasAltoBajo();
                    break;
                case 5:
                    return;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }
    }

    private void ConsultarEmpleadoPorCedula()
    {
        Console.Write("Ingrese cédula a consultar: ");
        string cedula = Console.ReadLine();

        var empleado = empleados.FirstOrDefault(e => e.Cedula == cedula);
        if (empleado != null)
        {
            Console.WriteLine(empleado);
        }
        else
        {
            Console.WriteLine("Empleado no encontrado.");
        }
    }

    private void ListarEmpleadosPorNombre()
    {
        if (empleados.Count == 0)
        {
            Console.WriteLine("No hay empleados registrados.");
            return;
        }

        var empleadosOrdenados = empleados.OrderBy(e => e.Nombre).ToList();
        foreach (var empleado in empleadosOrdenados)
        {
            Console.WriteLine(empleado);
        }
    }

    private void PromedioSalarios()
    {
        if (!empleados.Any())
        {
            Console.WriteLine("No hay empleados para calcular el promedio.");
            return;
        }
        double promedio = empleados.Average(e => e.Salario);
        Console.WriteLine($"Promedio de salarios: {promedio}");
    }

    private void SalarioMasAltoBajo()
    {
        if (!empleados.Any())
        {
            Console.WriteLine("No hay empleados para calcular.");
            return;
        }
        double maxSalario = empleados.Max(e => e.Salario);
        double minSalario = empleados.Min(e => e.Salario);
        Console.WriteLine($"Salario más alto: {maxSalario}, Salario más bajo: {minSalario}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        menu.MostrarMenu();
    }
}
