using System;
using System.Collections;
using System.Collections.Generic;

namespace TP_Integrador
{
	/// <summary>
	/// Description of Sucursal.
	/// </summary>
	
	//Excepcion por Cadena Vacia
	class ExcepcionPorCadenaVacia:Exception{}
	
	//Excepcion por Datos Incorrectos
	class ExcepcionPorDatosIncorrectos:Exception{}

	//Excepcion por Numeros Invalidos 
	class ExcepcionNumInvalidos:Exception{}

	public class Sucursaal
	{
		private ArrayList listaCli = new ArrayList();
		private ArrayList listaComp = new ArrayList();
		private ArrayList listaTarje = new ArrayList();
		private ArrayList listaProd = new ArrayList();
		private ArrayList listaProm = new ArrayList();
		
		private double recaudacion;
		private double [] descuento;
		private double financiado;
		private double totalFinanciado;
		
		public ArrayList ListaCli
		{
			set{listaCli = value;}
			get{return listaCli;}
		}
		
		public ArrayList ListaComp
		{
			set{listaComp = value;}
			get{return listaComp;}
		}
		
		public ArrayList ListaTarje
		{
			set{listaTarje = value;}
			get{return listaTarje;}
		}
		
		public ArrayList ListaProd
		{
			set{listaProd = value;}
			get{return listaProd;}
		}
		
		public ArrayList ListaProm
		{
			set{listaProm = value;}
			get{return listaProm;}
		}
		
		public double Recaudacion
		{
			get { return recaudacion; }
			set { recaudacion = value; }
		}
		
		public double[] Descuento
		{
			get { return descuento; }
			set { descuento = value; }
		}
		
		public double Financiado
		{
			get { return financiado; }
			set { financiado = value; }
		}

		public double TotalFinanciado 
		{
			get { return totalFinanciado; }
			set { totalFinanciado = value; }
		}
		
		public Sucursaal()
		{
			Producto p1 = new Producto("Short", "Adidas", "L", 560.4, 0);
			ListaProd.Add(p1);
			
			Producto p2 = new Producto("Botin", "Adidas", "42", 3254.5, 0);
			ListaProd.Add(p2);
			
			Producto p3 = new Producto("Remera", "LeCoqSportif", "M", 347.3, 0);
			ListaProd.Add(p3);
			
			Producto p4 = new Producto("Buzo", "Nike", "XS", 847.4, 0);
			ListaProd.Add(p4);
			
			Producto p5 = new Producto("Botin", "Diporto", "38", 1564.24, 0);
			ListaProd.Add(p5);
			
			Producto p6 = new Producto("Remera", "Nike", "XL", 320, 0);
			ListaProd.Add(p6);
			
			Producto p7 = new Producto("Zapatillas", "Topper", "42", 1560, 0);
			ListaProd.Add(p7);
			
			Producto p8 = new Producto("Short", "Adidas", "36", 300, 0);
			ListaProd.Add(p8);
			
			Producto p9 = new Producto("yoguis", "Topper", "5", 560, 0);
			ListaProd.Add(p9);
			
			Producto p10 = new Producto("Short", "Adidas", "32", 660.24, 0);
			ListaProd.Add(p10);
			
			//Para tres cliente existente
			//[Cliente Nombre=Pepe, Apellido=Argento, Dni=25178415, Nacimiento=22/07/70, TtlGastado=,0]
			Cliente c1 = new Cliente("Pepe", "Argento",25178415,"22/07/70",0);
			ListaCli.Add(c1);
			
			//public Tarjeta(string nombre, string banco, int formaDePago, int cuotas, int interes, double totalCompras)
			//1) [Tarjeta Nombre=Visa, Banco=Ciudad, Cantidad_formas_pago=3, Total Compras=0]
						//3 cuotas con 10% de interes
						//6 cuotas con 20% de interes
						//9 cuotas con 30% de interes		
			Tarjeta t1 = new Tarjeta("Visa", "Ciudad",3, new int[]{3,6,9}, new int[]{10, 20, 30}, 0);
			ListaTarje.Add(t1);
			Tarjeta t2 = new Tarjeta("Nativa", "Nación",4, new int[]{3,6,9,12}, new int[]{10, 20, 30, 40}, 0);
			ListaTarje.Add(t2);
			Tarjeta t3 = new Tarjeta("Visa", "Ciudad",2, new int[]{3,6}, new int[]{10, 20}, 0);
			ListaTarje.Add(t3);
		}
		
