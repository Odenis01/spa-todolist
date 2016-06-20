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
    public class TarefaController : ApiController
    {
        TarefaRepositorio _service = new TarefaRepositorio();

        [HttpGet]
        [Route("api/tarefas")]
        [DeflateCompression]
        public Task<HttpResponseMessage> GetTarefas()
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

        [HttpGet]
        [Route("api/tarefas/afazer")]
        [DeflateCompression]
        public Task<HttpResponseMessage> GetTarefasAfazer()
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var result = _service.Obter().Where(w => !w.Finalizada);
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

        [HttpGet]
        [Route("api/tarefas/feitos")]
        [DeflateCompression]
        public Task<HttpResponseMessage> GetTarefasFeitos()
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var result = _service.Obter().Where(w=> w.Finalizada);
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

        [HttpGet]
        [Route("api/tarefas/{id}")]
        [DeflateCompression]
        public Task<HttpResponseMessage> GetTarefas(int id)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {


                if (id < 0)
                {
                    response = Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                else
                {
                    var result = _service.Obter(id);
                    response = Request.CreateResponse(HttpStatusCode.OK, result);
                }
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
        [Route("api/tarefas")]
        public Task<HttpResponseMessage> Post(TarefaModel model)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                int? catId = null;
                int? usId = null;

                if (model.CategoriaId > 0)
                    catId = model.CategoriaId;

                if (model.UsuarioId > 0)
                    usId = model.UsuarioId;

                var tr = new Tarefa(model.Titulo, model.Descricao, catId, usId);
                _service.Criar(tr);

                var tarefa = _service.Obter(tr.Id);
                response = Request.CreateResponse(HttpStatusCode.OK, new { id = tr.Id, titulo = tr.Titulo, descricao = tr.Descricao, categoria = tarefa.Categoria, usuario = tarefa.Usuario });
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
        [Route("api/tarefas")]
        public HttpResponseMessage Put(TarefaModel model)
        {
            if (model == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                int? catId = null;
                int? usId = null;

                if (model.CategoriaId > 0)
                    catId = model.CategoriaId;

                if (model.UsuarioId > 0)
                    usId = model.UsuarioId;

                var tarefa = _service.Obter(model.Id);
                tarefa.UsuarioId = catId;
                tarefa.CategoriaId = usId;
                tarefa.Titulo = model.Titulo;
                tarefa.Descricao = model.Descricao;
                tarefa.Finalizada = model.Finalizada;

                _service.Atualizar(tarefa);

                var result = model;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar tarefa");
            }
        }


        [HttpDelete]
        [Route("api/tarefas")]
        public HttpResponseMessage Delete(int tarefaId)
        {
            if (tarefaId <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                var tarefa = _service.Obter(tarefaId);
                _service.Apagar(tarefa);

                return Request.CreateResponse(HttpStatusCode.OK, "Tarefa excluida");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao excluir tarefa");
            }
        }
    }
}
