using System;
using System.Collections.Generic;
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

                if (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 3)
                {
                    Console.WriteLine("Opción no válida. Por favor, ingrese un número válido entre 1 y 3.");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        transaction.tipo = "Ingreso";
                        Console.WriteLine("Selecciona la categoría: ");
                        Console.WriteLine("1. Alimentación");
                        Console.WriteLine("2. Transporte");
                        Console.WriteLine("3. Salud");
                        Console.WriteLine("4. Entretenimiento");
                        Console.WriteLine("5. Otros");

                        if (!int.TryParse(Console.ReadLine(), out category) || category < 1 || category > 5)
                        {
                            Console.WriteLine("Opción no válida. Por favor, ingrese un número válido entre 1 y 5.");
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
                            Console.Write("Coloca la cantidad a ingresar: ");
                            if (!decimal.TryParse(Console.ReadLine(), out monto) || monto < 0)
                            {
                                Console.WriteLine("Monto no válido. Por favor, ingrese un monto positivo.");
                                continue;
                            }
                            else
                            {
                                break;
                            }
                        } while (true);

                        transaction.monto = monto;

                        Console.WriteLine("Ingresa el concepto: ");
                        transaction.concepto = Console.ReadLine();

                        transacciones.Add(transaction);
                        break;

                    case 2:
                        transaction.tipo = "Retiro";
                        decimal totalIngresos = 0;
                        decimal totalRetiros = 0;
                        foreach (var sf in transacciones)
                        {
                            if (sf.tipo == "Ingreso")
                                totalIngresos += sf.monto;
                            else if (sf.tipo == "Retiro")
                                totalRetiros += sf.monto;
                        }

                        Console.WriteLine("Saldo Actual: " + (totalIngresos - totalRetiros));
                        Console.WriteLine("Selecciona la categoría: ");
                        Console.WriteLine("1. Alimentación");
                        Console.WriteLine("2. Transporte");
                        Console.WriteLine("3. Salud");
                        Console.WriteLine("4. Entretenimiento");
                        Console.WriteLine("5. Otros");

                        if (!int.TryParse(Console.ReadLine(), out category) || category < 1 || category > 5)
                        {
                            Console.WriteLine("Opción no válida. Por favor, ingrese un número válido entre 1 y 5.");
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
                            if (!decimal.TryParse(Console.ReadLine(), out monto) || monto < 0 || !HaveMoney(monto, (totalIngresos - totalRetiros)))
                            {
                                Console.WriteLine("Monto no válido o excede el saldo disponible. Por favor, ingrese un monto válido.");
                                continue;
                            }
                            else
                            {
                                break;
                            }
                        } while (true);

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

        public bool HaveMoney(decimal monto, decimal saldo)
        {
            return saldo >= monto;
        }
    }
}
