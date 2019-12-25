using System;
using System.Collections;
using System.Collections.Generic;

namespace TP_Integrador
{
	
	public class Cliente
	{
		private string nombre;
		private string apellido;
		private int dni;
		private string fechaNac;
		private double totalGastado;
		private double gasto;
		
		//BUSQUEDA SECUENCIAL
		private bool estadoCli;
		//private int[] clit=new int[1];
		
		public string Nombre
		{
			set{nombre = value;}
			get{return nombre;}
		}
		
		public string Apellido
		{
			set{apellido = value;}
			get{return apellido;}
		}
			
		public int Dni
		{
			set{dni = value;}
			get{return dni;}
		}
			
		public string FechaNac 
		{
			get { return fechaNac; }
			set { fechaNac = value; }
		}
		
		public double TotalGastado 
		{
			get { return totalGastado; }
			set { totalGastado = value; }
		}
		
		
		public bool EstadoCli
		{
			get { return estadoCli; }
			set { estadoCli = value; }
		}
				
		public double Gasto
		{
			get { return gasto; }
			set { gasto = value; }
		}
	
		public Cliente(string nombre, string apellido, int dni, string fechaNac, double TotalGastado)
		{
			this.nombre = nombre;
			this.apellido = apellido;
			this.dni = dni;
			this.fechaNac = fechaNac;
			this.totalGastado = TotalGastado;
		}
	}	
}