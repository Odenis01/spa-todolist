using AppTodoList.Domain.Models;
using System;
using System.Collections.Generic;

namespace AppTodoList.Domain.Contracts.Repositories
{
    public interface ITarefaRepositorio:IDisposable
    {
        Tarefa Obter(int Id);

        List<Tarefa> ObterPorUsuario(int usuarioId);

        List<Tarefa> ObterPorCategoria(int categoriaId);

        List<Tarefa> Obter();

        void Criar(Tarefa obj);

        void Atualizar(Tarefa obj);

        void Apagar(Tarefa obj);
    }
}
