using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FEL_API.Models
{
    public class DatosFox
    {
        public int id { get; set; }
        public String xml_encabezado { get; set; }
        public String xml_detalle { get; set; }
        public String num_fac { get; set; }
        public String token { get; set; }
        public String path { get; set; }
    }
}