using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services;

namespace FELFactura
{
    /// <summary>
    /// Descripción breve de solicitud
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class solicitud : System.Web.Services.WebService
    {

        [WebMethod]
        public String envioSolicitudAsync (String XMLInvoice/***, String XMLDetailInvoce, 
            String fac_num**/)
        {
            DataSet ds = new DataSet();
            String asd = "";
            try
            {
                
                asd = Task.Run(() => SolitudFirma.envioSolitudAsync("")).ToString();
                ds.Tables.Add("fuck");
                ds.WriteXml("asdsadas");
            }
            catch (Exception ex) {

            }
            return asd;
        }
        private async System.Threading.Tasks.Task<string> valorAsync() {
            
            String asdasd = await SolitudFirma.envioSolitudAsync("");
            //res(asdasd);
            return asdasd;
        }
        private String res(String asd) {
            
            return asd;
        }
    }
}
