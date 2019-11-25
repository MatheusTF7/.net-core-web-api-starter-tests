using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoWebVale.Models;

namespace ProjetoWebVale.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValoresController : ControllerBase
    {
        public ValoresController()
        {
        }

        // GET api/valores
        [HttpGet("")]
        public ActionResult<IEnumerable<string>> Getstrings()
        {
            return new List<string> { };
        }

        // GET api/valores/5
        [HttpGet("{id}")]
        public ActionResult<string> GetstringById(int id)
        {
            return null;
        }

        // POST api/valores
        [HttpPost("")]
        public void Poststring(string value)
        {
        }

        // PUT api/valores/5
        [HttpPut("{id}")]
        public void Putstring(int id, string value)
        {
        }

        // DELETE api/valores/5
        [HttpDelete("{id}")]
        public void DeletestringById(int id)
        {
        }
    }
}