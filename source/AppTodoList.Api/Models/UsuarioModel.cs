using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppTodoList.Api.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}