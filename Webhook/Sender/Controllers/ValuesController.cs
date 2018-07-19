using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web.Http;

namespace Sender.Controllers
{
    public class ValuesController : ApiController
    {
        //[Authorize]
        // GET api/values
        public async Task<IHttpActionResult> Get()
        {
            System.Threading.Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity("test"), new String[] { });
            
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("/api/webhooks/registrations");
                request.Method = "POST";
                request.ContentType = "application/json; charset=utf-8";

                var data = new
                {
                    WebHookUri = "http://localhost:50028/api/webhooks/incoming/custom",
                    Secret = "12345678901234567890123456789012",
                    Description = "My first WebHook!"
                };

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(data);
                    streamWriter.Flush();                    
                }

                using (var response = request.GetResponse())
                {
                    using (var steamReader = new StreamReader(response.GetResponseStream()))
                    {
                        var responseText = steamReader.ReadToEnd();
                    }
                }
            }
            catch(WebException ex)
            {

            }
            await this.NotifyAsync("eventwe", new { P1 = "p1" });
            return Ok(new string[] { "value1", "value2" });
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
