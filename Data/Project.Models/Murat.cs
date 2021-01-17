using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models
{
    public class MuratPedidos
    {
        public int IdCliente { get; set; }
        public string SCorreo { get; set; }
        public string SNro_Celular { get; set; }
        public string SNombre { get; set; }
        public string SApellido { get; set; }
        public int IdPais { get; set; }
        public int Ubigeo { get; set; }
        public string SDireccion { get; set; }
        public string SReferencia { get; set; }
        public int Cod_Docto_Venta { get; set; }
        public int Cod_Docto_Identidad { get; set; }
        public string SNro_Docto { get; set; }
        public int NMayor_Edad { get; set; }
        public string DFecha { get; set; }
        public int Cod_Moneda { get; set; }
        public float NImporte { get; set; }
        public float NImporte_Envio { get; set; }
        public float NTotal { get; set; }
        public string Nro_Operacion { get; set; }
        public int IdUsuario { get; set; }
        public List<MuratPedidoDetalle> Detalle { get; set; }
    }

    public class MuratPedidoDetalle
    {
        public int IdProducto { get; set; }
        public int Cod_Color { get; set; }
        public int Cod_Talla { get; set; }
        public int NCantidad { get; set; }
        public float NPrecio { get; set; }
        public int IdPPublic_Producto { get; set; }
    }

    public class MuratClientes
    {
        public int IdCliente { get; set; }
        public string SCorreo { get; set; }
        public string SNombre { get; set; }
        public string SApellido { get; set; }
        public string SNombre_Largo { get; set; }
        public string SNro_Telefono { get; set; }
        public string Contrasena { get; set; }
    }
}
