using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoWebVale.Models;
using ProjetoWebVale.Utils;

namespace ProjetoWebVale.Controllers
{

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return MeuContexto.listaDeValores;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            if (id > MeuContexto.listaDeValores.Count())
                return BadRequest(new Erro("não tem esse valor. presta atenção aí, vacilão"));
            return MeuContexto.listaDeValores[id - 1];
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] string value)
        {
            MeuContexto.listaDeValores.Add(value);
            return Ok(MeuContexto.listaDeValores);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] string value)
        {
            if (id > MeuContexto.listaDeValores.Count())
                return BadRequest(new Erro("não tem esse valor. presta atenção aí, vacilão"));

            MeuContexto.listaDeValores[id - 1] = value;
            return Ok("editado: " + id.ToString());
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id > MeuContexto.listaDeValores.Count())
                return BadRequest(new Erro("presta atenção aí, vacilão"));

            MeuContexto.listaDeValores.Remove(MeuContexto.listaDeValores[id - 1]);
            return Ok("deletado: " + id.ToString());
        }
    }
}
