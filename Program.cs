using System;
using System.Collections;
using System.Collections.Generic;

namespace TP_Integrador
{
	class Program
	{
		public static void Main(string[] args)
		{
			//Aca instancio la clase sucursal para que funcione el programa
			Sucursaal s1 = new Sucursaal();
			s1.menuTM();
			Console.ReadKey(true);
		}
	}
}