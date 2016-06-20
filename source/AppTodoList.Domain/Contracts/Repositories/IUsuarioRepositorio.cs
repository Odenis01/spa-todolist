using AppTodoList.Domain.Models;
using System;
using System.Collections.Generic;

namespace AppTodoList.Domain.Contracts.Repositories
{
    public interface IUsuarioRepositorio:IDisposable
    {
        Usuario Obter(int id);

        List<Usuario> Obter();

        void Criar(Usuario obj);

        void Atualizar(Usuario obj);

        void Apagar(Usuario obj);

    }
}
