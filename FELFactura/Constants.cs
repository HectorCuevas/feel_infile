using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FELFactura
{
    public class Constants
    {
        #region Rutas INFILE
        /*** Solitud de firma ***/
        public const String URL_SOLICITUD_FIRMA = "https://signer-emisores.feel.com.gt/";
        public const String METODO_SOLICITUD_FIRMA = "sign_solicitud_firmas/firma_xml";
        public const String ALIAS = "EPIDAURO";
        public const String ES_ANULACION = "N";
        public const String LLAVE = "4865c9949f6094472d6af60ab8d8453a";

        /*** Certificacion INFILE ***/
        public const String URL_CERTIFICACION_DTE = "https://certificador.feel.com.gt/";
        public const String METODO_CERTIFICACION_DTE = "fel/certificacion/dte";
        public const String NIT_EMISOR = "5203333";
        public const String CORREO_COPIA = "emayorgaa1@miumg.edu.gt";
        public const String HEADER_USUARIO = "usuario";
        public const String HEADER_LLAVE = "llave";
        public const String HEADER_IDENTIFICADOR = "identificador";
        public const String HEADER_USUARIO_TOKEN = "EPIDAURO";
        public const String HEADER_LLAVE_TOKEN = "F7FB8F31BB709D420FB3F1444162551D";
        public const String HEADER_IDENTIFICADOR_TOKEN = "NDEBEXC2";


        #endregion

        #region Rutas Megaprint
        /*** Rutas de megaprint ***/
        public static String URL_SOLICITAR_TOKEN = "https://dev.api.ifacere-fel.com/fel-dte-services/api/solicitarToken";
        public static String URL_REGISTRAR_DOCUMENTO = "https://dev.api.ifacere-fel.com/fel-dte-services/api/registrarDocumentoXML";
        public static String URL_VAIDAR_DOCUMENTO = "https://dev.api.ifacere-fel.com/fel-dte-services/api/validarDocumento";
        public static String URL_ANULAR_DOCUMENTO = "https://dev.api.ifacere-fel.com/fel-dte-services/api/anularDocumentoXML";
        public static String URL_CERTIFICADO = "C:\\certificado\\3225607-61589fea042b4cfc.pfx";
        public static String URL_CERTIFICADO_CONTRASENIA = "MayaZac/49";
        public static String UBICACION_XML_FACTURA = "C:\\Users\\leyla\\Dropbox\\universidad\\prosisco\\";
        public static String FRASE_2 = "1";
        public static String FRASE_1 = "1";
        public static String FRASE_CODIGO_2 = "2";
        public static String FRASE_CODIGO_1 = "1";
        public static String TIPO_FACTURA = "FACT";
        public static String TIPO_FACTURA_CAMBIARIA = "FCAM";
        public static String TIPO_FACTURA_PEQUENIO_CONTRIBUYENTE = "FPEQ";
        public static String TIPO_FACTURA_ESPECIAL = "FESP";
        public static String TIPO_NOTA_ABONO = "NABN";
        public static String TIPO_RECIBO_DONACION = "RDON";
        public static String TIPO_RECIBO = "RECI";
        public static String TIPO_NOTA_DEBITO = "NDEB";
        public static String TIPO_NOTA_CREDITO = "NCRE";
        #endregion

    }
}