using System;
using PROYECTP1W.Core.Entities;
using PROYECTP1W.Core.Services.Interfaces;

namespace PROYECTP1W.Core.Services
{
    public class SfService : ISfService
    {
        public Sf IncomeSf(Users users)
        {
            var sf = new Sf();
            decimal saldo = 0; 
            
            int opcion;
            do
            {
                Console.WriteLine("----- Registro de Transacciones -----");
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
                        Console.WriteLine("Saldo Actual: " + saldo );
                        Console.Write("Ingresa la categoría (alimentación, transporte, vivienda, entretenimiento): ");
                        String categoria = Console.ReadLine();
                        Console.Write("Coloca la cantidad a ingresar: ");
                        String dineroIngresadoString = Console.ReadLine();
                        decimal dineroIngresado;
                        if(string.IsNullOrEmpty(dineroIngresadoString)){
                            Console.WriteLine("No se ha ingreso ningún valor");
                            continue;
                        }
                        if(!decimal.TryParse(dineroIngresadoString, out dineroIngresado))
                        {
                            Console.WriteLine("Ingrese un número valido");
                            continue;
                        }
                        if(dineroIngresado < 0 ){
                            Console.WriteLine("La cantidad negativa no es valida");
                        }
                        else{
                            saldo += dineroIngresado;
                            Console.WriteLine("Ingreso exitoso de $"+dineroIngresado + " de la categoria "+ categoria);
                        }
                        break;
                    case 2:
                        Console.WriteLine("Saldo Actual: " + saldo );
                        Console.Write("Ingresa la categoría (alimentación, transporte, vivienda, entretenimiento): ");
                        String categoriaRetiro = Console.ReadLine();
                        Console.Write("Coloca la cantidad a retirar: ");
                        String dineroRetiradoString = Console.ReadLine();
                        decimal dineroRetirado;
                        if(string.IsNullOrEmpty(dineroRetiradoString)){
                            Console.WriteLine("No se ha ingreso ningún valor");
                            continue;
                        }
                        if(!decimal.TryParse(dineroRetiradoString, out dineroRetirado))
                        {
                            Console.WriteLine("Ingrese un número valido");
                            continue;
                        }
                        if(dineroRetirado < 0 ){
                            Console.WriteLine("La cantidad negativa no es valida");
                        }
                        else if(dineroRetirado > saldo){
                            Console.WriteLine("No se puede retirar mas dinero del que tienes en Saldo Actual");
                        }
                        else{
                            saldo -= dineroRetirado;
                            Console.WriteLine("Retiro exitoso de $"+ dineroRetirado + " en la categoria: " + categoriaRetiro);
                        }
                        break;
                    case 3:
                        Console.WriteLine("Volver al menú principal :)");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                        break;
                }
            } while (opcion != 3);

            return sf;
        }
    }
}
