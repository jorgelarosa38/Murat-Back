using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models
{
    public class Cliente
    {
		public int ID { get; set; }
		public int TipoDoc { get; set; }
		public string NroDoc { get; set; }
		public string RazonSocial { get; set; }
		public int Rubro { get; set; }
		public int Pais { get; set; }
		public string Departamento { get; set; }
		public string Provincia { get; set; }
		public string Distrito { get; set; }
		public string Direccion { get; set; }
		public string Referencia { get; set; }
		public string Contacto { get; set; }
		public string Correo { get; set; }
		public string Telefono1 { get; set; }
		public string Telefono2 { get; set; }
		public string Telefono3 { get; set; }
		public string PaginaWeb { get; set; }
		public int CodRedesSociales1 { get; set; }
		public string RedesSociales1 { get; set; }
		public int CodRedesSociales2 { get; set; }
		public string RedesSociales2 { get; set; }
		public int Categoria { get; set; }
		public string Comentario { get; set; }
		public int Origen { get; set; }
		public int IDUsuario { get; set; }
	}
}
