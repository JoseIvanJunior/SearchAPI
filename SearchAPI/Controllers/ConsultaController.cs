using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        // GET api/consulta
        [HttpGet]
        public string Get()
        {
            string url = Uri.EscapeUriString("https://g1.globo.com/");

            WebClient client = new WebClient();
            string source = client.DownloadString(url);
            string title = Regex.IsMatch(source,
                @"\b/[Cc][Oo][Pp][Aa]",
                RegexOptions.IgnoreCase) ? "True" : "False";

            return JsonConvert.SerializeObject(title);
        }

        // GET api/consulta/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "tasks";
        }

        // POST api/consulta
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/consulta/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/consulta/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
