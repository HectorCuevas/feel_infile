using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Xml;
using FEL_API.Models;
using FELFactura;
using Modelos;
using Newtonsoft.Json;

namespace FEL_API.Controllers
{
    public class SolicitudAPIsController : ApiController
    {
        private FEL_APIContext db = new FEL_APIContext();

        // GET: api/SolicitudAPIs
        public IQueryable<SolicitudAPI> GetSolicitudAPIs()
        {
            return db.SolicitudAPIs;
        }

        // GET: api/SolicitudAPIs/5
        [ResponseType(typeof(SolicitudAPI))]
        public IHttpActionResult GetSolicitudAPI(int id)
        {
            SolicitudAPI solicitudAPI = db.SolicitudAPIs.Find(id);
            if (solicitudAPI == null)
            {
                return NotFound();
            }

            return Ok(solicitudAPI);
        }

        // PUT: api/SolicitudAPIs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSolicitudAPI(int id, SolicitudAPI solicitudAPI)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != solicitudAPI.id)
            {
                return BadRequest();
            }

            db.Entry(solicitudAPI).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SolicitudAPIExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/SolicitudAPIs
        [ResponseType(typeof(SolicitudAPI))]
        public async Task<IHttpActionResult> PostSolicitudAPIAsync(SolicitudAPI solicitudAPI)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            String res = await hacerAsync("");
            return Ok(res);
        }

