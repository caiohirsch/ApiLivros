using ApiLivros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ApiLivros.Controllers
{
    public class LivrosController : ApiController
    {
        BasicAuthenticationAttribute basicAuthentication = new BasicAuthenticationAttribute();

        // GET: api/Livros
        public IEnumerable<Livro> Get()
        {
            
            return RepositorioSimulado.Livros;
        }

        // GET: api/Livros/5
        public IHttpActionResult Get(int id)
        {
            Livro livro = RepositorioSimulado.Livros.FirstOrDefault(l => l.ID == id);

            if (livro != null)
                return ResponseMessage(Request.CreateResponse<Livro>(HttpStatusCode.OK, livro));
            else
                return ResponseMessage(Request.CreateResponse<string>(HttpStatusCode.NotFound, "Livro não localizado."));
        }

        // POST: api/Livros
        public IHttpActionResult Post([FromBody] Livro objeto)
        {
            Livro livro = RepositorioSimulado.Livros.FirstOrDefault(l => l.ID == objeto.ID);

            if (livro != null)
                return ResponseMessage(Request.CreateResponse<string>(HttpStatusCode.Conflict, "Já existe um livro cadastrado com esse ID."));
            else
            {
                RepositorioSimulado.Livros.Add(objeto);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK));
            }
        }

        // PUT: api/Livros/5
        public IHttpActionResult Put([FromBody] Livro objeto)
        {
            Livro livro = RepositorioSimulado.Livros.FirstOrDefault(l => l.ID == objeto.ID);

            if (livro != null)
            {
                livro.Autor = objeto.Autor;
                livro.Titulo = objeto.Titulo;
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK));
            }
            else
                return ResponseMessage(Request.CreateResponse<string>(HttpStatusCode.NotFound, "Livro não localizado para alteração."));
        }

        // DELETE: api/Livros/5
        public IHttpActionResult Delete(int id)
        {
            Livro livro = RepositorioSimulado.Livros.FirstOrDefault(l => l.ID == id);

            if (livro != null)
            {
                RepositorioSimulado.Livros.Remove(livro);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK));
            }
            else
                return ResponseMessage(Request.CreateResponse<string>(HttpStatusCode.NotFound, "Livro não localizado para exclusão."));
        }
    }
}