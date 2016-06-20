using AppTodoList.Domain.Models;
using System;
using System.Collections.Generic;

namespace AppTodoList.Domain.Contracts.Repositories
{
    public interface ICategoriaRepositorio:IDisposable
    {
        Categoria Obter(int Id);

        List< Categoria> Obter();

        void Criar(Categoria obj);

        void Atualizar(Categoria obj);

        void Apagar(Categoria obj);
    }
}
