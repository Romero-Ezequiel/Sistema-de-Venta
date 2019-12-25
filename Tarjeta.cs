using System;
using System.Collections;
using System.Collections.Generic;

namespace TP_Integrador
{
	
	public class Tarjeta
	{
		private string nombre;
		private string banco;
		private int formaDePago;
		private int cuotas;
		private int interes;
		private double totalCompras;
		
		//BUSQUEDA SECUENCIAL
		private bool estadoTarj;
		private int[] vecCuotas = new int[4];
		private int[] vecInteres = new int[4];
	
		public string Nombre 
		{
			get { return nombre; }
			set { nombre = value; }
		}
		
		public string Banco 
		{
			get { return banco; }
			set { banco = value; }
		}

		public int FormaDePago 
		{
			get { return formaDePago; }
			set { formaDePago = value; }
		}

		public double TotalCompras 
		{
			get { return totalCompras; }
			set { totalCompras = value; }
		}

		public bool EstadoTarj 
		{
			get { return estadoTarj; }
			set { estadoTarj = value; }
		}
		
		public int Cuotas
		{
			get { return cuotas; }
			set { cuotas = value; }
		}

		public int Interes 
		{
			get { return interes; }
			set { interes = value; }
		}
		
		public int[] VecCuotas
		{
				get { return vecCuotas; }
				set { vecCuotas = value; }
		}

		public int[] VecInteres 
		{
				get { return vecInteres; }
				set { vecInteres = value; }
		}	

		public Tarjeta(string nombre, string banco, int formaDePago, int[] vecCuotas , int[] vecInteres, double totalCompras)
		{
			this.nombre = nombre;
			this.banco = banco;
			this.formaDePago = formaDePago;
			this.vecCuotas = vecCuotas;
			this.vecInteres = vecInteres;
			this.totalCompras = totalCompras;
		}
	}
}
