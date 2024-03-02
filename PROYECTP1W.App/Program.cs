using System;
using System.Collections.Generic;
using PROYECTP1W.Core.Entities;
using PROYECTP1W.Core.Managers;
using PROYECTP1W.Core.Services;

namespace PROYECTP1W.Console
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var user = new Users();
            List<Sf> lstSf = new List<Sf>();

            System.Console.WriteLine("Ingresa por favor tu nombre");
            user.nombre = System.Console.ReadLine();

            int option;
            do
            {
                System.Console.WriteLine("Bienvenid@ " + user.nombre + "!");
                System.Console.WriteLine("----- Menu del Sistema -----");
                System.Console.WriteLine("1. Registro de Transacciones");
                System.Console.WriteLine("2. Seguimiento de Saldo y Estado Financiero");
                System.Console.WriteLine("3. Establecimiento de metas y presupuestos");
                System.Console.WriteLine("4. Salir del Sistema");
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
                        var serviceSf = new SfService();
                        var managerSf = new SfManager(serviceSf);
                        lstSf = managerSf.GetSf(user, lstSf);
                        break;
                    case 2:
                        var serviceSSEF = new SSEFService();
                        var managerSSEF = new SSEFManager(serviceSSEF);
                        managerSSEF.GetSSEF(user, lstSf);
                        break;
                    case 3:
                        var serviceEMP = new EMPService();
                        var managerEMP = new EMPManager(serviceEMP);
                        managerEMP.GetEMP(user, lstSf);
                        break;
                    case 4:
                        System.Console.WriteLine("Ha salido del sistema, que tenga un buen día!! :)");
                        break;
                    default:
                        System.Console.WriteLine("No es una opción del Sistema");
                        break;
                }
            } while (option != 4);
        }
    }
}
