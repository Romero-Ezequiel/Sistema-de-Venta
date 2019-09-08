using System;
using System.Collections;
using System.Collections.Generic;

namespace TP_Integrador
{
	/// <summary>
	/// Description of Producto.
	/// </summary>
	public class Producto
	{
		private string tipoProd;
		private string tipoProm;
		private string marcaProd;
		private double precioProd;
		private int descuento;
		private string talleProd;
		private double totalProducto;
		
		//BUSQUEDA SECUENCIAL
		private bool estadoProm;
		private bool estadoProducto;
		private int[] promo=new int[1];
		private int[] cantidad=new int[1];
		
		public string TipoProd
		{
			set{tipoProd = value;}
			get{return tipoProd;}
		}
		
		public string TipoProm
		{
			set{tipoProm = value;}
			get{return tipoProd;}
		}
		
		public string MarcaProd
		{
			set{marcaProd = value;}
			get{return marcaProd;}
		}
		
		public double PrecioProd
		{
			set{precioProd = value;}
			get{return precioProd;}
		}
		
		public int Descuento
		{
			set{descuento = value;}
			get{return descuento;}
		}
		
		public string TalleProd
		{
			set{talleProd = value;}
			get{return talleProd;}
		}
		
		public bool EstadoProm 
		{
			get { return estadoProm; }
			set { estadoProm = value; }
		}

		public int[] Promo 
		{
			get { return promo; }
			set { promo = value; }
		}
		
		public bool EstadoProducto
		{
			get { return estadoProducto; }
			set { estadoProducto = value; }
		}

		public int[] Cantidad
		{
			get { return cantidad; }
			set { cantidad = value; }
		}
		
		public double TotalProducto
		{
			get { return totalProducto; }
			set { totalProducto = value; }
		}
		
		public Producto(string tipo, string marca, string talle, double precio, int descuento)
		{
			this.tipoProd = tipo;
			this.marcaProd = marca;
			this.talleProd = talle;
			this.precioProd = precio;
			this.descuento = descuento;			
		}
	}
}