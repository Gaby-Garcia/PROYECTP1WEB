using PROYECTP1W.Core.Entities;
using PROYECTP1W.Core.Services.Interfaces;
namespace PROYECTP1W.Core.Services;

public class SSEFService : ISSEFService
{
    public void Consult(Users user, List<Sf> lst)
    {
        int opcion;
        do
        {
            Console.WriteLine("\n \n----- Seguimiento de Saldo y Estado Financiero -----");
            Console.WriteLine("1. Consultar Saldo");
            Console.WriteLine("2. Estado Financiero");
            Console.WriteLine("3. Volver al menú principal");
            Console.Write("Seleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion)|| opcion < 1 || opcion > 3)
            {
                Console.WriteLine("Opción no válida. Por favor, ingrese un número válido.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    decimal totalIngresos = lst.Where(sf => sf.tipo == "Ingreso").Sum(sf => sf.monto);
                    decimal totalRetiros = lst.Where(sf => sf.tipo == "Retiro").Sum(sf => sf.monto);
                    Console.WriteLine("El total de ingresos es: $" + totalIngresos);
                    Console.WriteLine("El total de Retiros es: $" + totalRetiros);
                    Console.WriteLine("El Saldo Actual de su Cuenta es: $"+Math.Round( (totalIngresos-totalRetiros), 2));
                    break;
                case 2:
                    Console.WriteLine("Resumen Financiero de la Cuenta:\n");
                    Console.WriteLine("Tipo\tCategoria\tConcepto\tMonto");
                    foreach (var sf in lst)
                    {
                        Console.WriteLine($"{sf.tipo}\t{sf.categoria}\t{sf.concepto}\t${sf.monto}");
                    }
                    Console.WriteLine("Saldo Actual en la Cuenta: $"+(lst.Where(sf => sf.tipo == "Ingreso").Sum(sf => sf.monto)-lst.Where(sf => sf.tipo == "Retiro").Sum(sf => sf.monto)));
                    break;
                case 3:
                 Console.WriteLine("Volver al menú principal :)");
                break;
                default:
                    Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                    break;
            }
        } while (opcion != 3);
    }
}