using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeuEcommerce.Models
{
    public class Carrinho
    {
        private Dictionary<int, CarrinhoItem> Itens;

        public Carrinho()
        {
            Itens = new Dictionary<int, CarrinhoItem>();
        }

        public void Add(Produto produto)
        {
            /*verificar se já existe um item igual no meu carrinho*/
            if (Itens.ContainsKey(produto.Id))
            {
                Itens[produto.Id].Quantidade++;
            }
            else
            {
                var carrinhoItem = new CarrinhoItem(produto.Id, produto.Nome, produto.Preco);

                Itens.Add(produto.Id, carrinhoItem);
            }
        }
    }

    public class CarrinhoItem
    {
        public int Id_Produto { get; set; }        
        public string Nome { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; }

        public CarrinhoItem(int id_produto, string nome, decimal precoUnitario)
        {
            Id_Produto = id_produto;
            Nome = nome;
            Quantidade = 1;
            PrecoUnitario = precoUnitario;
        }

        public decimal PrecoTotal
            => PrecoUnitario * Quantidade;
    }
}