using System;
using System.Collections;
using System.Collections.Generic;

namespace TP_Integrador
{
	/// <summary>
	/// Description of Compra.
	/// </summary>
	
	public class Compra
	{
		private ArrayList listaProductos = new ArrayList();
		private ArrayList cantidad = new ArrayList();
		private int gasto;
		
		public ArrayList ListaProductos
		{
			get { return listaProductos; }
			set { listaProductos = value; }
		}

		public ArrayList Cantidad 
		{
			get { return cantidad; }
			set { cantidad = value; }
		}

		public int Gasto 
		{
			get { return gasto; }
			set { gasto = value; }
		}	

	}
}

