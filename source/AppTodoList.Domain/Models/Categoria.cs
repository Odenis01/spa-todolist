
using System;
namespace AppTodoList.Domain.Models
{
    public class Categoria
    {
        protected Categoria() { }
        public Categoria(string descricao)
        {            
            this.Descricao = descricao;
        }

        public int Id { get; set; }
        public string Descricao { get; set; }

        public override string ToString()
        {
            return this.Descricao;
        }
    }
}
