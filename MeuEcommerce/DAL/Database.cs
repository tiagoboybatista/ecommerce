using System;
using System.Collections.Generic;
using MeuEcommerce.Models;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MeuEcommerce.DAL
{
    public class Database : DbContext
    {
        public IDbSet<Produto> Produtos { get; set; }
        public IDbSet<Categoria> Categorias { get; set; }

        public IDbSet<Compra> Compra { get; set; }
        public IDbSet<Compras_Item> Compras_Item { get; set; }

        static private string GetConnectionString()
        {

            return @"Data Source=.\SQLEXPRESS01;Initial Catalog=MeuEcommerce; Integrated Security=true;";
        }

        public Database() : base(GetConnectionString())
        {
            GetConnectionString();
        }
    }
}