		//1) MODULO PRODUCTOS Y PROMOCIONES		
		//1) Dar de alta Productos o Ingresar un nuevo producto al modulo productos
		//Sub-opción 1) Dar de alta productos
		//Para dar de alta un producto en el sistema, el usuario deberá completar los 
		//datos de interés del producto: tipo, marca, talle y precio.
		public void DarAltaProducto()
		{
			string tipo, marca, talle, precio;	
			double precio1;
			Console.Write("Ingrese tipo de producto: ");
			tipo = Console.ReadLine();
			try 
			{
				if (tipo == "")
				{
					throw new ExcepcionPorCadenaVacia();
				}
			} 		
			catch (ExcepcionPorCadenaVacia) 
			{
				Console.WriteLine("\nIngreso una cadena vacia, vuelva a intentar");
				Console.WriteLine("Presione una tecla para continuar.....");
				Console.ReadKey();
				Console.Clear();
				menuMP();
			}
			Console.Write("Ingrese la marca de producto: ");
			marca = Console.ReadLine();
			try 
			{
				if (marca == "")
				{
					throw new ExcepcionPorCadenaVacia();
				}
			} 
			catch (ExcepcionPorCadenaVacia) 
			{
				Console.WriteLine("\nIngreso una cadena vacia, vuelva a intentar");
				Console.WriteLine("Presione una tecla para continuar.....");
				Console.ReadKey();
				Console.Clear();
				menuMP();
			}
			Console.Write("Ingrese talle de producto: ");
			talle = Console.ReadLine();
			try 
			{
				if (talle == "") 
				{
					throw new ExcepcionPorCadenaVacia();
				}
			} 
			catch (ExcepcionPorCadenaVacia) 
			{
				Console.WriteLine("\nIngreso una cadena vacia, vuelva a intentar");
				Console.WriteLine("Presione una tecla para continuar.....");
				Console.ReadKey();
				Console.Clear();
				menuMP();
			}
			
			Console.Write("Ingrese precio del producto: ");
			precio = Console.ReadLine();
			
			try
			{
				if (precio == "") 
				{
					throw new ExcepcionPorCadenaVacia();
				}
				// Convertir una cadena en un número
				if (!(double.TryParse(precio, out precio1))) 
				{
					throw new ExcepcionPorDatosIncorrectos();	
				}
				precio1 = double.Parse(precio);
				if (precio1 <=0)
				{
					throw new ExcepcionNumInvalidos();
				}
			} 
			catch (ExcepcionPorCadenaVacia) 
			{
				Console.WriteLine("\nIngreso una cadena vacia, vuelva a intentar");
				Console.WriteLine("Presione una tecla para continuar.....");
				Console.ReadKey();
				Console.Clear();
				menuMP();
			}
			catch (ExcepcionPorDatosIncorrectos) 
			{
				Console.WriteLine("\nIngreso una cadena vacia, vuelva a intentar");
				Console.WriteLine("Presione una tecla para continuar.....");
				Console.ReadKey();
				Console.Clear();
				menuMP();
			}
			catch (ExcepcionNumInvalidos) 
			{
				Console.WriteLine("\nIngreso una cadena vacia, vuelva a intentar");
				Console.WriteLine("Presione una tecla para continuar.....");
				Console.ReadKey();
				Console.Clear();
				menuMP();
			}
			precio1 = double.Parse(precio);
			int descuento=0;
			Producto xp = new Producto(tipo, marca, talle, precio1, descuento);
			ListaProd.Add(xp);
		}
	
 
//		((Producto)ListaProd[num]).EstadoProm=true;
//		((Producto)ListaProd[num]).Promo[0]=num1;
		//2) Dar de alta Promociones o Ingresar una promoción nueva al Modulo Productos
		public void DarAltaPromociones()
		{
			int i=0;
			Console.WriteLine("Seleccione un producto para la promo: ");
			foreach (Producto p in ListaProd) 
			{
				if (p.EstadoProm==false) 
					Console.WriteLine(i+1 +")[Producto Tipo=" + p.TipoProd + ", "+
					              "Marca=" + p.MarcaProd + ", "+
				                  "Talle=" + p.TalleProd + ", "+
				                  "Precio=$" + p.PrecioProd + ", "+
				                  "Descuento=" + p.Descuento + "%]");
				else
					Console.WriteLine(i+1 +")[Producto Tipo=" + p.TipoProd + ", "+ 
					               "Marca=" + p.MarcaProd + ", "+
				                  "Talle=" + p.TalleProd + ", "+
				                  "Precio=$" + p.PrecioProd + ", "+
				                  "Descuento=" + p.Promo[0] + "%]" );	
				i++;
			}
		}					
		//3) Listar los Productos en el Modulo Productos
		public void ListarProductos()
		{
			int i=0;
			foreach (Producto p in ListaProd) 
			{
				if (p.EstadoProm==false) 
					Console.WriteLine(i+1 +")[Producto Tipo=" + p.TipoProd + ", "+
					              "Marca=" + p.MarcaProd + ", "+
				                  "Talle=" + p.TalleProd + ", "+
				                  "Precio=$" + p.PrecioProd + ", "+
				                  "Descuento=" + p.Descuento + "%]");
				else
						Console.WriteLine(i+1 +")[Producto Tipo=" + p.TipoProd + ", "+
					              "Marca=" + p.MarcaProd + ", "+
				                  "Talle=" + p.TalleProd + ", "+
				                  "Precio=$" + p.PrecioProd + ", "+
				                  "Descuento=" + p.Promo[0] +"%]");
				i++;
			}
			Console.ReadKey();
		}
		//4) LISTAR PROMOCIONES
		public void ListarPromociones()
		{
			int i=1;
			foreach (Producto p in ListaProd) 
			{
				if (p.EstadoProm==true) 
					Console.WriteLine(i +")[Producto Tipo=" + p.TipoProd + ", "+ 
					              "Marca=" + p.MarcaProd + ", "+
				                  "Talle=" + p.TalleProd + ", "+
				                  "Precio=$" + p.PrecioProd + ", "+
				                  "Descuento=" + p.Promo[0] + "%]");
			i++;
			}
			Console.ReadKey();
		}
		//MÓDULO 2: MÓDULO DE COMPRAS
		//1) Agregar productos al carro
		public void AgregarProducto()
		{
			int i=0;
			Console.WriteLine("Seleccione un producto para agregar al carro: ");
			foreach (Producto p in ListaProd) 
			{
				if (p.EstadoProducto==false) 
					Console.WriteLine(i+1 +")[Producto Tipo=" + p.TipoProd + ", "+
					              "Marca=" + p.MarcaProd + ", "+
				                  "Talle=" + p.TalleProd + ", "+
				                  "Precio=$" + p.PrecioProd + ", "+
				                  "Descuento=" + p.Descuento + "%]");
				else
					Console.WriteLine(i+1 +")[Producto Tipo=" + p.TipoProd + ", "+ 
					              "Marca=" + p.MarcaProd + ", "+
				                  "Talle=" + p.TalleProd + ", "+
				                  "Precio=$" + p.PrecioProd + ", "+
				                  "Descuento=" + p.Promo[0] + "%]" );
				i++;
			}
		}

		//((Producto)ListaProd[quitar2]).EstadoProducto = false;
		//2) Quitar producto del carro
		public void QuitarProducto()
		{
			Console.WriteLine("Seleccione un producto para quitar del carro: ");
			int i=0;
			foreach (Producto p in ListaProd) 
			{
				if (p.EstadoProducto==true)
					Console.WriteLine(i+1 +")[Producto Tipo=" + p.TipoProd + ", "+
					              "Marca=" + p.MarcaProd + ", "+
				                  "Talle=" + p.TalleProd + ", "+
				                  "Precio=$" + p.PrecioProd + ", "+
				                  "Descuento=" + p.Descuento + "%]");
				i++;
			}
			Console.ReadKey();
		}
		//3) Listar productos en el carro
		public void ListarProductoCarro() 
		{
			int i=0;
			double total=0;
			foreach (Producto p in ListaProd) 
			{
				
				if (p.EstadoProducto==true) 
				{
					Console.WriteLine(i+1 +")Cantidad:"+p.Cantidad[0]+
					              "[Producto Tipo=" + p.TipoProd + ", "+
					              "Marca=" + p.MarcaProd + ", "+
				                  "Talle=" + p.TalleProd + ", "+
				                  "Precio=$" + p.PrecioProd + ", "+
				                  "Descuento=" + p.Descuento + "%]");
				}
				
				i++;		
				total+= p.Cantidad[0] * p.PrecioProd;
				Recaudacion = total;
			}
			Console.WriteLine("El total es: "+ Recaudacion);
			Console.ReadKey();			
		}

		//MODULO 2- OPCIÓN 2 ME FALTA TERMINAR BIEN
		//Sub-Opción 2) Identifica cliente:
		//Para avanzar con la compra se deberá identificar el cliente por medio de su DNI. 
		//En primera instancia el sistema deberá detectar si se trata de un cliente existente
		//o un nuevo cliente, y luego darle la opción de seleccionar una tarjeta para el pago, 
		//la cantidad de cuotas y confirmar la compra. Luego de esta confirmación el carro quedará 
		//vacio y listo para una nueva operación de compra:
		public bool BusquedaDNI(int dni, ArrayList arreglo)
		{
			foreach (Cliente c in arreglo) 
			{
				if (c.Dni == dni) 
				{
					return true;
				}
			}
			return false;			
		}
		

