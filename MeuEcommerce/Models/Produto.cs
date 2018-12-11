using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeuEcommerce.Models
{
    public class Produto
    {
        static Random _random = new Random();

        public int Id { get; set; }
        public int Id_Categoria { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string Imagem { get; set; }

        /*Construtor*/
        public Produto(string nome, int id, int id_categoria, string imagem)
        {
            Id = id;
            Id_Categoria = id_categoria;
            Nome = nome;
            Descricao = "Descrição de " + Nome;
            Preco = _random.Next(10, 100) + (decimal)_random.NextDouble();
            Imagem = "/img/Produtos/" + imagem + ".png";
        }
    }
}