using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeuEcommerce.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        /*Construtor*/
        public Categoria(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}