		//Para cliente existentes 		
		public void IdentificarCliente()	
		{
	//		double total;
			string nom, ape, fechaNac, dni;
			int numDNI;
			Console.Write("Ingrese DNI: ");
			dni = Console.ReadLine();
			try
			{
				if (dni == "")
				{
					throw new ExcepcionPorCadenaVacia();
				}
				// Convertir una cadena en un número
				if (!(int.TryParse(dni, out numDNI)))
				{
					throw new ExcepcionPorDatosIncorrectos();
				}
				numDNI = int.Parse(dni);
				if (numDNI <= 0 )
				{
					throw new ExcepcionNumInvalidos();
				}
			} 
			catch (ExcepcionPorCadenaVacia)
			{
				Console.WriteLine("\nIngreso una cadena vacia, vuelva a intentar");
				Console.WriteLine("Presione una tecla para continuar.....");
				Console.ReadKey();
				Console.Clear();
				menuMC();
			}
			catch (ExcepcionPorDatosIncorrectos)
			{
				Console.WriteLine("\nIngreso una cadena vacia, vuelva a intentar");
				Console.WriteLine("Presione una tecla para continuar.....");
				Console.ReadKey();
				Console.Clear();
				menuMC();
			}
			catch (ExcepcionNumInvalidos)
			{
				Console.WriteLine("\nIngreso una cadena vacia, vuelva a intentar");
				Console.WriteLine("Presione una tecla para continuar.....");
				Console.ReadKey();
				Console.Clear();
				menuMC();
			}	
			numDNI = int.Parse(dni);
			bool idenficar = BusquedaDNI(numDNI, ListaCli);
	   		if (idenficar == true)
	   		{
				Console.WriteLine("Cliente Existente\n"+
				                  "[Cliente Nombre="+ ((Cliente)ListaCli[0]).Nombre +", " +
					               "Apellido=" +((Cliente)ListaCli[0]).Apellido + ", "+
					               "Dni="+ ((Cliente)ListaCli[0]).Dni +", "+ "Nacimiento="+ 
					               ((Cliente)ListaCli[0]).FechaNac+", "+"TtlGastado="
					               + ((Cliente)ListaCli[0]).TotalGastado + "]");
	   		}
			else
			{
				Console.WriteLine("Nuevo cliente, ingrese sus datos: ");
				Console.Write("Ingrese Nombre: ");
				nom = Console.ReadLine();
				try
				{
					if (nom == "")
					{
						throw new ExcepcionPorCadenaVacia();
					}
				} 
				catch (ExcepcionPorCadenaVacia)
				{
					Console.WriteLine("\nIngreso una cadena vacia, vuelva a intentar");
					Console.WriteLine("Presione una tecla para continuar.....");
					Console.ReadKey();
					Console.Clear();
					menuMC();
				}
				Console.Write("Ingrese Apellido: ");
				ape = Console.ReadLine();
				
				try
				{
					if (ape == "")
					{
						throw new ExcepcionPorCadenaVacia();
					}
				} 
				catch (ExcepcionPorCadenaVacia)
				{
					Console.WriteLine("\nIngreso una cadena vacia, vuelva a intentar");
					Console.WriteLine("Presione una tecla para continuar.....");
					Console.ReadKey();
					Console.Clear();
					menuMC();
				}
				Console.Write("Ingrese Fecha Nacimiento (DD/MM/AA): ");
				fechaNac = Console.ReadLine();
				
				try
				{
					if (fechaNac == "")
					{
						throw new ExcepcionPorCadenaVacia();
					}
				} 
				catch (ExcepcionPorCadenaVacia)
				{
					Console.WriteLine("\nIngreso una cadena vacia, vuelva a intentar");
					Console.WriteLine("Presione una tecla para continuar.....");
					Console.ReadKey();
					Console.Clear();
					menuMC();
				}
				double total=0.0;
				Cliente nuevo1 = new Cliente(nom, ape, numDNI, fechaNac, total);
				ListaCli.Add(nuevo1);
			}	
			Console.ReadKey();
	   	}

		//MODULO 2)-2
		public void SeleccioneTarjeta()
		{
			int i=0;
			Console.WriteLine("Seleccione una tarjeta para abonar: ");
			foreach (Tarjeta t in ListaTarje)
			{
				if (t.EstadoTarj == false)
				{
					Console.WriteLine(i+1 +") [Tarjeta Nombre="+t.Nombre + ", "+
						"Banco="+t.Banco + ", "+ "Cantidad_formas_pago=" +t.FormaDePago +", "+ 
						"Total compras="+t.TotalCompras+"]");
						for (int j = 0; j < t.FormaDePago; j++)
						{
							Console.WriteLine("\t "+t.VecCuotas[j]+ " cuotas con " + t.VecInteres[j] +"% de interes" );
						}
				}									
				i++;				        
			}
		} 

		//OPCION 2
		public void Mostar(int numCuota)
		{
			double totalFinanciado=0.0;
			string respuesta;
			int k=0;	
			foreach (Tarjeta t in ListaTarje)
			{
				if (t.EstadoTarj == false)
				{					
					for (int i = 0; i < t.FormaDePago; i++)
					{
						this.Financiado = (t.VecInteres[i] * this.Recaudacion/100.0) ;
						totalFinanciado = this.Recaudacion;
						Console.WriteLine(Recaudacion);
						Console.WriteLine(Financiado);
						
						Console.WriteLine(Recaudacion - Financiado);
						if(t.VecCuotas[i] == numCuota)
						{	
														
							Console.WriteLine("En "+ t.VecCuotas[i] +
							                " cuotas tiene un interes de "+ t.VecInteres[i]+"%\n"+
							                "En el carro hay un total de $"+ Recaudacion+ "\n"+
							                "Precio total financiado: $ " +totalFinanciado+
							                ", en "+ numCuota + " cuotas de "+Financiado);	
							

							Console.WriteLine("Confirma la compra? (SI/NO)");
							respuesta = Console.ReadLine();
							respuesta = respuesta.ToUpper();
							if (respuesta.Equals("SI"))
							{
								t.TotalCompras = TotalFinanciado;
								Console.WriteLine("Felicidades por su compra, carro vacio!");
							}
							else
							{
								Console.WriteLine("OK!");
							}
							break;
								
						}
							
					}
				}
				k++;				
			}
			Console.ReadKey();	
		}
			
