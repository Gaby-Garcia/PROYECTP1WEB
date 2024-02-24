using System;
using PROYECTP1W.Core.Entities;
using PROYECTP1W.Core.Managers;
using PROYECTP1W.Core.Services;

namespace PROYECTP1W.Console
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var sfService = new SfService();
            var users = new Users();
            int option;
            do
            {
                System.Console.WriteLine("----- Menu del Sistema -----");
                System.Console.WriteLine("1. Registro de Transacciones");
                System.Console.WriteLine("2. Seguimiento de Saldo y Estado Financiero");
                System.Console.WriteLine("3. Meta");
                System.Console.WriteLine("0. Salir del Sistema");
                System.Console.Write("Ingresa una opción: ");
                string input = System.Console.ReadLine();
                
                if (!int.TryParse(input, out option))
                {
                    System.Console.WriteLine("Opción no válida. Por favor, ingrese un número válido.");
                    continue;
                }

                switch (option)
                {
                    case 1:
                        sfService.IncomeSf(users);
                        break;
                    case 2:
                        // Llama a la función de seguimiento de saldo y estado financiero
                        break;
                    case 3:
                        // Llama a la función de la meta
                        break;
                    case 0:
                        System.Console.WriteLine("Ha salido del sistema, que tenga un buen dia!! :)");
                        break;
                    default:
                        System.Console.WriteLine("No es una opcion del Sistema");
                        break;
                }
            } while (option != 0);
        }
    }
}
