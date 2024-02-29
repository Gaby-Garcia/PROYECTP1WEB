using PROYECTP1W.Core.Entities;
using PROYECTP1W.Core.Services.Interfaces;

namespace PROYECTP1W.Core.Services;

public class EMPService : IEMPService
{
    public Users GoalsAndLimits(Users user, List<Sf> lst)
    {
        int opcion;
        decimal meta;
        decimal presupuesto;
        Users lcUser = user;
        decimal totalIngresos = lst.Where(sf => sf.tipo == "Ingreso").Sum(sf => sf.monto);
        decimal totalRetiros = lst.Where(sf => sf.tipo == "Retiro").Sum(sf => sf.monto);
        do
        {
            Console.WriteLine("\n \n----- Metas y Presupuestos -----");
            Console.WriteLine("1. Establecer/Modificar tu Meta");
            Console.WriteLine("2. Establecer/Modificar tu Presupuesto");
            Console.WriteLine("3. Consultar Avance de tu Meta");
            Console.WriteLine("4. Consultar Avance de tu Presupuesto");
            Console.WriteLine("5. Volver al menú principal");
            Console.Write("Seleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Opción no válida. Por favor, ingrese un número válido.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Tu meta actual es de: $"+user.meta);
                    Console.WriteLine("Ingresa tu nueva meta:");
                    if (!decimal.TryParse(Console.ReadLine(), out meta))
                    {
                        Console.WriteLine("Por favor, ingrese una cantidad valida.");
                        continue;
                    }
                    user.meta = meta;
                    break;
                case 2:
                    Console.WriteLine("Tu presupuesto actual es de: $"+user.presupuesto);
                    Console.WriteLine("Ingresa tu nueva meta:");
                    if (!decimal.TryParse(Console.ReadLine(), out presupuesto))
                    {
                        Console.WriteLine("Por favor, ingrese una cantidad valida.");
                        continue;
                    }
                    user.presupuesto = presupuesto;
                    break;
                case 3:
                    Console.WriteLine("Tu Saldo Actual es de: $" + (totalIngresos-totalRetiros) );
                    decimal Avance = ( (totalIngresos-totalRetiros) / user.meta) * 100;
                    decimal Faltante = user.meta - (totalIngresos - totalRetiros);
                    if (Faltante < 0)
                    {
                        Console.WriteLine("Ya has logrado tu meta!!");
                    }
                    else
                    {
                        Console.WriteLine($"Llevas un {Avance:F2}%, solo te faltan ${Faltante:F2} para llegar a tu meta :)");
                    }
                    break;
                case 4:
                    Console.WriteLine("Tu total de Gastos es de: $" + totalRetiros);
                    decimal Gastado = ( (totalRetiros) / user.presupuesto) * 100;
                    decimal Restante = user.meta - (totalIngresos-totalRetiros);
                    if (Restante < 0)
                    {
                        Console.WriteLine("Ya te has pasado de tu presupuesto, ya no gastes!");
                    }
                    else
                    {
                        Console.WriteLine($"Has Gastado un {Gastado:F2}%, aun puedes gastar ${Restante:F2} este mes :)");
                    }
                    break;
            }
        } while (opcion != 5);
        return lcUser;
    }
}