		//Opción 3) Módulo de Tarjetas:
		//Sub-Opción 1) Agregar tarjeta:
		public void AgregarTarjeta()
		{
			
			string nombre;
			Console.Write("Ingrese Tarjeta: ");
			nombre = Console.ReadLine();
			try
			{
				if (nombre == "")
				{
					throw new ExcepcionPorCadenaVacia();
				}	
			} 
			catch (ExcepcionPorCadenaVacia)
			{
				Console.WriteLine("\nIngreso una cadena vacia, vuelva a intentar");
				Console.WriteLine("Presione una tecla para continuar.....");
				Console.ReadKey();
				Console.Clear();
				menuMT();
			}
			string banco;
			Console.Write("Ingrese Banco: ");
			banco = Console.ReadLine();
			try
			{
				if (banco == "")
				{
					throw new ExcepcionPorCadenaVacia();
				}
			} 
			catch (ExcepcionPorCadenaVacia)
			{
				Console.WriteLine("\nIngreso una cadena vacia, vuelva a intentar");
				Console.WriteLine("Presione una tecla para continuar.....");
				Console.ReadKey();
				Console.Clear();
				menuMT();
			}
			
			string cantidad;
			Console.Write("Ingrese cantidad de formas de pago: ");
			cantidad = Console.ReadLine();
			
			try
			{
				if (cantidad == "")
				{
					throw new ExcepcionPorCadenaVacia();
				}
			} 
			catch (ExcepcionPorCadenaVacia)
			{
				Console.WriteLine("\nIngreso una cadena vacia, vuelva a intentar");
				Console.WriteLine("Presione una tecla para continuar.....");
				Console.ReadKey();
				Console.Clear();
				menuMT();
			}
			string cuotas;
			Console.Write("Ingrese "+cantidad +" # de cuotas: ");
			cuotas = Console.ReadLine();
			try
			{
				if (cuotas == "") 
				{
					throw new ExcepcionPorCadenaVacia();
				}
			}
			catch (ExcepcionPorCadenaVacia)
			{
				Console.WriteLine("\nIngreso una cadena vacia, vuelva a intentar");
				Console.WriteLine("Presione una tecla para continuar.....");
				Console.ReadKey();
				Console.Clear();
				menuMT();	
			}	
			string interes;
			Console.Write("Ingrese interés por cuota: ");
			interes = Console.ReadLine();
			try 
			{
				if (interes == "") 
				{
					throw new ExcepcionPorCadenaVacia();
				}
			} 
			catch (ExcepcionPorCadenaVacia) 
			{
				Console.WriteLine("\nIngreso una cadena vacia, vuelva a intentar");
				Console.WriteLine("Presione una tecla para continuar.....");
				Console.ReadKey();
				Console.Clear();
				menuMT();
			}
			double total=0;
			int formadePago, cuotas1, interes1;
			formadePago = int.Parse(cantidad);
			cuotas1 = int.Parse(cuotas);
			interes1 = int.Parse(interes);
			
			int[] vecCuotas = new int[formadePago];
			int[] vecInteres = new int[formadePago];
			
			vecCuotas[0]=cuotas1;
			vecInteres[0]=interes1;
			Tarjeta xt2 = new Tarjeta(nombre, banco, formadePago, vecCuotas, vecInteres, total);
			ListaTarje.Add(xt2);
			Console.ReadKey();
		}
		//Sub-Opción 2) Agregar beneficio:
		public void AgregarBeneficio()
		{
			int i=0;
			Console.WriteLine("Selecione una tarjeta para el beneficio: ");
			foreach (Tarjeta t in ListaTarje) 
			{
				if (t.EstadoTarj==false) 
				{
						Console.WriteLine(i+1 +") [Tarjeta Nombre="+t.Nombre + ", "+
							"Banco="+t.Banco + ", "+ "Cantidad_formas_pago=" +t.FormaDePago +", "+ 
							"Total compras="+t.TotalCompras+"]");
							
					//Console.WriteLine("\t "+ t.VecCuotas+ " cuotas con " + t.VecInteres+"% de interes" );
							for (int k = 0; k < t.FormaDePago; k++) 
							{
								Console.WriteLine("\t "+ t.VecCuotas[k]+ " cuotas con " + t.VecInteres[k]+"% de interes" );
							}
				}
				else
				{
						Console.WriteLine(i+1 +") [Tarjeta Nombre="+t.Nombre + ", "+
							"Banco="+t.Banco + ", "+ "Cantidad_formas_pago=" +t.FormaDePago +", "+ 
							"Total compras="+t.TotalCompras+"]");
					//Console.WriteLine("\t "+t.VecCuotas[0]+ " cuotas con " + t.VecInteres[0] +"% de interes" );
								
							for (int x = 0; x < t.FormaDePago; x++) 
							{
								if (t.VecCuotas[x]==t.VecCuotas[0])
								{
									Console.WriteLine("\t "+t.VecCuotas[0]+ " cuotas con " + t.VecInteres[0] +"% de interes" );
								}
								else
								{
									Console.WriteLine("\t "+ t.VecCuotas[x]+ " cuotas con " + t.VecInteres[x]+"% de interes" );
								}					
							}
				}
				i++;								
			}		
		}
		//Sub-Opción 3) Listar Tarjetas:
		public void ListarTarjetas()
		{
			int i=1;
			foreach (Tarjeta t in ListaTarje) 
			{
				if (t.EstadoTarj==false) 
				{
					Console.WriteLine(i +") [Tarjeta Nombre="+t.Nombre + ", "+
							"Banco="+t.Banco + ", "+ "Cantidad_formas_pago=" +t.FormaDePago +", "+ 
							"Total compras="+t.TotalCompras+"]");
							
							for (int k = 0; k < t.FormaDePago; k++) 
							{
								Console.WriteLine("\t "+ t.VecCuotas[k]+ " cuotas con " + t.VecInteres[k]+"% de interes" );
							}
				}
				else
				{
						Console.WriteLine(i +") [Tarjeta Nombre="+t.Nombre + ", "+
							"Banco="+t.Banco + ", "+ "Cantidad_formas_pago=" +t.FormaDePago +", "+ 
							"Total compras="+t.TotalCompras+"]");
								
							for (int x = 0; x < t.FormaDePago; x++) 
							{
								if (t.VecCuotas[x]==t.VecCuotas[0])
								{
									Console.WriteLine("\t "+t.VecCuotas[0]+ " cuotas con " + t.VecInteres[0] +"% de interes" );
								}
								else
								{
									Console.WriteLine("\t "+ t.VecCuotas[x]+ " cuotas con " + t.VecInteres[x]+"% de interes" );
								}
							}
				}
				i++;
			}
			Console.ReadKey();
		}
		//Sub-Opción 4) Listar Tarjetas con beneficios:
		//de manera similar a la opción previa se deberán 
		//listar solo las tarjetas con beneficios.
		public void ListarTarjetaConBeneficios()
		{
			int i=1;
			foreach (Tarjeta  t in ListaTarje) 
			{
				if (t.EstadoTarj == true) 
				{
						Console.WriteLine(i +") [Tarjeta Nombre="+t.Nombre + ", "+
							"Banco="+t.Banco + ", "+ "Cantidad_formas_pago=" +t.FormaDePago +", "+ 
							"Total compras="+t.TotalCompras+"]");
								
							for (int x = 0; x < t.FormaDePago; x++) 
							{
								if (t.VecCuotas[x]==t.VecCuotas[0])
								{
									Console.WriteLine("\t "+t.VecCuotas[0]+ " cuotas con " + t.VecInteres[0] +"% de interes" );
								}
								else
								{
									Console.WriteLine("\t "+ t.VecCuotas[x]+ " cuotas con " + t.VecInteres[x]+"% de interes" );
								}
							}
				}
			i++;	
			}
			Console.ReadKey();
		}
	
