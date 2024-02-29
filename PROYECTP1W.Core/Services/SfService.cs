using System;
using PROYECTP1W.Core.Entities;
using PROYECTP1W.Core.Services.Interfaces;

namespace PROYECTP1W.Core.Services
{
    public class SfService : ISfService
    {
        public List<Sf> IncomeSf(Users user, List<Sf> transacciones)
        {
            int opcion;
            int category;
            decimal monto;
            do
            {
                Sf transaction = new Sf();
                Console.WriteLine("\n \n----- Registro de Transacciones -----");
                Console.WriteLine("1. Ingresar transacción");
                Console.WriteLine("2. Retirar transacción");
                Console.WriteLine("3. Volver al menú principal");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Opción no válida. Por favor, ingrese un número válido.");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        transaction.tipo = "Ingreso";
                        //Console.WriteLine("Saldo Actual: " + /*Agregar aqui la parte para el saldo*/);
                        Console.WriteLine("Selecciona la categoría: ");
                        Console.WriteLine("1. Alimentación");
                        Console.WriteLine("2. Transporte");
                        Console.WriteLine("3. Salud");
                        Console.WriteLine("4. Entetenimeinto");
                        Console.WriteLine("5. Otros");
                        
                        if (!int.TryParse(Console.ReadLine(), out category))
                        {
                            Console.WriteLine("Opción no válida. Por favor, ingrese un número válido.");
                            continue;
                        }
                        switch (category)
                        {
                            case 1:
                                transaction.categoria = "Alimentación";
                                break;
                            case 2:
                                transaction.categoria = "Transporte";
                                break;
                            case 3:
                                transaction.categoria = "Salud";
                                break;
                            case 4:
                                transaction.categoria = "Entretenimiento";
                                break;
                            case 5:
                                transaction.categoria = "Otros";
                                break;
                            default:
                                Console.WriteLine("Selecciona una categoria valida");
                                break;
                        }
                        do
                        {
                            Console.Write("Coloca la cantidad a ingresar: ");
                            if (!decimal.TryParse(Console.ReadLine(), out monto))
                            {
                                Console.WriteLine("Opción no válida. Por favor, ingrese un monto válido.");
                                continue;
                            }

                            if (monto < 0)
                            {
                                Console.WriteLine("Ingresa un monto valido");
                                continue;
                            }
                        } while (monto < 0);
                        transaction.monto = monto;
                        Console.WriteLine("Ingresa el concepto: ");
                        transaction.concepto = Console.ReadLine();
                        transacciones.Add(transaction);
                        break;
                    case 2:
                        transaction.tipo = "Retiro";
                        decimal totalIngresos = transacciones.Where(sf => sf.tipo == "Ingreso").Sum(sf => sf.monto);
                        decimal totalRetiros = transacciones.Where(sf => sf.tipo == "Retiro").Sum(sf => sf.monto);
                        Console.WriteLine("Saldo Actual: " + (totalIngresos-totalRetiros) );
                        Console.WriteLine("Selecciona la categoría: ");
                        Console.WriteLine("1. Alimentación");
                        Console.WriteLine("2. Transporte");
                        Console.WriteLine("3. Salud");
                        Console.WriteLine("4. Entetenimeinto");
                        Console.WriteLine("5. Otros");
                        
                        if (!int.TryParse(Console.ReadLine(), out category))
                        {
                            Console.WriteLine("Opción no válida. Por favor, ingrese un número válido.");
                            continue;
                        }
                        
                        switch (category)
                        {
                            case 1:
                                transaction.categoria = "Alimentación";
                                break;
                            case 2:
                                transaction.categoria = "Transporte";
                                break;
                            case 3:
                                transaction.categoria = "Salud";
                                break;
                            case 4:
                                transaction.categoria = "Entretenimiento";
                                break;
                            case 5:
                                transaction.categoria = "Otros";
                                break;
                        }
                        do
                        {
                            Console.Write("Coloca la cantidad a retirar: ");
                            if ((!decimal.TryParse(Console.ReadLine(), out monto)) || monto > (totalIngresos-totalRetiros))
                            {
                                Console.WriteLine("Opción no válida. Por favor, ingrese un monto válido.");
                                continue;
                            }

                            if (monto < 0)
                            {
                                Console.WriteLine("Ingresa un monto valido");
                                continue;
                            }
                        } while (monto < 0);
                        transaction.monto = monto;
                        Console.WriteLine("Ingresa el concepto: ");
                        transaction.concepto = Console.ReadLine();
                        transacciones.Add(transaction);
                        break;
                    case 3:
                        Console.WriteLine("Volver al menú principal :)");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                        break;
                }
            } while (opcion != 3);
            return transacciones;
        }
    }
}