        // DELETE: api/SolicitudAPIs/5
        [ResponseType(typeof(SolicitudAPI))]
        public IHttpActionResult DeleteSolicitudAPI(int id)
        {
            SolicitudAPI solicitudAPI = db.SolicitudAPIs.Find(id);
            if (solicitudAPI == null)
            {
                return NotFound();
            }

            db.SolicitudAPIs.Remove(solicitudAPI);
            db.SaveChanges();

            return Ok(solicitudAPI);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SolicitudAPIExists(int id)
        {
            return db.SolicitudAPIs.Count(e => e.id == id) > 0;
        }

        private static async Task<string> hacerAsync(String xml)
        {
            var tags = "";
            using (var client = new HttpClient())
            {
                //  XmlDocument xmltest = new XmlDocument();
                //xmltest.LoadXml(xml);

                //Pasar el xml a Base64
                var arrayDeBytes = xml.ToString();
                var encoding = new UnicodeEncoding();
                String s = Convert.ToBase64String(encoding.GetBytes(xml), Base64FormattingOptions.InsertLineBreaks);
                Solictud solictud = new Solictud();
                solictud.llave = Constants.LLAVE_TOKEN;
                solictud.archivo = "PGR0ZTpHVERvY3VtZW50byB4bWxuczpkcz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC8wOS94bWxkc2lnIyIgeG1sbnM6ZHRlPSJodHRwOi8vd3d3LnNhdC5nb2IuZ3QvZHRlL2ZlbC8wLjEuMCIgeG1sbnM6eHNpPSJodHRwOi8vd3d3LnczLm9yZy8yMDAxL1hNTFNjaGVtYS1pbnN0YW5jZSIgVmVyc2lvbj0iMC40IiB4c2k6c2NoZW1hTG9jYXRpb249Imh0dHA6Ly93d3cuc2F0LmdvYi5ndC9kdGUvZmVsLzAuMS4wIj4KICA8ZHRlOlNBVCBDbGFzZURvY3VtZW50bz0iZHRlIj4KICAgIDxkdGU6RFRFIElEPSJEYXRvc0NlcnRpZmljYWRvcyI+CiAgICAgIDxkdGU6RGF0b3NFbWlzaW9uIElEPSJEYXRvc0VtaXNpb24iPgogICAgICAgIDxkdGU6RGF0b3NHZW5lcmFsZXMgQ29kaWdvTW9uZWRhPSJHVFEiIEZlY2hhSG9yYUVtaXNpb249IjIwMTktMDctMDhUMDk6NTg6MDAtMDY6MDAiIFRpcG89IkZBQ1QiPjwvZHRlOkRhdG9zR2VuZXJhbGVzPgogICAgICAgIDxkdGU6RW1pc29yIEFmaWxpYWNpb25JVkE9IkdFTiIgQ29kaWdvRXN0YWJsZWNpbWllbnRvPSIxIiBDb3JyZW9FbWlzb3I9ImRlbW9AZGVtby5jb20uZ3QiIE5JVEVtaXNvcj0iMjM3NTAyNzgiIE5vbWJyZUNvbWVyY2lhbD0iREVNTyIgTm9tYnJlRW1pc29yPSJERU1PLCBTT0NJRURBRCBBTk9OSU1BIj4KICAgICAgICAgIDxkdGU6RGlyZWNjaW9uRW1pc29yPgogICAgICAgICAgICA8ZHRlOkRpcmVjY2lvbj5DVUlEQUQ8L2R0ZTpEaXJlY2Npb24+CiAgICAgICAgICAgIDxkdGU6Q29kaWdvUG9zdGFsPjAxMDAxPC9kdGU6Q29kaWdvUG9zdGFsPgogICAgICAgICAgICA8ZHRlOk11bmljaXBpbz5HVUFURU1BTEE8L2R0ZTpNdW5pY2lwaW8+CiAgICAgICAgICAgIDxkdGU6RGVwYXJ0YW1lbnRvPkdVQVRFTUFMQTwvZHRlOkRlcGFydGFtZW50bz4KICAgICAgICAgICAgPGR0ZTpQYWlzPkdUPC9kdGU6UGFpcz4KICAgICAgICAgIDwvZHRlOkRpcmVjY2lvbkVtaXNvcj4KICAgICAgICA8L2R0ZTpFbWlzb3I+CiAgICAgICAgPGR0ZTpSZWNlcHRvciBDb3JyZW9SZWNlcHRvcj0ibGV5b2Fsdml6dXJlczQ0NTZAZ21haWwuY29tIiBJRFJlY2VwdG9yPSI3NjM2NTIwNCIgTm9tYnJlUmVjZXB0b3I9IkphaW1lIEFsdml6dXJlcyI+CiAgICAgICAgICA8ZHRlOkRpcmVjY2lvblJlY2VwdG9yPgogICAgICAgICAgICA8ZHRlOkRpcmVjY2lvbj5DVUlEQUQ8L2R0ZTpEaXJlY2Npb24+CiAgICAgICAgICAgIDxkdGU6Q29kaWdvUG9zdGFsPjAxMDAxPC9kdGU6Q29kaWdvUG9zdGFsPgogICAgICAgICAgICA8ZHRlOk11bmljaXBpbz5HVUFURU1BTEE8L2R0ZTpNdW5pY2lwaW8+CiAgICAgICAgICAgIDxkdGU6RGVwYXJ0YW1lbnRvPkdVQVRFTUFMQTwvZHRlOkRlcGFydGFtZW50bz4KICAgICAgICAgICAgPGR0ZTpQYWlzPkdUPC9kdGU6UGFpcz4KICAgICAgICAgIDwvZHRlOkRpcmVjY2lvblJlY2VwdG9yPgogICAgICAgIDwvZHRlOlJlY2VwdG9yPgo8ZHRlOkZyYXNlcz48ZHRlOkZyYXNlIENvZGlnb0VzY2VuYXJpbz0iMSIgVGlwb0ZyYXNlPSIxIj48L2R0ZTpGcmFzZT48L2R0ZTpGcmFzZXM+PGR0ZTpJdGVtcz4gICAgICAgICAgPGR0ZTpJdGVtIEJpZW5PU2VydmljaW89IkIiIE51bWVyb0xpbmVhPSIxIj4KICAgICAgICAgICAgPGR0ZTpDYW50aWRhZD4xPC9kdGU6Q2FudGlkYWQ+CjxkdGU6VW5pZGFkTWVkaWRhPlVORDwvZHRlOlVuaWRhZE1lZGlkYT4KICAgICAgICAgICAgPGR0ZTpEZXNjcmlwY2lvbj5QUk9EVUNUTzE8L2R0ZTpEZXNjcmlwY2lvbj4KICAgICAgICAgICAgPGR0ZTpQcmVjaW9Vbml0YXJpbz4xMjA8L2R0ZTpQcmVjaW9Vbml0YXJpbz4KICAgICAgICAgICAgPGR0ZTpQcmVjaW8+MTIwPC9kdGU6UHJlY2lvPgo8ZHRlOkRlc2N1ZW50bz4wPC9kdGU6RGVzY3VlbnRvPgo8ZHRlOkltcHVlc3Rvcz4gICAgICAgICAgICAgIDxkdGU6SW1wdWVzdG8+CiAgICAgICAgICAgICAgICA8ZHRlOk5vbWJyZUNvcnRvPklWQTwvZHRlOk5vbWJyZUNvcnRvPgogICAgICAgICAgICAgICAgPGR0ZTpDb2RpZ29VbmlkYWRHcmF2YWJsZT4xPC9kdGU6Q29kaWdvVW5pZGFkR3JhdmFibGU+CjxkdGU6TW9udG9HcmF2YWJsZT4xMDcuMTQ8L2R0ZTpNb250b0dyYXZhYmxlPgogICAgICAgICAgICAgICAgPGR0ZTpNb250b0ltcHVlc3RvPjEyLjg2PC9kdGU6TW9udG9JbXB1ZXN0bz4KICAgICAgICAgICAgICA8L2R0ZTpJbXB1ZXN0bz4KPC9kdGU6SW1wdWVzdG9zPiAgICAgICAgICAgIDxkdGU6VG90YWw+MTIwPC9kdGU6VG90YWw+CiAgICAgICAgICA8L2R0ZTpJdGVtPgo8L2R0ZTpJdGVtcz4gICAgICAgIDxkdGU6VG90YWxlcz4KPGR0ZTpUb3RhbEltcHVlc3Rvcz48ZHRlOlRvdGFsSW1wdWVzdG8gTm9tYnJlQ29ydG89IklWQSIgVG90YWxNb250b0ltcHVlc3RvPSIxMi44NiI+PC9kdGU6VG90YWxJbXB1ZXN0bz48L2R0ZTpUb3RhbEltcHVlc3Rvcz4JCTxkdGU6R3JhblRvdGFsPjEyMDwvZHRlOkdyYW5Ub3RhbD4KICAgICAgICA8L2R0ZTpUb3RhbGVzPgogICAgICA8L2R0ZTpEYXRvc0VtaXNpb24+CiAgICA8L2R0ZTpEVEU+CiA8ZHRlOkFkZW5kYT4KPENvZGlnb19jbGllbnRlPkMwMTwvQ29kaWdvX2NsaWVudGU+CjxPYnNlcnZhY2lvbmVzPkVTVEEgRVMgVU5BIEFERU5EQTwvT2JzZXJ2YWNpb25lcz4KIDwvZHRlOkFkZW5kYT4gIDwvZHRlOlNBVD4KPC9kdGU6R1REb2N1bWVudG8+";
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

                // Deserealizar respuesta objeto JSON
                RespuestaSolitud respuestaSolitud = new RespuestaSolitud();
                await client.SendAsync(request)
                .ContinueWith(async responseTask =>
                {
                    respuestaSolitud = JsonConvert.DeserializeObject<RespuestaSolitud>(responseTask.Result.Content.ReadAsStringAsync().Result);
                });

                return respuestaSolitud.ToString();
            }
        }
    }
}