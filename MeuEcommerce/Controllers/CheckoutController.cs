using MeuEcommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeuEcommerce.Controllers
{
    public class CheckoutController : BaseController
    {
        // GET: Checkout
        public ActionResult Index()
        {
            var model = new CheckoutIndexViewModel();
            model.Carrinho = GetCarrinhoDaSessao();

                      
            return View(model);
        }

        public ActionResult Incrementa(int id)
        {
            Carrinho carrinho = GetCarrinhoDaSessao();

            CarrinhoItem item  = carrinho.Itens[id];
            item.Quantidade++;

            return Redirect("Index");

        }

        public ActionResult Decrementa(int id)
        {
            Carrinho carrinho = GetCarrinhoDaSessao();

            CarrinhoItem item = carrinho.Itens[id];
            item.Quantidade--;

            return Redirect("Index");
        }

        public ActionResult Remove(int id)
        {
            Carrinho carrinho = GetCarrinhoDaSessao();

            carrinho.Itens.Remove(id);

            return Redirect("Index");
        }
    }
}