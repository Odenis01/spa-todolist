using AppTodoList.Api.Attributes;
using AppTodoList.Api.Models;
using AppTodoList.Domain.Models;
using AppTodoList.Infraestructure.Data;
using AppTodoList.Infraestructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AppTodoList.Api.Controllers
{
    [RoutePrefix("api/categorias")]
    public class CategoriaController : ApiController
    {
        CategoriaRepositorio _service = new CategoriaRepositorio();

        [HttpGet]
        [Route("")]
        [DeflateCompression]        
        public Task<HttpResponseMessage> Get()
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var result = _service.Obter();
                response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
                catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        [HttpPost]
        [Route("")]
        public Task<HttpResponseMessage> Post(CategoriaModel model)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var cat = new Categoria(model.Descricao);
                _service.Criar(cat);
                response = Request.CreateResponse(HttpStatusCode.OK, new {id = cat.Id, descricao = model.Descricao});
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        [HttpPut]
        [Route("")]
        public Task<HttpResponseMessage> Put(CategoriaModel model)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var cat = _service.Obter(model.Id);
                cat.Descricao = model.Descricao;

                _service.Atualizar(cat);

                response = Request.CreateResponse(HttpStatusCode.OK, new { id = cat.Id, descricao = model.Descricao });
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        protected override void Dispose(bool disposing)
        {
            _service.Dispose();
        }
    }
}
