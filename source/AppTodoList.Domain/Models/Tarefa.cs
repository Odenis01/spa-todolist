
using System;
namespace AppTodoList.Domain.Models
{
    public class Tarefa
    {

        protected Tarefa(){}
        public Tarefa(string titulo,string descricao)
        {
            
            this.Titulo = titulo;
            this.Descricao = descricao;
        }
        public Tarefa(string titulo, string descricao, int? categoriaId)
        {
            
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.CategoriaId = categoriaId;
        }
        public Tarefa(string titulo, string descricao, int? categoriaId, int? usuarioId)
        {            
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.CategoriaId = categoriaId;
            this.UsuarioId = usuarioId;
        }
        public int Id { get; set; }
        public TarefaStatus Status { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public byte Prioridade { get; set; }

        public int? CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }

        public int? UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        
        public DateTime DataCriacao { get; set; }
        public override string ToString()
        {
            return Titulo;
        }

        public bool Finalizada { get; set; }

    }
}
