using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FEL_API.Models
{
    public class SolicitudAPI
    {
        public int id { get; set; }
        public String llave { get; set; }
        public String archivo { get; set; }
        public String codigo { get; set; }
        public String alias { get; set; }
        public String es_anulacion { get; set; }

       
    }
}