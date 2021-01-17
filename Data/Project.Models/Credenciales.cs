using System.Collections.Generic;

namespace Project.Models
{
    public class Credenciales
    {
        public string usuario { get; set; }
        public string contraseña { get; set; }
    }
    public class OauthAccess
    {
        public string token { get; set; }
        public object UserAccess { get; set; }
    }
    public class DetalleUsuario
    {
        public string Estado { get; set; }
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public int IdPerfil { get; set; }
        public int IdSucursal { get; set; }
        public string Sucursal { get; set; }
        public float Descuento { get; set; }
        public string Perfil { get; set; }
        public string Fecha { get; set; }
        public List<Accesos> Accesos { get; set; }
    }
    public class Accesos
    {
        public int IdOpcion { get; set; }
        public int NOrden { get; set; }
        public int Title { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public string Class { get; set; }
        public int IdPadre { get; set; }
        public List<Accesos> Children { get; set; }

    }
}
