using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppTodoList.Api.Models
{
    public class TarefaModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int UsuarioId { get; set; }
        public int CategoriaId { get; set; }
        public int Prioridade { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Finalizada { get; set; }

    }
}