		//MENU TIENDA LA MUNDIAL ON-LINE
		public void menuTM()
		{
			Console.WriteLine("*******************************************************************************\n");
			Console.WriteLine("*****                      TIENDA ON-Line		                   *****");
			Console.WriteLine("*******************************************************************************\n");
			
			Console.WriteLine("¿A qué módulo desea ingresar?\n" +
			                  "\n"+
			                  "1) Productos y Promociones\n"+
			                  "2) Compras\n"+
			                  "3) Tarjetas de Crédito\n"+
			                  "4) Administración\n"+
			                  "5) Salir del sistema\n");
	
			string opcion;
			opcion = Console.ReadLine();
			int opcion1;
			try 
			{
				if (opcion == "") 
				{
					throw new ExcepcionPorCadenaVacia();
				}
				// Convertir una cadena en un número
				if (!(int.TryParse(opcion, out opcion1)))
				{
					throw new ExcepcionPorDatosIncorrectos();
				}
			} 
			catch (ExcepcionPorCadenaVacia) 
			{
				Console.WriteLine("\nError!! Ingrese solo las opciones indicadas en el menu");
				Console.WriteLine("Presione cualquier tecla para continuar.....");
				Console.ReadKey();
				Console.Clear();
				menuTM();
			} 
			catch (ExcepcionPorDatosIncorrectos) 
			{
				Console.WriteLine("\nError!! Ingrese solo las opciones indicadas en el menu");
				Console.WriteLine("Presione cualquier tecla para continuar.....");
				Console.ReadKey();
				Console.Clear();
				menuTM();
			}
			opcion1 = int.Parse(opcion);
			switch (opcion1) 
			{
					case 1:
					Console.Clear();
					menuMP();
					break;
					
					case 2:
					Console.Clear();
					menuMC();
					break;
					
					case 3:
					Console.Clear();
					menuMT();
					break;
					
					case 4:
					Console.Clear();
					menuMA();
					break;
					
					case 5:
					Console.WriteLine("Presione ENTER para salir....\n" +
					                          "Realizado por alumno: Romero Ezequiel");break;
					default:
					
					try 
					{
						if (opcion1 <=0 || opcion1 > 5) 
						{
							throw new ExcepcionNumInvalidos();
						}
					} 
					catch (ExcepcionNumInvalidos) 
					{
						Console.WriteLine("\nError!! Ingrese solo las opciones indicadas en el menu");
						Console.WriteLine("Presione cualquier tecla para continuar.....");
						Console.ReadKey();
						Console.Clear();
						menuTM();
					}
					break;
			}
		}
		//MENU MODULO PRODUCTOS
		public void menuMP()
		{	
			Console.WriteLine("*******************************************************************************");
			Console.WriteLine("*****                       MODULO PRODUCTOS                             *****");
			Console.WriteLine("*******************************************************************************\n");
			
			Console.WriteLine("¿Qué desea hacer?\n"+
			                 "\n"+
			                 "1) Dar de alta Productos\n"+
			                 "2) Dar de alta Promociones\n"+
			                 "3) Listar Productos\n"+
			                 "4) Listar Promociones\n"+
			                 "5) Volver\n");
		
			string opcion;
			opcion = Console.ReadLine();
			switch (opcion) 
			{
					//OPCION 1 DAR DE ALTA PRODUCTOS
					case "1":
					DarAltaProducto();		
					Console.Clear();
					menuMP();
					break;
				
					//OPCION 2 DAR DE ALTA PROMOCIONES
					case "2":
					DarAltaPromociones();
					string promo;
					promo = Console.ReadLine();
					int num;
					
					try 
					{
						if (promo == "")
						{
							throw new ExcepcionPorCadenaVacia();
						}
						
						if (!(int.TryParse(promo, out num)))
						{
							throw new ExcepcionPorDatosIncorrectos();
						}
						num = int.Parse(promo);
						if (num <= 0 || num > ListaProd.Count)				
						{
							throw new ExcepcionNumInvalidos();
						}
					} 
					catch (ExcepcionPorCadenaVacia) 
					{
						Console.WriteLine("\nError!! Ingrese solo las opciones indicadas en el menu");
						Console.WriteLine("Presione cualquier tecla para continuar.....");
						Console.ReadKey();
						Console.Clear();
						menuMP();
					}
					catch (ExcepcionPorDatosIncorrectos) 
					{
						Console.WriteLine("\nError!! Ingrese solo las opciones indicadas en el menu");
						Console.WriteLine("Presione cualquier tecla para continuar.....");
						Console.ReadKey();
						Console.Clear();
						menuMP();
					}
					catch (ExcepcionNumInvalidos) 
					{
						Console.WriteLine("\nError!! Ingrese solo las opciones indicadas en el menu");
						Console.WriteLine("Presione cualquier tecla para continuar.....");
						Console.ReadKey();
						Console.Clear();
						menuMP();
					}
					
					Console.Write("Indique porcentaje de descuento: ");
					string porcentaje;
					porcentaje = Console.ReadLine();
					int num1;
					
					try
					{
						if (porcentaje == "") 
						{
							throw new ExcepcionPorCadenaVacia();
						}
						
						if (!(int.TryParse(porcentaje, out num1)))
						{
							throw new ExcepcionPorDatosIncorrectos();
						}
						num1 = int.Parse(porcentaje);
						if (num1 < 0)				
						{
							throw new ExcepcionNumInvalidos();
						}						
					} 
					catch (ExcepcionPorCadenaVacia) 
					{
						Console.WriteLine("\nError!! Ingrese solo las opciones indicadas en el menu");
						Console.WriteLine("Presione cualquier tecla para continuar.....");
						Console.ReadKey();
						Console.Clear();
						menuMP();
					}
					catch (ExcepcionPorDatosIncorrectos) 
					{
						Console.WriteLine("\nError!! Ingrese solo las opciones indicadas en el menu");
						Console.WriteLine("Presione cualquier tecla para continuar.....");
						Console.ReadKey();
						Console.Clear();
						menuMP();
					}
					catch (ExcepcionNumInvalidos) 
					{
						Console.WriteLine("\nError!! Ingrese solo las opciones indicadas en el menu");
						Console.WriteLine("Presione cualquier tecla para continuar.....");
						Console.ReadKey();
						Console.Clear();
						menuMP();
					}
					
					num1 = int.Parse(porcentaje);
					num = int.Parse(promo)-1;
					
					
					((Producto)ListaProd[num]).EstadoProm=true;
					((Producto)ListaProd[num]).Promo[0]=num1;
					
					Console.Clear();
					menuMP();
					break;
					
					//OPCION 3 LISTAR PRODUCTOS
					case "3":
					ListarProductos();
					Console.Clear();
					menuMP();
					break;
					
					//OPCION 4 LISTAR PROMOCIONES
					case "4":
					ListarPromociones();
					Console.Clear();
					menuMP();
					break;
				
					//OPCION 5 VOLVER AL MENU PRINCIPAL TIENDA MUNDIAL ON-LINE
					case "5":
					Console.Clear();
					menuTM();
					break;
				
					//OPCION INCORRECTA 
					default:
				//	int num;
					try 
					{
						if (!(int.TryParse(opcion, out num)))
						{
							throw new ExcepcionPorDatosIncorrectos();
						}
						
						if (opcion == "")
						{
							throw new ExcepcionPorCadenaVacia();
						}
						int opcion1;
						opcion1 = int.Parse(opcion);
						if (opcion1 <=0 || opcion1 > 5) 
						{
							throw new ExcepcionNumInvalidos();
						}
					} 
					catch (ExcepcionPorDatosIncorrectos)
					{
						Console.WriteLine("Error!! Ingrese solo las opciones indicadas en el menu\n");
						Console.WriteLine("Presione cualquier tecla para continuar.....");
						Console.ReadKey();
						Console.Clear();
						menuMP();
					}
					catch (ExcepcionNumInvalidos) 
					{
						Console.WriteLine("Error!! Ingrese solo las opciones indicadas en el menu\n");
						Console.WriteLine("Presione cualquier tecla para continuar.....");
						Console.ReadKey();
						Console.Clear();
						menuMP();
					}
					catch (ExcepcionPorCadenaVacia)
					{
						Console.WriteLine("Error!! Ingrese solo las opciones indicadas en el menu\n");
						Console.WriteLine("Presione cualquier tecla para continuar.....");
						Console.ReadKey();
						Console.Clear();
						menuMP();
					}					
					break;
			}
		}
		//MENU MODULO COMPRAS
		public void menuMC()
		{
			
			Console.WriteLine("*******************************************************************************");
			Console.WriteLine("*****                       MODULO COMPRAS                                *****");
			Console.WriteLine("*******************************************************************************\n");
			
			Console.WriteLine("¿Qué desea hacer?\n"+
			                 "\n"+
			                 "1) Agregar productos al carro\n"+
			                 "2) Identificar Cliente\n"+
			                 "3) Volver\n");
			string opcion;
			opcion = Console.ReadLine();
			switch (opcion) 
			{
				case "1":
				Console.Clear();
				menuSC();
				break;
	
				case "2":
				Console.Clear();
				IdentificarCliente();
				SeleccioneTarjeta();
				string OpcionSelec;
				OpcionSelec = Console.ReadLine();
				int num10;
				int nCuota;
				
				try 
				{
					if (OpcionSelec == "") 
					{
						throw new ExcepcionPorCadenaVacia();
					}
					if (!(int.TryParse(OpcionSelec, out num10)))
					{
						throw new ExcepcionPorDatosIncorrectos();
					}
					num10 = int.Parse(OpcionSelec);
					if (num10 <= 0 || num10 > ListaTarje.Count)				
					{
						throw new ExcepcionNumInvalidos();
					}
				}
				catch (ExcepcionPorCadenaVacia) 
				{
					Console.WriteLine("Error!! Ingrese solo las opciones indicadas en el menu\n");
					Console.WriteLine("Presione cualquier tecla para continuar.....");
					Console.ReadKey();
					Console.Clear();
					menuMC();
				}
				catch (ExcepcionPorDatosIncorrectos) 
				{
					Console.WriteLine("Error!! Ingrese solo las opciones indicadas en el menu\n");
					Console.WriteLine("Presione cualquier tecla para continuar.....");
					Console.ReadKey();
					Console.Clear();
					menuMC();
				}
				catch (ExcepcionNumInvalidos) 
				{
					Console.WriteLine("Error!! Ingrese solo las opciones indicadas en el menu\n");
					Console.WriteLine("Presione cualquier tecla para continuar.....");
					Console.ReadKey();
					Console.Clear();
					menuMC();
				}
				
				Console.Write("Indique cantidad de cuotas: ");
				nCuota = Convert.ToInt32(Console.ReadLine());
				Mostar(nCuota);
				Console.ReadKey();
				Console.Clear();
				menuMC();
				break;
				
				//Volver al menu anterior
				case "3":
				Console.Clear();
				menuTM();
				break;
				
				default:
				int num;
				try 
				{
					if (!(int.TryParse(opcion, out num)))
					{
						throw new ExcepcionPorDatosIncorrectos();
					}
						
					if (opcion == "")
					{
						throw new ExcepcionPorCadenaVacia();
					}
					int opcion1;
					opcion1 = int.Parse(opcion);
					if (opcion1 <=0 || opcion1 > 5) 
					{
						throw new ExcepcionNumInvalidos();
					}
				} 
				catch (ExcepcionPorDatosIncorrectos)
				{
					Console.WriteLine("Error!! Ingrese solo las opciones indicadas en el menu\n");
					Console.WriteLine("Presione cualquier tecla para continuar.....");
					Console.ReadKey();
					Console.Clear();
					menuMC();
				}
				catch (ExcepcionNumInvalidos) 
				{
					Console.WriteLine("Error!! Ingrese solo las opciones indicadas en el menu\n");
					Console.WriteLine("Presione cualquier tecla para continuar.....");
					Console.ReadKey();
					Console.Clear();
					menuMC();
				}
				catch (ExcepcionPorCadenaVacia)
				{
					Console.WriteLine("Error!! Ingrese solo las opciones indicadas en el menu\n");
					Console.WriteLine("Presione cualquier tecla para continuar.....");
					Console.ReadKey();
					Console.Clear();
					menuMC();
				}					
				break;
			}
		}
		
