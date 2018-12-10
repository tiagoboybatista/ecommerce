﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeuEcommerce.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewBag.Categorias = new Models.Categoria[]
            {
                new Models.Categoria(1,"Celular"),
                new Models.Categoria(2,"Eletrodosmésticos"),
                new Models.Categoria(3,"Eletrônico"),
                new Models.Categoria(4,"Games"),
                new Models.Categoria(5,"TV"),
            };

            base.OnActionExecuting(filterContext);
        }
    }

    public class HomeController : BaseController
    {
        public ActionResult Index(int? id)
        {
            var model = new Models.HomeIndexViewModel();

            model.Produtos = new Models.Produto[]
            {   /*Celular*/
                new Models.Produto("Iphone", 1, 1,"iphone"),
                /*Eletrodosmésticos*/
                new Models.Produto("Geladeira", 1, 2,"geladeira"),
                new Models.Produto("Batedeira", 1, 2,"batedeira"),
                new Models.Produto("Ar Condicionado", 1, 2,"ar-condicionado"),
                new Models.Produto("Lava & Seca", 1, 2,"lava_seca"),
                /*Eletrônico*/
                new Models.Produto("Home Theater", 1, 3,"homeTheater"),
                /*TV*/
                new Models.Produto("TV Led", 2, 5,"tv"),

                new Models.Produto("Playstation 4", 3, 4,"ps4"),
                new Models.Produto("X-BOX 4", 3, 4,"xbox"),

                new Models.Produto("MacBook Air", 4, 3,"macbook"),
            };

            /*Fazendo um filtro para filtrar a categoria do produto*/
            if (id != null)
            {
                model.Produtos = model.Produtos.Where(p => p.Id_Categoria == id).ToArray();
            }

            return View(model);           
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