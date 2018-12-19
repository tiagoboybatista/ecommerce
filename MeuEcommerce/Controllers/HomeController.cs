﻿using MeuEcommerce.DAL;
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
        protected Database _dal = new Database();

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
            ViewBag.Categorias = _dal.Categorias.ToArray();
            ViewBag.Carrinho = GetCarrinhoDaSessao();

            base.OnActionExecuting(filterContext);
        }        
    }

    public class HomeController : BaseController
    {
        static Produto[] _produto;

        public ActionResult Index(int? id)
        {
            var model = new Models.HomeIndexViewModel();

            model.Produtos = _dal.Produtos.ToArray();
            /*Fazendo um filtro categoria do produto*/
            if (id != null)
            {
                model.Produtos = model.Produtos.Where(p => p.CategoriaId == id).ToArray();
            }            
            return View(model);           
        }

        public ActionResult AddItem(int id)
        {
            var listaProdutos = _dal.Produtos.ToArray();

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