		//MENU SUBMODULO CARRO
		public  void menuSC()
		{
			
			Console.WriteLine("*******************************************************************************");
			Console.WriteLine("*****                       SUBMODULO CARRO                              *****");
			Console.WriteLine("*******************************************************************************\n");
			
			Console.WriteLine("¿Qué desea hacer?\n"+
			                 "\n"+
			                 "1) Agregar producto al carro\n"+
			                 "2) Quitar producto del carro\n"+
			                 "3) Listar productos en carro\n"+
			                 "4) Volver\n");
			
			string opcion;
			opcion = Console.ReadLine();
			switch (opcion) 
			{
				//1) Agregar producto al carro
				case "1":
				AgregarProducto();
				string opcion1, cantidad;
				opcion1 = Console.ReadLine();
				int opcion2;
				try 
				{
					if (opcion1 == "") 
					{
						throw new ExcepcionPorCadenaVacia();
					}	
					if (!(int.TryParse(opcion1, out opcion2)))
					{
						throw new ExcepcionPorDatosIncorrectos();
					}
					opcion2 = int.Parse(opcion1);
					if (opcion2 <=0 || opcion2 >ListaProd.Count) 
					{
						throw new ExcepcionNumInvalidos();
					}
				}
				catch (ExcepcionPorCadenaVacia) 
				{
					Console.WriteLine("Error!! Ingrese solo las opciones indicadas en el menu\n");
					Console.WriteLine("Presione cualquier tecla para continuar.....");
					Console.ReadKey();
					Console.Clear();
					menuSC();
				}
				catch (ExcepcionPorDatosIncorrectos) 
				{
					Console.WriteLine("Error!! Ingrese solo las opciones indicadas en el menu\n");
					Console.WriteLine("Presione cualquier tecla para continuar.....");
					Console.ReadKey();
					Console.Clear();
					menuSC();
				}
				catch (ExcepcionNumInvalidos) 
				{
					Console.WriteLine("Error!! Ingrese solo las opciones indicadas en el menu\n");
					Console.WriteLine("Presione cualquier tecla para continuar.....");
					Console.ReadKey();
					Console.Clear();
					menuSC();
				}
				opcion2 = int.Parse(opcion1)-1;
				Console.Write("Indique cantidad a comprar: ");
				cantidad = Console.ReadLine();
				int cant2;
				try 
				{
					if (cantidad == "")
					{
						throw new ExcepcionPorCadenaVacia();
					}
					if (!(int.TryParse(cantidad, out cant2)))
					{	
						throw new ExcepcionPorDatosIncorrectos();
					}
					cant2 = int.Parse(cantidad);
					if (cant2 <= 0) 
					{	
						throw new ExcepcionNumInvalidos();
					}	
				} 
				catch (ExcepcionPorCadenaVacia) 
				{
					Console.WriteLine("Error!! Ingrese solo las opciones indicadas en el menu\n");
					Console.WriteLine("Presione cualquier tecla para continuar.....");
					Console.ReadKey();
					Console.Clear();
					menuSC();
				}
				catch (ExcepcionPorDatosIncorrectos) 
				{
					Console.WriteLine("Error!! Ingrese solo las opciones indicadas en el menu\n");
					Console.WriteLine("Presione cualquier tecla para continuar.....");
					Console.ReadKey();
					Console.Clear();
					menuSC();
				}
				catch (ExcepcionNumInvalidos) 
				{
					Console.WriteLine("Error!! Ingrese solo las opciones indicadas en el menu\n");
					Console.WriteLine("Presione cualquier tecla para continuar.....");
					Console.ReadKey();
					Console.Clear();
					menuSC();
				}
				
				cant2 = int.Parse(cantidad);
				((Producto)ListaProd[opcion2]).EstadoProducto=true;
				((Producto)ListaProd[opcion2]).Cantidad[0] = cant2;
				Console.Clear();
				menuSC();
				break;
				
				//2) Quitar producto del carro
				case "2":
				QuitarProducto();
				string quitar;
				int quitar2;
				Console.Write("Indique producto a quitar: ");
				quitar = Console.ReadLine();
				Console.ReadKey();
				try 
				{
					if (quitar == "") 
					{
						throw new ExcepcionPorCadenaVacia();
					}
					if (!(int.TryParse(quitar, out quitar2)))
					{
						throw new ExcepcionPorDatosIncorrectos();
					}
					
					quitar2 = int.Parse(quitar);
					if (quitar2 <=0 || quitar2 > ListaProd.Count) 
					{
						throw new ExcepcionNumInvalidos();
					}
				} 
				catch (ExcepcionPorCadenaVacia) 
				{
					Console.WriteLine("Error!! Ingrese solo las opciones indicadas en el menu\n");
					Console.WriteLine("Presione cualquier tecla para continuar.....");
					Console.ReadKey();
					Console.Clear();
					menuSC();
				}
				catch (ExcepcionPorDatosIncorrectos) 
				{
					Console.WriteLine("Error!! Ingrese solo las opciones indicadas en el menu\n");
					Console.WriteLine("Presione cualquier tecla para continuar.....");
					Console.ReadKey();
					Console.Clear();
					menuSC();
				}
				catch (ExcepcionNumInvalidos) 
				{
					Console.WriteLine("Error!! Ingrese solo las opciones indicadas en el menu\n");
					Console.WriteLine("Presione cualquier tecla para continuar.....");
					Console.ReadKey();
					Console.Clear();
					menuSC();
				}
				
				quitar2 = int.Parse(quitar)-1;
				((Producto)ListaProd[quitar2]).EstadoProducto = false;
				Console.ReadKey();
				Console.Clear();
				menuSC();
				break;
				
				//3) Listar productos en el carro
				case "3":
				ListarProductoCarro();
				Console.Clear();
				menuSC();
				break;

				//VOLVER al Modulo Compras
				case "4":
				Console.Clear();
				menuMC();
				break;
				
				default:
				int num;
				int opcion6;
				try 
				{
					if (!(int.TryParse(opcion, out num)))
					{
						throw new ExcepcionPorDatosIncorrectos();
					}
						
					if (opcion == "")
					{
						throw new ExcepcionPorCadenaVacia();
					}
				
					opcion6 = int.Parse(opcion);
					if (opcion6 <=0 || opcion6 > 5) 
					{
						throw new ExcepcionNumInvalidos();
					}
				} 
				catch (ExcepcionPorDatosIncorrectos)
				{
					Console.WriteLine("Error!! Ingrese solo las opciones indicadas en el menu\n");
					Console.WriteLine("Presione cualquier tecla para continuar.....");
					Console.ReadKey();
					Console.Clear();
					menuSC();
				}
				catch (ExcepcionNumInvalidos) 
				{
					Console.WriteLine("Error!! Ingrese solo las opciones indicadas en el menu\n");
					Console.WriteLine("Presione cualquier tecla para continuar.....");
					Console.ReadKey();
					Console.Clear();
					menuSC();
				}
				catch (ExcepcionPorCadenaVacia)
				{
					Console.WriteLine("Error!! Ingrese solo las opciones indicadas en el menu\n");
					Console.WriteLine("Presione cualquier tecla para continuar.....");
					Console.ReadKey();
					Console.Clear();
					menuSC();
				}					
				break;
			}
		}
		
