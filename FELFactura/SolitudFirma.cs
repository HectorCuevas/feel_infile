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

namespace FELFactura
{
    public class SolitudFirma
    {
        public async Task hacerAsync(String xml)
        {
            using (var client = new HttpClient())
            { 
                //Pasar el xml a Base64
                var arrayDeBytes = xml.ToString();
                var encoding = new UnicodeEncoding();
                String s = Convert.ToBase64String(encoding.GetBytes(xml), Base64FormattingOptions.InsertLineBreaks);
                Solictud solictud = new Solictud();
                solictud.llave = Constants.LLAVE;
                solictud.archivo = "PGR0ZTpHVERvY3VtZW50byB4bWxuczpkcz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC8wOS94bWxkc2lnIyIgeG1sbnM6ZHRlPSJodHRwOi8vd3d3LnNhdC5nb2IuZ3QvZHRlL2ZlbC8wLjEuMCIgeG1sbnM6eHNpPSJodHRwOi8vd3d3LnczLm9yZy8yMDAxL1hNTFNjaGVtYS1pbnN0YW5jZSIgVmVyc2lvbj0iMC40IiB4c2k6c2NoZW1hTG9jYXRpb249Imh0dHA6Ly93d3cuc2F0LmdvYi5ndC9kdGUvZmVsLzAuMS4wIj4gIA0KICA8ZHRlOlNBVCBDbGFzZURvY3VtZW50bz0iZHRlIj4NCiAgICA8ZHRlOkRURSBJRD0iRGF0b3NDZXJ0aWZpY2Fkb3MiPg0KICAgICAgPGR0ZTpEYXRvc0VtaXNpb24gSUQ9IkRhdG9zRW1pc2lvbiI+DQogICAgICAgIDxkdGU6RGF0b3NHZW5lcmFsZXMgQ29kaWdvTW9uZWRhPSJHVFEiIEZlY2hhSG9yYUVtaXNpb249IjIwMTktMDctMDhUMDk6NTg6MDAtMDY6MDAiIFRpcG89IkZBQ1QiPjwvZHRlOkRhdG9zR2VuZXJhbGVzPg0KICAgICAgICA8ZHRlOkVtaXNvciBBZmlsaWFjaW9uSVZBPSJHRU4iIENvZGlnb0VzdGFibGVjaW1pZW50bz0iMSIgQ29ycmVvRW1pc29yPSJkZW1vQGRlbW8uY29tLmd0IiBOSVRFbWlzb3I9IjIzNzUwMjc4IiBOb21icmVDb21lcmNpYWw9IkRFTU8iIE5vbWJyZUVtaXNvcj0iREVNTywgU09DSUVEQUQgQU5PTklNQSI+DQogICAgICAgICAgPGR0ZTpEaXJlY2Npb25FbWlzb3I+DQogICAgICAgICAgICA8ZHRlOkRpcmVjY2lvbj5DVUlEQUQ8L2R0ZTpEaXJlY2Npb24+DQogICAgICAgICAgICA8ZHRlOkNvZGlnb1Bvc3RhbD4wMTAwMTwvZHRlOkNvZGlnb1Bvc3RhbD4NCiAgICAgICAgICAgIDxkdGU6TXVuaWNpcGlvPkdVQVRFTUFMQTwvZHRlOk11bmljaXBpbz4NCiAgICAgICAgICAgIDxkdGU6RGVwYXJ0YW1lbnRvPkdVQVRFTUFMQTwvZHRlOkRlcGFydGFtZW50bz4NCiAgICAgICAgICAgIDxkdGU6UGFpcz5HVDwvZHRlOlBhaXM+DQogICAgICAgICAgPC9kdGU6RGlyZWNjaW9uRW1pc29yPg0KICAgICAgICA8L2R0ZTpFbWlzb3I+DQogICAgICAgIDxkdGU6UmVjZXB0b3IgQ29ycmVvUmVjZXB0b3I9ImxleW9hbHZpenVyZXM0NDU2QGdtYWlsLmNvbSIgSURSZWNlcHRvcj0iNzYzNjUyMDQiIE5vbWJyZVJlY2VwdG9yPSJKYWltZSBBbHZpenVyZXMiPg0KICAgICAgICAgIDxkdGU6RGlyZWNjaW9uUmVjZXB0b3I+DQogICAgICAgICAgICA8ZHRlOkRpcmVjY2lvbj5DVUlEQUQ8L2R0ZTpEaXJlY2Npb24+DQogICAgICAgICAgICA8ZHRlOkNvZGlnb1Bvc3RhbD4wMTAwMTwvZHRlOkNvZGlnb1Bvc3RhbD4NCiAgICAgICAgICAgIDxkdGU6TXVuaWNpcGlvPkdVQVRFTUFMQTwvZHRlOk11bmljaXBpbz4NCiAgICAgICAgICAgIDxkdGU6RGVwYXJ0YW1lbnRvPkdVQVRFTUFMQTwvZHRlOkRlcGFydGFtZW50bz4NCiAgICAgICAgICAgIDxkdGU6UGFpcz5HVDwvZHRlOlBhaXM+DQogICAgICAgICAgPC9kdGU6RGlyZWNjaW9uUmVjZXB0b3I+DQogICAgICAgIDwvZHRlOlJlY2VwdG9yPg0KPGR0ZTpGcmFzZXM+PGR0ZTpGcmFzZSBDb2RpZ29Fc2NlbmFyaW89IjEiIFRpcG9GcmFzZT0iMSI+PC9kdGU6RnJhc2U+PC9kdGU6RnJhc2VzPjxkdGU6SXRlbXM+ICAgICAgICAgIDxkdGU6SXRlbSBCaWVuT1NlcnZpY2lvPSJCIiBOdW1lcm9MaW5lYT0iMSI+DQogICAgICAgICAgICA8ZHRlOkNhbnRpZGFkPjE8L2R0ZTpDYW50aWRhZD4NCjxkdGU6VW5pZGFkTWVkaWRhPlVORDwvZHRlOlVuaWRhZE1lZGlkYT4NCiAgICAgICAgICAgIDxkdGU6RGVzY3JpcGNpb24+UFJPRFVDVE8xPC9kdGU6RGVzY3JpcGNpb24+DQogICAgICAgICAgICA8ZHRlOlByZWNpb1VuaXRhcmlvPjEyMDwvZHRlOlByZWNpb1VuaXRhcmlvPg0KICAgICAgICAgICAgPGR0ZTpQcmVjaW8+MTIwPC9kdGU6UHJlY2lvPg0KPGR0ZTpEZXNjdWVudG8+MDwvZHRlOkRlc2N1ZW50bz4NCjxkdGU6SW1wdWVzdG9zPiAgICAgICAgICAgICAgPGR0ZTpJbXB1ZXN0bz4NCiAgICAgICAgICAgICAgICA8ZHRlOk5vbWJyZUNvcnRvPklWQTwvZHRlOk5vbWJyZUNvcnRvPg0KICAgICAgICAgICAgICAgIDxkdGU6Q29kaWdvVW5pZGFkR3JhdmFibGU+MTwvZHRlOkNvZGlnb1VuaWRhZEdyYXZhYmxlPg0KPGR0ZTpNb250b0dyYXZhYmxlPjEwNy4xNDwvZHRlOk1vbnRvR3JhdmFibGU+DQogICAgICAgICAgICAgICAgPGR0ZTpNb250b0ltcHVlc3RvPjEyLjg2PC9kdGU6TW9udG9JbXB1ZXN0bz4NCiAgICAgICAgICAgICAgPC9kdGU6SW1wdWVzdG8+DQo8L2R0ZTpJbXB1ZXN0b3M+ICAgICAgICAgICAgPGR0ZTpUb3RhbD4xMjA8L2R0ZTpUb3RhbD4NCiAgICAgICAgICA8L2R0ZTpJdGVtPg0KPC9kdGU6SXRlbXM+ICAgICAgICA8ZHRlOlRvdGFsZXM+DQo8ZHRlOlRvdGFsSW1wdWVzdG9zPjxkdGU6VG90YWxJbXB1ZXN0byBOb21icmVDb3J0bz0iSVZBIiBUb3RhbE1vbnRvSW1wdWVzdG89IjEyLjg2Ij48L2R0ZTpUb3RhbEltcHVlc3RvPjwvZHRlOlRvdGFsSW1wdWVzdG9zPiAgIDxkdGU6R3JhblRvdGFsPjEyMDwvZHRlOkdyYW5Ub3RhbD4NCiAgICAgICAgPC9kdGU6VG90YWxlcz4NCiAgICAgIDwvZHRlOkRhdG9zRW1pc2lvbj4NCiAgICA8L2R0ZTpEVEU+DQogPGR0ZTpBZGVuZGE+DQo8Q29kaWdvX2NsaWVudGU+QzAxPC9Db2RpZ29fY2xpZW50ZT4NCjxPYnNlcnZhY2lvbmVzPkVTVEEgRVMgVU5BIEFERU5EQTwvT2JzZXJ2YWNpb25lcz4NCiA8L2R0ZTpBZGVuZGE+ICA8L2R0ZTpTQVQ+DQo8L2R0ZTpHVERvY3VtZW50bz4=";
                solictud.codigo = "155ssss20";
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
                .ContinueWith(responseTask =>
                {
                    Console.WriteLine(responseTask.Result.Content.ReadAsStringAsync().Result);
                });
            }
            Console.ReadKey();
        }
    }
}