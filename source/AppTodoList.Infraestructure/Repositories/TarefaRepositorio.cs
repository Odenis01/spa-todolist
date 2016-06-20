using AppTodoList.Domain.Contracts.Repositories;
using AppTodoList.Domain.Models;
using AppTodoList.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppTodoList.Infraestructure.Repositories
{
    public class TarefaRepositorio : ITarefaRepositorio
    {
        private AppDataContext _context = new AppDataContext();

        public TarefaRepositorio()
        {

        }
        public Tarefa Obter(int id)
        {
            var re = _context.Tarefas
                .Include("Categoria")
                .Include("Usuario")
                .Where(w => w.Id == id);



            return re.FirstOrDefault();
        }

        public List<Tarefa> Obter()
        {
            return _context.Tarefas.Include("Categoria").Include("Usuario").OrderBy(o=>o.Prioridade).ToList();
        }

        public List<Tarefa> ObterPorUsuario(int usuarioId)
        {
            return _context.Tarefas.Include("Usuario").ToList();
        }

        public List<Tarefa> ObterPorCategoria(int categoriaId)
        {
            return _context.Tarefas.Include("Categoria").ToList();
        }

        public void Criar(Tarefa obj)
        {
            if (obj.DataCriacao == default(DateTime))
                obj.DataCriacao = DateTime.Now;

            _context.Tarefas.Add(obj);
            _context.SaveChanges();
        }

        public void Atualizar(Tarefa obj)
        {
            _context.Entry<Tarefa>(obj).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Apagar(Tarefa obj)
        {
            _context.Tarefas.Remove(obj);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
