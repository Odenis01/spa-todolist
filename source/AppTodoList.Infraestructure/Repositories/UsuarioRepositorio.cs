using AppTodoList.Domain.Contracts.Repositories;
using AppTodoList.Domain.Models;
using AppTodoList.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppTodoList.Infraestructure.Repositories
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private AppDataContext _context = new AppDataContext();

        public UsuarioRepositorio()
        {
            
        }
        
        public Usuario Obter(int id)
        {
            return _context.Usuarios.Where(x => x.Id == id).FirstOrDefault();
        }
        
        public List<Usuario> Obter()
        {
            return _context.Usuarios.ToList();
        }

        public void Criar(Usuario obj)
        {
            _context.Usuarios.Add(obj);
            _context.SaveChanges();
        }

        public void Atualizar(Usuario obj)
        {
            _context.Entry<Usuario>(obj).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Apagar(Usuario obj)
        {
            _context.Usuarios.Remove(obj);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }


    }
}