		//MENU MODULO TARJETAS
		public  void menuMT()
		{
			
			Console.WriteLine("*******************************************************************************");
			Console.WriteLine("*****                       MODULO TARJETAS                              *****");
			Console.WriteLine("*******************************************************************************\n");
			
			Console.WriteLine("¿Qué desea hacer?\n"+
			                 "\n"+
			                 "1) Agregar Tarjeta\n"+
			                 "2) Agregar Beneficio\n"+
			                 "3) Listar Tarjetas\n"+
			                 "4) Listar Tarjetas con Beneficio\n"+
			                 "5) Volver\n");
			
			string opcion;
			opcion = Console.ReadLine();
			switch (opcion) 
			{
				//Agregar Tarjeta 	(menuMT = menu tarjetas)	
				case "1":
				AgregarTarjeta();
				Console.Clear();
				menuMT();
				break;
				
				//Agregar Beneficio  (menuMT = menu tarjetas)
				case "2":
				AgregarBeneficio();
				string opcionTarj;
				opcionTarj = Console.ReadLine();
				int num4, num5, num6;
				
				try
				{
					if (opcionTarj == "") 
					{
						throw new ExcepcionPorCadenaVacia();
					}
					if (!(int.TryParse(opcionTarj, out num4)))
					{
						throw new ExcepcionPorDatosIncorrectos();
					}
					num4 = int.Parse(opcionTarj);
					if (num4 <= 0 || num4 > ListaTarje.Count)				
					{
						throw new ExcepcionNumInvalidos();
					}
				}
				catch (ExcepcionPorCadenaVacia) 
				{
					Console.WriteLine("Error!! Ingrese solo las opciones indicadas en el menu\n");
					Console.WriteLine("Presione cualquier tecla para continuar.....");
					Console.ReadKey();
					Console.Clear();
					menuMT();
				}
				catch (ExcepcionPorDatosIncorrectos) 
				{
					Console.WriteLine("Error!! Ingrese solo las opciones indicadas en el menu\n");
					Console.WriteLine("Presione cualquier tecla para continuar.....");
					Console.ReadKey();
					Console.Clear();
					menuMT();
				}
				catch (ExcepcionNumInvalidos) 
				{
					Console.WriteLine("Error!! Ingrese solo las opciones indicadas en el menu\n");
					Console.WriteLine("Presione cualquier tecla para continuar.....");
					Console.ReadKey();
					Console.Clear();
					menuMT();
				}
				
				string cuota, interes;
				Console.Write("Indique cantidad de cuotas: ");
				cuota = Console.ReadLine();

				try 
				{
					if (cuota == "") 
					{
						throw new ExcepcionPorCadenaVacia();
					}
					
					if (!(int.TryParse(cuota, out num5)))
					{
						throw new ExcepcionPorDatosIncorrectos();
					}
					
					num5 = int.Parse(cuota);
					if (num5 < 0)				
					{
						throw new ExcepcionNumInvalidos();
					}
				} 
				catch (ExcepcionPorCadenaVacia) 
				{
					Console.WriteLine("Error!! Ingrese solo las opciones indicadas en el menu\n");
					Console.WriteLine("Presione cualquier tecla para continuar.....");
					Console.ReadKey();
					Console.Clear();
					menuMT();
				}	
				catch (ExcepcionPorDatosIncorrectos) 
				{
					Console.WriteLine("Error!! Ingrese solo las opciones indicadas en el menu\n");
					Console.WriteLine("Presione cualquier tecla para continuar.....");
					Console.ReadKey();
					Console.Clear();
					menuMT();
				}	
				catch (ExcepcionNumInvalidos) 
				{
					Console.WriteLine("Error!! Ingrese solo las opciones indicadas en el menu\n");
					Console.WriteLine("Presione cualquier tecla para continuar.....");
					Console.ReadKey();
					Console.Clear();
					menuMT();
				}					
				Console.Write("Indique interés por cuota: ");
				interes = Console.ReadLine();
				try 
				{
					if (interes == "") 
					{
						throw new ExcepcionPorCadenaVacia();
					}
					
					if (!(int.TryParse(interes, out num6)))
					{
						throw new ExcepcionPorDatosIncorrectos();
					}
					
					num6 = int.Parse(interes);
					if (num6 < 0)				
					{
						throw new ExcepcionNumInvalidos();
					}
				} 
				catch (ExcepcionPorCadenaVacia) 
				{
					Console.WriteLine("Error!! Ingrese solo las opciones indicadas en el menu\n");
					Console.WriteLine("Presione cualquier tecla para continuar.....");
					Console.ReadKey();
					Console.Clear();
					menuMT();
				}	
				catch (ExcepcionPorDatosIncorrectos) 
				{
					Console.WriteLine("Error!! Ingrese solo las opciones indicadas en el menu\n");
					Console.WriteLine("Presione cualquier tecla para continuar.....");
					Console.ReadKey();
					Console.Clear();
					menuMC();
				}	
				catch (ExcepcionNumInvalidos) 
				{
					Console.WriteLine("Error!! Ingrese solo las opciones indicadas en el menu\n");
					Console.WriteLine("Presione cualquier tecla para continuar.....");
					Console.ReadKey();
					Console.Clear();
					menuMT();
				}
				
				num4 = int.Parse(opcionTarj)-1;
				num5 = int.Parse(cuota);
				num6 = int.Parse(interes);
				
				((Tarjeta)ListaTarje[num4]).EstadoTarj = true;
				((Tarjeta)ListaTarje[num4]).VecCuotas[0] = num5;
				((Tarjeta)ListaTarje[num4]).VecInteres[0] = num6;
				Console.ReadKey();	
				Console.Clear();
				menuMT();
				break;
			
				//Listar Tarjetas  (menuMT = menu tarjetas)
				case "3":
				ListarTarjetas();
				Console.Clear();
				menuMT();
				break;
				
				////Listar Tarjetas con Beneficios  (menuMT = menu tarjetas)
				case "4":				
				ListarTarjetaConBeneficios();
				Console.Clear();
				menuMT();
				break;
				
				//VOLVER
				case "5":
				Console.Clear();
				menuTM();
				break;
				
				default:
				int num;
				
				try
				{
					if (!(int.TryParse(opcion, out num)))
					{
						throw new ExcepcionPorDatosIncorrectos();
					}
						
					if (opcion == "")
					{
						throw new ExcepcionPorCadenaVacia();
					}
					int opcion1;
					opcion1 = int.Parse(opcion);
					if (opcion1 <=0 || opcion1 > 5) 
					{
						throw new ExcepcionNumInvalidos();
					}
				} 
				catch (ExcepcionPorDatosIncorrectos)
				{
					Console.WriteLine("Error!! Ingrese solo las opciones indicadas en el menu\n");
					Console.WriteLine("Presione cualquier tecla para continuar.....");
					Console.ReadKey();
					Console.Clear();
					menuMT();
				}
				catch (ExcepcionNumInvalidos) 
				{
					Console.WriteLine("Error!! Ingrese solo las opciones indicadas en el menu\n");
					Console.WriteLine("Presione cualquier tecla para continuar.....");
					Console.ReadKey();
					Console.Clear();
					menuMT();
				}
				catch (ExcepcionPorCadenaVacia)
				{
					Console.WriteLine("Error!! Ingrese solo las opciones indicadas en el menu\n");
					Console.WriteLine("Presione cualquier tecla para continuar.....");
					Console.ReadKey();
					Console.Clear();
					menuMT();
				}					
				break;
			}
		}
		
