﻿using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Zoologico.Models;
using Zoologico.ViewModels;
using Microsoft.Owin.Host.SystemWeb;
using Zoologico.Areas.Gerenciamento.Models;
using Zoologico.Areas.Gerenciamento.ViewModels;
using Zoologico.DAO;

namespace Zoologico.Controllers
{
    public class HomeController : Controller
    {
        Usuario ObjLogin = new Usuario();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ValidaLogin(string vLogin)
        {
            bool UsuarioExists;
            string usuario = ObjLogin.ValidaLogin(vLogin);

            if (usuario.Length == 0)
                UsuarioExists = false;
            else
                UsuarioExists = true;

            return Json(!UsuarioExists, new System.Text.Json.JsonSerializerOptions());
        }

        public ActionResult ValidaSenha(string vSenha)
        {
            bool UsuarioExists;
            string senha = ObjLogin.ValidaSenha(vSenha);

            if (senha.Length == 0)
                UsuarioExists = false;
            else
                UsuarioExists = true;

            return Json(!UsuarioExists, new System.Text.Json.JsonSerializerOptions());
        }
    }
}