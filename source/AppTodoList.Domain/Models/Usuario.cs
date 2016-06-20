
using System;
namespace AppTodoList.Domain.Models
{
    public class Usuario
    {
        //Para uso do EF
        protected Usuario() { }


        public Usuario(string nome)
        {            
            this.Nome = nome;
        }
        public Usuario(string nome, string email)
        {            
            this.Nome = nome;
            this.Email = email;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return this.Nome;
        }
    }
}
