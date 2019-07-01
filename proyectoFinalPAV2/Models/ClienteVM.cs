using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyectoFinalPAV2.Models
{
    /*public class FiltroClienteVM
    {
        public string apellido { get; set; }
        public string nombre { get; set; }
        public string razonSocial { get; set; }
        public int cuit { get; set; }
    }*/

    public class ListadoClienteVM
    {
        public int idCliente { get; set; }
        public string tipoCliente { get; set; }
        public string percepcionIIBB { get; set; }
        public string percepcionComEInd { get; set; }
        public string apellido { get; set; }
        public string nombre { get; set; }
        public string razonSocial { get; set; }
        public int cuit { get; set; }
        public int ingBrutos { get; set; }
        public string domicilio { get; set; }
        public string localidad { get; set; }
        public string telefono { get; set; }
        public int habilitado { get; set; }
        public int pagoCtaCte { get; set; }
    }
}