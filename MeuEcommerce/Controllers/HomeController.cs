using MeuEcommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeuEcommerce.Controllers
{
    public class BaseController : Controller
    {
        static Categoria[] _categorias;
        private Categoria[] GetCategorias()
        {
            if (_categorias == null)
            {
                _categorias = new Models.Categoria[]
                {
                    new Models.Categoria(1,"Celular"),
                    new Models.Categoria(2,"Eletrodosmésticos"),
                    new Models.Categoria(3,"Eletrônico"),
                    new Models.Categoria(4,"Games"),
                    new Models.Categoria(5,"TV"),
                };
            }
            return _categorias;
        }

        protected Carrinho GetCarrinhoDaSessao()
        {
            if (Session["carrinho"] == null)
            {
                Session["carrinho"] = new Carrinho();
            }
            return (Carrinho)Session["carrinho"];
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewBag.Categorias = GetCategorias();
            ViewBag.Carrinho = GetCarrinhoDaSessao();

            base.OnActionExecuting(filterContext);
        }        
    }

    public class HomeController : BaseController
    {
        static Produto[] _produto;
        private Produto[] GetProdutos()
        {
            if (_produto == null)
            {
                _produto = new Models.Produto[]
                {
                    new Models.Produto("Iphone", 01, 1,"iphone"),
                    new Models.Produto("Geladeira", 02, 2,"geladeira"),
                    new Models.Produto("Batedeira", 03, 2,"batedeira"),
                    new Models.Produto("Ar Condicionado", 04, 2,"ar-condicionado"),
                    new Models.Produto("Lava & Seca", 05, 2,"lava_seca"),
                    new Models.Produto("Home Theater", 06, 3,"homeTheater"),
                    new Models.Produto("TV Led", 07, 5,"tv"),
                    new Models.Produto("Playstation 4", 08, 4,"ps4"),
                    new Models.Produto("X-BOX 4", 09, 4,"xbox"),
                    new Models.Produto("MacBook Air", 10, 3,"macbook"),
                };
            }
            return _produto;
        }

        public ActionResult Index(int? id)
        {
            var model = new Models.HomeIndexViewModel();

            model.Produtos = GetProdutos();
            /*Fazendo um filtro categoria do produto*/
            if (id != null)
            {
                model.Produtos = model.Produtos.Where(p => p.Id_Categoria == id).ToArray();
            }            
            return View(model);           
        }

        public ActionResult AddItem(int id)
        {
            var listaProdutos = GetProdutos();

            Produto produto = null;

            foreach (var item in listaProdutos)
            {
                if (item.Id == id)
                {
                    produto = item;
                }
            }
            var carrinho = GetCarrinhoDaSessao();

            carrinho.AddProduto(produto);

            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}