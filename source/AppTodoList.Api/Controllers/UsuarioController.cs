using AppTodoList.Api.Attributes;
using AppTodoList.Api.Models;
using AppTodoList.Domain.Models;
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
    [RoutePrefix("api/usuarios")]
    public class UsuarioController : ApiController
    {
        UsuarioRepositorio _service = new UsuarioRepositorio();
        TarefaRepositorio _serviceTarefa = new TarefaRepositorio();

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
        public Task<HttpResponseMessage> Post(UsuarioModel model)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                _service.Criar(new Usuario(model.Nome, model.Email));
                response = Request.CreateResponse(HttpStatusCode.OK, new { nome = model.Nome, email = model.Email });
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
        public Task<HttpResponseMessage> Put(UsuarioModel model)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var usuario = _service.Obter(model.Id);
                usuario.Email = model.Email;
                usuario.Nome = model.Nome;

                _service.Atualizar(usuario);
                response = Request.CreateResponse(HttpStatusCode.OK, new { nome = model.Nome, email = model.Email });
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        [HttpDelete]
        [Route("")]
        public HttpResponseMessage Delete(int usuarioId)
        {
            if (usuarioId <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                var tarefa = _service.Obter(usuarioId);
                _service.Apagar(tarefa);

                return Request.CreateResponse(HttpStatusCode.OK, "Usuário excluido");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao excluir usuário");
            }
        }
        
        protected override void Dispose(bool disposing)
        {
            _service.Dispose();
        }
    }
}
