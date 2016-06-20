using AppTodoList.Domain.Contracts.Repositories;
using AppTodoList.Domain.Models;
using AppTodoList.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppTodoList.Infraestructure.Repositories
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private AppDataContext _context = new AppDataContext();

        public CategoriaRepositorio()
        {            
        }

        public Categoria Obter(int id)
        {
            return _context.Categorias.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Categoria> Obter()
        {
            return _context.Categorias.ToList();
        }

        public void Criar(Categoria obj)
        {
            _context.Categorias.Add(obj);
            _context.SaveChanges();
        }

        public void Atualizar(Categoria obj)
        {
            _context.Entry<Categoria>(obj).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Apagar(Categoria obj)
        {
            _context.Categorias.Remove(obj);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
