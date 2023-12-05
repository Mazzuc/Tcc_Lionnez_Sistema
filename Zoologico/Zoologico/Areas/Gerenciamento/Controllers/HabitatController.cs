﻿using Microsoft.AspNetCore.Mvc;
using Zoologico.Areas.Gerenciamento.Models;
using Zoologico.Areas.Gerenciamento.ViewModels;
using Zoologico.DAO;


namespace Zoologico.Controllers
{
    public class HabitatController : Controller
    {
        HabitatDAO ObjHabitat = new HabitatDAO();
        AnimalDAO ObjAnimal = new AnimalDAO();

        public ActionResult Details(int Id)
        {
            var list = ObjAnimal.SelectListHabitat(Id);
            return View(list);
        }
 
        public ActionResult Select()
        {
            var list = ObjHabitat.SelectList();
            return View(list);
        }

        public ActionResult Search(string NomeHabitat)
        {
            var list = ObjHabitat.Search(NomeHabitat);
            return View(list);
        }
        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(CadastroHabitatViewModel vielmodel)
        {
            if (!ModelState.IsValid)
                return View(vielmodel);

            Habitat novoanimal = new Habitat()
            {
                NomeHabitat = vielmodel.NomeHabitat,
                TipoHabitat = vielmodel.TipoHabitat,
                Capacidade = vielmodel.Capacidade,
                Vegetacao = vielmodel.Vegetacao,
                Clima = vielmodel.Clima,
                Solo = vielmodel.Solo
            };
            ObjHabitat.InsertHabitat(novoanimal);

            TempData["MensagemCadastro"] = "Cadastro de " + vielmodel.NomeHabitat + " realizado com sucesso";

            return RedirectToAction("Select");
        }

        [HttpPost]
        public ActionResult Edit(int IdHabitat, string NomeHabitat, int Capacidade, string Vegetacao, string Clima, string Solo)
        {
            if (!ModelState.IsValid)
                return View("select");
   
            ObjHabitat.UpdateHabitat(IdHabitat, NomeHabitat, Capacidade, Vegetacao, Clima, Solo);
            TempData["MensagemCadastro"] = "Cadastro de " + NomeHabitat + " atualizado com sucesso";

            return RedirectToAction("Select");
        }

        public ActionResult Delete(int Id)
        {
            var objHabitat = ObjHabitat.SelectHabitat(Id);
            return View(objHabitat);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmeDelete(int Id)
        {
            ObjHabitat.DeleteHabitat(Id);
            TempData["MensagemCadastro"] = "Cadastro excluído";
            return RedirectToAction("Select");
        }
        public ActionResult Edit(int Id)
        {
            var objHabitat = ObjHabitat.SelectHabitat(Id);

            return View(objHabitat);
        }
       
        public ActionResult ValidaHabitat(string NomeHabitat)
        {
            bool HabitatExists;
            string habitat = ObjHabitat.ValidaHabitat(NomeHabitat);

            if (habitat.Length == 0)
                HabitatExists = false;
            else
                HabitatExists = true;

            return Json(!HabitatExists, new System.Text.Json.JsonSerializerOptions());
        }
    }
}