		//MENU MODULO ADMINISTRATIVO
		public void menuMA()
		{
			
			Console.WriteLine("*******************************************************************************");
			Console.WriteLine("*****                       MODULO ADMINISTRATIVO                         *****");
			Console.WriteLine("*******************************************************************************\n");
		
			Console.WriteLine("¿Qué desea hacer?\n"+
			                 "\n"+
			                 "1) Total vendido en la Tienda On-line\n"+
			                 "2) Total vendido por Cliente\n"+
			                 "3) Total vendido por Tarjeta\n"+
			                 "4) Volver\n");
			
			string opcion;
			opcion = Console.ReadLine();
			switch (opcion) 
			{
				case "1":
				Console.WriteLine("Total vendido en la tienda es de: $"+Recaudacion);
				Console.ReadKey();
				Console.Clear();
				menuMA();
				break;
				
				case "2":
				
				int i=0;
				foreach (Cliente c in ListaCli) 
				{
					c.TotalGastado = Financiado;	
					if (c.EstadoCli == true)
					{
							Console.WriteLine(i+1 +") [Cliente Nombre=" +c.Nombre +
					                  ", "+ "Dni="+ c.Dni + ", "+ "Nacimiento="+c.FechaNac+
					                  ", "+ "TtlGastado="+ 0 + "]" );
					}
					else
					{
						Console.WriteLine(i+1 +") [Cliente Nombre=" +c.Nombre +
					                  ", "+ "Dni="+ c.Dni + ", "+ "Nacimiento="+c.FechaNac+
					                  ", "+ "TtlGastado="+ c.TotalGastado + "]" );
					}
					i++;
				}
				Console.ReadKey();
				Console.Clear();
				menuMA();
				break;
				
				case "3":
				int j=0;
				foreach (Tarjeta t in ListaTarje) 
				{
					Console.WriteLine(j+1 +") [Tarjeta Nombre=" +t.Nombre +
					                  ", "+ "Banco="+ t.Banco + ", "+ 
					                  "Total Compras="+ t.TotalCompras + "]" );
					j++;
				}
				Console.ReadKey();
				Console.Clear();
				menuMA();
				break;
				
				case "4":
				Console.Clear();
				menuTM();
				break;
				
				default:
				int num;
				
				try
				{
					if (!(int.TryParse(opcion, out num)))
					{
						throw new ExcepcionPorDatosIncorrectos();
					}
						
					if (opcion == "")
					{
						throw new ExcepcionPorCadenaVacia();
					}
					int opcion1;
					opcion1 = int.Parse(opcion);
					if (opcion1 <=0 || opcion1 > 5) 
					{
						throw new ExcepcionNumInvalidos();
					}
				} 
				catch (ExcepcionPorDatosIncorrectos)
				{
					Console.WriteLine("Error!! Ingrese solo las opciones indicadas en el menu\n");
					Console.WriteLine("Presione cualquier tecla para continuar.....");
					Console.ReadKey();
					Console.Clear();
					menuMA();
				}
				catch (ExcepcionNumInvalidos) 
				{
					Console.WriteLine("Error!! Ingrese solo las opciones indicadas en el menu\n");
					Console.WriteLine("Presione cualquier tecla para continuar.....");
					Console.ReadKey();
					Console.Clear();
					menuMA();
				}
				catch (ExcepcionPorCadenaVacia)
				{
					Console.WriteLine("Error!! Ingrese solo las opciones indicadas en el menu\n");
					Console.WriteLine("Presione cualquier tecla para continuar.....");
					Console.ReadKey();
					Console.Clear();
					menuMA();
				}					
				break;
			}
		
		}
	
	}

}