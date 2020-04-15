using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Threading;
using System.Net.Http;
using System.Net.Http.Headers;
using Modelos;
using FELFactura;
using Newtonsoft.Json;
using System.Xml;
//using fel;


namespace SolicitudFirma
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                #region XML
                string xml = "<dte:GTDocumento xmlns:ds=\"http://www.w3.org/2000/09/xmldsig#\" xmlns:dte=\"http://www.sat.gob.gt/dte/fel/0.1.0\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" Version=\"0.4\" xsi:schemaLocation=\"http://www.sat.gob.gt/dte/fel/0.1.0\">" +
                         "  <dte:SAT ClaseDocumento=\"dte\">" + "\n" +
                         "    <dte:DTE ID=\"DatosCertificados\">" + "\n" +
                         "      <dte:DatosEmision ID=\"DatosEmision\">" + "\n" +
                         "        <dte:DatosGenerales CodigoMoneda=\"GTQ\" FechaHoraEmision=\"2019-07-08T09:58:00-06:00\" Tipo=\"FACT\"></dte:DatosGenerales>" + "\n" +
                         "        <dte:Emisor AfiliacionIVA=\"GEN\" CodigoEstablecimiento=\"1\" CorreoEmisor=\"demo@demo.com.gt\" NITEmisor=\"23750278\" NombreComercial=\"DEMO\" NombreEmisor=\"DEMO, SOCIEDAD ANONIMA\">" + "\n" +
                         "          <dte:DireccionEmisor>" + "\n" +
                         "            <dte:Direccion>CUIDAD</dte:Direccion>" + "\n" +
                         "            <dte:CodigoPostal>01001</dte:CodigoPostal>" + "\n" +
                         "            <dte:Municipio>GUATEMALA</dte:Municipio>" + "\n" +
                         "            <dte:Departamento>GUATEMALA</dte:Departamento>" + "\n" +
                         "            <dte:Pais>GT</dte:Pais>" + "\n" +
                         "          </dte:DireccionEmisor>" + "\n" +
                         "        </dte:Emisor>" + "\n" +
                         "        <dte:Receptor CorreoReceptor=\"leyoalvizures4456@gmail.com\" IDReceptor=\"76365204\" NombreReceptor=\"Jaime Alvizures\">" + "\n" +
                         "          <dte:DireccionReceptor>" + "\n" +
                         "            <dte:Direccion>CUIDAD</dte:Direccion>" + "\n" +
                         "            <dte:CodigoPostal>01001</dte:CodigoPostal>" + "\n" +
                         "            <dte:Municipio>GUATEMALA</dte:Municipio>" + "\n" +
                         "            <dte:Departamento>GUATEMALA</dte:Departamento>" + "\n" +
                         "            <dte:Pais>GT</dte:Pais>" + "\n" +
                         "          </dte:DireccionReceptor>" + "\n" +
                         "        </dte:Receptor>" + "\n" +
                         "<dte:Frases><dte:Frase CodigoEscenario=\"1\" TipoFrase=\"1\"></dte:Frase></dte:Frases><dte:Items>          <dte:Item BienOServicio=\"B\" NumeroLinea=\"1\">" + "\n" +
                         "            <dte:Cantidad>1</dte:Cantidad>" + "\n" +
                         "<dte:UnidadMedida>UND</dte:UnidadMedida>" + "\n" +
                         "            <dte:Descripcion>PRODUCTO1</dte:Descripcion>" + "\n" +
                         "            <dte:PrecioUnitario>120</dte:PrecioUnitario>" + "\n" +
                         "            <dte:Precio>120</dte:Precio>" + "\n" +
                         "<dte:Descuento>0</dte:Descuento>" + "\n" +
                         "<dte:Impuestos>              <dte:Impuesto>" + "\n" +
                         "                <dte:NombreCorto>IVA</dte:NombreCorto>" + "\n" +
                         "                <dte:CodigoUnidadGravable>1</dte:CodigoUnidadGravable>" + "\n" +
                         "<dte:MontoGravable>107.14</dte:MontoGravable>" + "\n" +
                         "                <dte:MontoImpuesto>12.86</dte:MontoImpuesto>" + "\n" +
                         "              </dte:Impuesto>" + "\n" +
                         "</dte:Impuestos>            <dte:Total>120</dte:Total>" + "\n" +
                         "          </dte:Item>" + "\n" +
                         "</dte:Items>        <dte:Totales>" + "\n" +
                         "<dte:TotalImpuestos><dte:TotalImpuesto NombreCorto=\"IVA\" TotalMontoImpuesto=\"12.86\"></dte:TotalImpuesto></dte:TotalImpuestos>		<dte:GranTotal>120</dte:GranTotal>" + "\n" +
                         "        </dte:Totales>" + "\n" +
                         "      </dte:DatosEmision>" + "\n" +
                         "    </dte:DTE>" + "\n" +
                         " <dte:Adenda>" + "\n" +
                         "<Codigo_cliente>C01</Codigo_cliente>" + "\n" +
                         "<Observaciones>ESTA ES UNA ADENDA</Observaciones>" + "\n" +
                         " </dte:Adenda>  </dte:SAT>" + "\n" +
                         "</dte:GTDocumento>";
                #endregion

                // RequestFEL requestFEL = new RequestFEL();
                //  RequestFEL.getSignatureAsync().ToString();

                XMLFactura xmlObject = new XMLFactura();
                //String xmlInvoice = args[0].ToString();
                //String xmlDetail = args[1].ToString();
                // String path = args[2].ToString();
                // String fact_num = args[3].ToString();
                //  String xmlDoc = xmlObject.getXML(xmlInvoice, xmlDetail, path, fact_num);

                // byte[] data = Convert.FromBase64String(xmlInvoice);
                //  string decodedString = Encoding.UTF8.GetString(data);

                // envioSolicitud("");          
                //String objRequest = request.getSignatureAsync().ToString();
                //   Console.WriteLine(RequestFEL.getSignatureAsync().ToString());
                // RequestFEL.getSignatureAsync("");
                //RequestFEL.Main("");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadKey();
            Environment.Exit(0);
        }
        private static async Task envioSolicitud(String xml)

        {
            using (var client = new HttpClient())
            {
                //XmlDocument xmltest = new XmlDocument();
                /// xmltest.LoadXml(xml);

                //Pasar el xml a Base64
                //var arrayDeBytes = xml.ToString();
                var encoding = new UnicodeEncoding();
                // String xs = Convert.ToBase64String(encoding.GetBytes(xml),,)
                String s = Convert.ToBase64String(encoding.GetBytes(xml), Base64FormattingOptions.InsertLineBreaks);
                //Nuevo objeto de Solicitud
                Solictud solictud = new Solictud();
                solictud.llave = Constants.LLAVE;
                solictud.archivo = "PGR0ZTpHVERvY3VtZW50byB4bWxuczpkcz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC8wOS94bWxkc2lnIyIgeG1sbnM6ZHRlPSJodHRwOi8vd3d3LnNhdC5nb2IuZ3QvZHRlL2ZlbC8wLjEuMCIgeG1sbnM6eHNpPSJodHRwOi8vd3d3LnczLm9yZy8yMDAxL1hNTFNjaGVtYS1pbnN0YW5jZSIgVmVyc2lvbj0iMC40IiB4c2k6c2NoZW1hTG9jYXRpb249Imh0dHA6Ly93d3cuc2F0LmdvYi5ndC9kdGUvZmVsLzAuMS4wIj4gIAogIDxkdGU6U0FUIENsYXNlRG9jdW1lbnRvPSJkdGUiPgogICAgPGR0ZTpEVEUgSUQ9IkRhdG9zQ2VydGlmaWNhZG9zIj4KICAgICAgPGR0ZTpEYXRvc0VtaXNpb24gSUQ9IkRhdG9zRW1pc2lvbiI+CiAgICAgICAgPGR0ZTpEYXRvc0dlbmVyYWxlcyBDb2RpZ29Nb25lZGE9IkdUUSIgRmVjaGFIb3JhRW1pc2lvbj0iMjAxOS0wNy0wOFQwOTo1ODowMC0wNjowMCIgVGlwbz0iRkFDVCI+PC9kdGU6RGF0b3NHZW5lcmFsZXM+CiAgICAgICAgPGR0ZTpFbWlzb3IgQWZpbGlhY2lvbklWQT0iR0VOIiBDb2RpZ29Fc3RhYmxlY2ltaWVudG89IjEiIENvcnJlb0VtaXNvcj0iZGVtb0BkZW1vLmNvbS5ndCIgTklURW1pc29yPSIyMzc1MDI3OCIgTm9tYnJlQ29tZXJjaWFsPSJERU1PIiBOb21icmVFbWlzb3I9IkRFTU8sIFNPQ0lFREFEIEFOT05JTUEiPgogICAgICAgICAgPGR0ZTpEaXJlY2Npb25FbWlzb3I+CiAgICAgICAgICAgIDxkdGU6RGlyZWNjaW9uPkNVSURBRDwvZHRlOkRpcmVjY2lvbj4KICAgICAgICAgICAgPGR0ZTpDb2RpZ29Qb3N0YWw+MDEwMDE8L2R0ZTpDb2RpZ29Qb3N0YWw+CiAgICAgICAgICAgIDxkdGU6TXVuaWNpcGlvPkdVQVRFTUFMQTwvZHRlOk11bmljaXBpbz4KICAgICAgICAgICAgPGR0ZTpEZXBhcnRhbWVudG8+R1VBVEVNQUxBPC9kdGU6RGVwYXJ0YW1lbnRvPgogICAgICAgICAgICA8ZHRlOlBhaXM+R1Q8L2R0ZTpQYWlzPgogICAgICAgICAgPC9kdGU6RGlyZWNjaW9uRW1pc29yPgogICAgICAgIDwvZHRlOkVtaXNvcj4KICAgICAgICA8ZHRlOlJlY2VwdG9yIENvcnJlb1JlY2VwdG9yPSJsZXlvYWx2aXp1cmVzNDQ1NkBnbWFpbC5jb20iIElEUmVjZXB0b3I9Ijc2MzY1MjA0IiBOb21icmVSZWNlcHRvcj0iSmFpbWUgQWx2aXp1cmVzIj4KICAgICAgICAgIDxkdGU6RGlyZWNjaW9uUmVjZXB0b3I+CiAgICAgICAgICAgIDxkdGU6RGlyZWNjaW9uPkNVSURBRDwvZHRlOkRpcmVjY2lvbj4KICAgICAgICAgICAgPGR0ZTpDb2RpZ29Qb3N0YWw+MDEwMDE8L2R0ZTpDb2RpZ29Qb3N0YWw+CiAgICAgICAgICAgIDxkdGU6TXVuaWNpcGlvPkdVQVRFTUFMQTwvZHRlOk11bmljaXBpbz4KICAgICAgICAgICAgPGR0ZTpEZXBhcnRhbWVudG8+R1VBVEVNQUxBPC9kdGU6RGVwYXJ0YW1lbnRvPgogICAgICAgICAgICA8ZHRlOlBhaXM+R1Q8L2R0ZTpQYWlzPgogICAgICAgICAgPC9kdGU6RGlyZWNjaW9uUmVjZXB0b3I+CiAgICAgICAgPC9kdGU6UmVjZXB0b3I+CjxkdGU6RnJhc2VzPjxkdGU6RnJhc2UgQ29kaWdvRXNjZW5hcmlvPSIxIiBUaXBvRnJhc2U9IjEiPjwvZHRlOkZyYXNlPjwvZHRlOkZyYXNlcz48ZHRlOkl0ZW1zPiAgICAgICAgICA8ZHRlOkl0ZW0gQmllbk9TZXJ2aWNpbz0iQiIgTnVtZXJvTGluZWE9IjEiPgogICAgICAgICAgICA8ZHRlOkNhbnRpZGFkPjE8L2R0ZTpDYW50aWRhZD4KPGR0ZTpVbmlkYWRNZWRpZGE+VU5EPC9kdGU6VW5pZGFkTWVkaWRhPgogICAgICAgICAgICA8ZHRlOkRlc2NyaXBjaW9uPlBST0RVQ1RPMTwvZHRlOkRlc2NyaXBjaW9uPgogICAgICAgICAgICA8ZHRlOlByZWNpb1VuaXRhcmlvPjEyMDwvZHRlOlByZWNpb1VuaXRhcmlvPgogICAgICAgICAgICA8ZHRlOlByZWNpbz4xMjA8L2R0ZTpQcmVjaW8+CjxkdGU6RGVzY3VlbnRvPjA8L2R0ZTpEZXNjdWVudG8+CjxkdGU6SW1wdWVzdG9zPiAgICAgICAgICAgICAgPGR0ZTpJbXB1ZXN0bz4KICAgICAgICAgICAgICAgIDxkdGU6Tm9tYnJlQ29ydG8+SVZBPC9kdGU6Tm9tYnJlQ29ydG8+CiAgICAgICAgICAgICAgICA8ZHRlOkNvZGlnb1VuaWRhZEdyYXZhYmxlPjE8L2R0ZTpDb2RpZ29VbmlkYWRHcmF2YWJsZT4KPGR0ZTpNb250b0dyYXZhYmxlPjEwNy4xNDwvZHRlOk1vbnRvR3JhdmFibGU+CiAgICAgICAgICAgICAgICA8ZHRlOk1vbnRvSW1wdWVzdG8+MTIuODY8L2R0ZTpNb250b0ltcHVlc3RvPgogICAgICAgICAgICAgIDwvZHRlOkltcHVlc3RvPgo8L2R0ZTpJbXB1ZXN0b3M+ICAgICAgICAgICAgPGR0ZTpUb3RhbD4xMjA8L2R0ZTpUb3RhbD4KICAgICAgICAgIDwvZHRlOkl0ZW0+CjwvZHRlOkl0ZW1zPiAgICAgICAgPGR0ZTpUb3RhbGVzPgo8ZHRlOlRvdGFsSW1wdWVzdG9zPjxkdGU6VG90YWxJbXB1ZXN0byBOb21icmVDb3J0bz0iSVZBIiBUb3RhbE1vbnRvSW1wdWVzdG89IjEyLjg2Ij48L2R0ZTpUb3RhbEltcHVlc3RvPjwvZHRlOlRvdGFsSW1wdWVzdG9zPiAgIDxkdGU6R3JhblRvdGFsPjEyMDwvZHRlOkdyYW5Ub3RhbD4KICAgICAgICA8L2R0ZTpUb3RhbGVzPgogICAgICA8L2R0ZTpEYXRvc0VtaXNpb24+CiAgICA8L2R0ZTpEVEU+CiA8ZHRlOkFkZW5kYT4KPENvZGlnb19jbGllbnRlPkMwMTwvQ29kaWdvX2NsaWVudGU+CjxPYnNlcnZhY2lvbmVzPkVTVEEgRVMgVU5BIEFERU5EQTwvT2JzZXJ2YWNpb25lcz4KIDwvZHRlOkFkZW5kYT4gIDwvZHRlOlNBVD4KPGRzOlNpZ25hdHVyZSBJZD0ieG1sZHNpZy03ZjEzNGQwNS00ZTk2LTQxNTgtYmNiNC0zN2RiYmVmMmZjZmQiPgo8ZHM6U2lnbmVkSW5mbz4KPGRzOkNhbm9uaWNhbGl6YXRpb25NZXRob2QgQWxnb3JpdGhtPSJodHRwOi8vd3d3LnczLm9yZy9UUi8yMDAxL1JFQy14bWwtYzE0bi0yMDAxMDMxNSI+PC9kczpDYW5vbmljYWxpemF0aW9uTWV0aG9kPgo8ZHM6U2lnbmF0dXJlTWV0aG9kIEFsZ29yaXRobT0iaHR0cDovL3d3dy53My5vcmcvMjAwMS8wNC94bWxkc2lnLW1vcmUjcnNhLXNoYTI1NiI+PC9kczpTaWduYXR1cmVNZXRob2Q+CjxkczpSZWZlcmVuY2UgSWQ9InhtbGRzaWctN2YxMzRkMDUtNGU5Ni00MTU4LWJjYjQtMzdkYmJlZjJmY2ZkLXJlZjAiIFVSST0iI0RhdG9zRW1pc2lvbiI+CjxkczpUcmFuc2Zvcm1zPgo8ZHM6VHJhbnNmb3JtIEFsZ29yaXRobT0iaHR0cDovL3d3dy53My5vcmcvMjAwMC8wOS94bWxkc2lnI2VudmVsb3BlZC1zaWduYXR1cmUiPjwvZHM6VHJhbnNmb3JtPgo8L2RzOlRyYW5zZm9ybXM+CjxkczpEaWdlc3RNZXRob2QgQWxnb3JpdGhtPSJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGVuYyNzaGEyNTYiPjwvZHM6RGlnZXN0TWV0aG9kPgo8ZHM6RGlnZXN0VmFsdWU+KzlNZWJuSk5oMFV4VUZKL0tvUDU0Uzg3OStuSm4wU2E1QXNMNUJkY2lTRT08L2RzOkRpZ2VzdFZhbHVlPgo8L2RzOlJlZmVyZW5jZT4KPGRzOlJlZmVyZW5jZSBUeXBlPSJodHRwOi8vdXJpLmV0c2kub3JnLzAxOTAzI1NpZ25lZFByb3BlcnRpZXMiIFVSST0iI3htbGRzaWctN2YxMzRkMDUtNGU5Ni00MTU4LWJjYjQtMzdkYmJlZjJmY2ZkLXNpZ25lZHByb3BzIj4KPGRzOkRpZ2VzdE1ldGhvZCBBbGdvcml0aG09Imh0dHA6Ly93d3cudzMub3JnLzIwMDEvMDQveG1sZW5jI3NoYTI1NiI+PC9kczpEaWdlc3RNZXRob2Q+CjxkczpEaWdlc3RWYWx1ZT4vWDJ6VitVK2FhdWdUa1JKd2pPeTBFVW9BOGZFRnI0WE1EdWtINmpIMjFZPTwvZHM6RGlnZXN0VmFsdWU+CjwvZHM6UmVmZXJlbmNlPgo8L2RzOlNpZ25lZEluZm8+CjxkczpTaWduYXR1cmVWYWx1ZSBJZD0ieG1sZHNpZy03ZjEzNGQwNS00ZTk2LTQxNTgtYmNiNC0zN2RiYmVmMmZjZmQtc2lndmFsdWUiPgpNUFBVVXU0NkVoYS80eFlqWjJyYXBRQWZHdmUrSWRuV1VJL2RBQVlzZHBYSjhKTUF2VUNJdkVIK2lWaUdFNlZvUkVoTk1RUTg4WGhICkZ4RlN3VGRzM0xQVEUwL0haZnhVemdJK1kreEV2c0RjM1BJdUgxblA3bnpwQURwaHNUc2FBa2hTQmxyL2QvdFIwS2tlSTkxZCtScDMKTm5wOUREa0FaRVV5N3V3a29xL2t6cEw1OG43enR6Mlk0UVgwK01GelJGSFFPV0pZZDExaEd0cFc1L0lCclNuUC9uQlNqT2o1YWdhNApJaFhuSVlrbm5WaTNtWG0zSDdEbzlQRFZZcU1PTkpHS0ZoREFhUFVEYXBVa0I2M29JMTg1R3VjV3lUa0ZqTmdwYUdRU1gzUmZsWXR2CllubEoxMUs0eS9NRWNzTFdad0o1VVRyN0JaQUhWUWZqb3lmZUhBPT0KPC9kczpTaWduYXR1cmVWYWx1ZT4KPGRzOktleUluZm8+CjxkczpYNTA5RGF0YT4KPGRzOlg1MDlDZXJ0aWZpY2F0ZT4KTUlJRFVqQ0NBanFnQXdJQkFnSUlFa1dkb056R2hKNHdEUVlKS29aSWh2Y05BUUVMQlFBd0tURU1NQW9HQTFVRUF3d0RSa1ZNTVF3dwpDZ1lEVlFRS0RBTlRRVlF4Q3pBSkJnTlZCQVlUQWtkVU1CNFhEVEU1TURZd05qRTJNelUxTVZvWERUSXhNRFl3TlRFMk16VTFNVm93CktERVJNQThHQTFVRUF3d0lNak0zTlRBeU56Z3hFekFSQmdOVkJBb01Dbk5oZEM1bmIySXVaM1F3Z2dFaU1BMEdDU3FHU0liM0RRRUIKQVFVQUE0SUJEd0F3Z2dFS0FvSUJBUUNVaGJ5LzFRR0RaR2R2SmZ0Wjk5YWZ4MUUyekMvRUYrVWxLZ1hCakUyRmNtV2IweHlmMGFKOAo5cnd4OGl2VE1VSVBmL3lLUlZtV2lWcmcrbXAwSU1IVjU0NTNRWnMrVEJGWTNOcEs2Qm1NcTU1YUR4NUtkRENsbXlVaENZRzJ3T3pFCnF2d3NVRnJsekpCK0tFR0g0Wlg1VTF5cTJ2VWh1dmdSY2VaWi9BRkl3SnpsUytHS0EyU3RmMzJYOWloNEcybVBtM1lNRHJIelpKMUwKRmdVdTloNUdqU0ZoenpIdllycStJbXdaeGxFUFAxNk5kc0RJSDZIWG9lZll4WUlZRzlyaCt0Q2hRZUYvVE9JUXpFUWdnMkRhR3ZueQpteXAwK1RGbFpMTU9jTGlBR05JcnZzUmZHS0swdEtwY0lVRENWYU1ROFRtYi9iQjZGeHlBZ2FrZVI3OVJBZ01CQUFHamZ6QjlNQXdHCkExVWRFd0VCL3dRQ01BQXdId1lEVlIwakJCZ3dGb0FVYzczemlsSnNNNWhaMS9mUXJiRnpqTFJRU2dvd0hRWURWUjBsQkJZd0ZBWUkKS3dZQkJRVUhBd0lHQ0NzR0FRVUZCd01FTUIwR0ExVWREZ1FXQkJRbnV2cEV2bkNJMEV4STczdm1JR3pab0lvdUlUQU9CZ05WSFE4QgpBZjhFQkFNQ0JlQXdEUVlKS29aSWh2Y05BUUVMQlFBRGdnRUJBSGMxWWlsYVdobThwNG1wY1dyL1djMENxbEtxbTdRcnU3RWRrdUFECnh4T0NpZVZJUTExOFlnNkJPV1VLV3NieHRnaTlRRjV3c0FBNWJ2Q1pMTTlZWGg0ZmFrQW8zenNVVjJXOC9RNUVQdC9zenUvUUdsbmcKcG1aTzlJNm1GR2VzbjNjQzFGYWVqRUUxekNzaEhaMkZlK3J2MW5RZTJNN2VFT0RSbk9tbEtET25XbkUvMXRXZmJaUDFhb09VRHVCWgpIQ2VicnlhMG9WTmc5UVRIOTRaWEVVZUNlWE9CZGFXZ0RpZ21hamV3dS9zdnlXbUJqRWE3YVZGT01ZZmVmUnVRVUh6cWw1SU4zT3hmClBmOE1hV01uOU9sMDFDM1FxRnJrSXhILzZJdENMRzZFWnNTdlJzcTBwRXJMQy9xMm02aVIyUW5CakFHc1hjdGRVZ0FvbjFrR3RTbz0KPC9kczpYNTA5Q2VydGlmaWNhdGU+CjwvZHM6WDUwOURhdGE+CjwvZHM6S2V5SW5mbz4KPGRzOk9iamVjdD48eGFkZXM6UXVhbGlmeWluZ1Byb3BlcnRpZXMgeG1sbnM6eGFkZXM9Imh0dHA6Ly91cmkuZXRzaS5vcmcvMDE5MDMvdjEuMy4yIyIgeG1sbnM6eGFkZXMxNDE9Imh0dHA6Ly91cmkuZXRzaS5vcmcvMDE5MDMvdjEuNC4xIyIgVGFyZ2V0PSIjeG1sZHNpZy03ZjEzNGQwNS00ZTk2LTQxNTgtYmNiNC0zN2RiYmVmMmZjZmQiPjx4YWRlczpTaWduZWRQcm9wZXJ0aWVzIElkPSJ4bWxkc2lnLTdmMTM0ZDA1LTRlOTYtNDE1OC1iY2I0LTM3ZGJiZWYyZmNmZC1zaWduZWRwcm9wcyI+PHhhZGVzOlNpZ25lZFNpZ25hdHVyZVByb3BlcnRpZXM+PHhhZGVzOlNpZ25pbmdUaW1lPjIwMTktMDctMTFUMTc6MzU6MDguNjA0WjwveGFkZXM6U2lnbmluZ1RpbWU+PHhhZGVzOlNpZ25pbmdDZXJ0aWZpY2F0ZT48eGFkZXM6Q2VydD48eGFkZXM6Q2VydERpZ2VzdD48ZHM6RGlnZXN0TWV0aG9kIEFsZ29yaXRobT0iaHR0cDovL3d3dy53My5vcmcvMjAwMS8wNC94bWxlbmMjc2hhMjU2Ij48L2RzOkRpZ2VzdE1ldGhvZD48ZHM6RGlnZXN0VmFsdWU+dVg2QTZyWUFSUDBFb09mTytUUTduN01vNGpKS0ZvWXFwenlkOWxFSzRuZz08L2RzOkRpZ2VzdFZhbHVlPjwveGFkZXM6Q2VydERpZ2VzdD48eGFkZXM6SXNzdWVyU2VyaWFsPjxkczpYNTA5SXNzdWVyTmFtZT5DPUdULE89U0FULENOPUZFTDwvZHM6WDUwOUlzc3Vlck5hbWU+PGRzOlg1MDlTZXJpYWxOdW1iZXI+MTMxNjYzMTc4MDMwMDA2MzkwMjwvZHM6WDUwOVNlcmlhbE51bWJlcj48L3hhZGVzOklzc3VlclNlcmlhbD48L3hhZGVzOkNlcnQ+PC94YWRlczpTaWduaW5nQ2VydGlmaWNhdGU+PC94YWRlczpTaWduZWRTaWduYXR1cmVQcm9wZXJ0aWVzPjwveGFkZXM6U2lnbmVkUHJvcGVydGllcz48L3hhZGVzOlF1YWxpZnlpbmdQcm9wZXJ0aWVzPjwvZHM6T2JqZWN0Pgo8L2RzOlNpZ25hdHVyZT48L2R0ZTpHVERvY3VtZW50bz4=";
                // solictud.archivo = s;
                solictud.alias = Constants.ALIAS;
                solictud.es_anulacion = "N";

                //pasar a json el objeto
                string json = JsonConvert.SerializeObject(solictud);


                client.BaseAddress = new Uri(Constants.URL_SOLICITUD_FIRMA);
                client.DefaultRequestHeaders.Accept.Clear();
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, Constants.METODO_SOLICITUD_FIRMA);
                request.Content = new StringContent(json,
                                                    Encoding.UTF8,
                                                    "application/json");
                await client.SendAsync(request)
                .ContinueWith(async responseTask =>
                 {
                     Console.WriteLine("Response: {0}", responseTask.Result.Content.ReadAsStringAsync().Result);
                     //Deserealizacion de la respuesta
                     // RespuestaSolitud respuestaSolitud = new RespuestaSolitud();
                     //respuestaSolitud = JsonConvert.DeserializeObject<RespuestaSolitud>(responseTask.Result.Content.ReadAsStringAsync().Result);
                     //    Console.WriteLine("\n{0}", respuestaSolitud.descripcion);
                     //String xmlDte = respuestaSolitud.archivo.ToString();
                     // await certificacion(xmlDte);
                 });
            }
            Console.ReadKey();
        }

        public static String certificacion(String xml)
        {
            Certificacion certificacion = new Certificacion();
            certificacion.nit_emisor = Constants.NIT_EMISOR;
            certificacion.correo_copia = Constants.CORREO_COPIA;
            certificacion.xml_dte = xml;

            //pasar a json el objeto
            string json = JsonConvert.SerializeObject(certificacion);



            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Constants.URL_CERTIFICACION_DTE);
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, Constants.METODO_CERTIFICACION_DTE);
                request.Headers.Add(Constants.HEADER_USUARIO, Constants.HEADER_USUARIO_TOKEN);
                request.Headers.Add(Constants.HEADER_LLAVE, Constants.HEADER_LLAVE_TOKEN);
                request.Headers.Add(Constants.HEADER_IDENTIFICADOR, Constants.HEADER_IDENTIFICADOR_TOKEN);
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");
                String d = "";
                using (HttpResponseMessage response = client.SendAsync(request).Result)
                {
                    using (HttpContent content = response.Content)
                    {
                        String json1 = content.ReadAsStringAsync().Result;
                        d = json1.ToString();
                    }
                }

            }
            return null;
        }
    }
}













