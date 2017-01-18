using DocAppBackendWithAuth.Logic;
using DocAppBackendWithAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DocAppBackendWithAuth.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "DocApp";

            return View();
        }

        public ActionResult ManageSystem()
        {
            ViewBag.Title = "ManageSystem";

            return View();
        }

        public ActionResult ManageDepartament(int? id)
        {
            string name = "";
            if (id.HasValue)
            {
                ViewBag.Title = "Редактирование системы";
                name = new NeuralLogic().getDepartaments(id).First().name;
            }
            else
            {
                ViewBag.Title = "Создание системы";
            }

           

            return View(new UniversalViewModel {
                id = id,
                name = name
            });
        }

        public ActionResult ManageGroup(int? id)
        {
            string name = "";
            if (id.HasValue)
            {
                ViewBag.Title = "Редактирование группы";
                name = new NeuralLogic().getGroups(id).First().name;
            }
            else
            {
                ViewBag.Title = "Создание группы";
            }

            return View(new UniversalViewModel
            {
                id = id,
                name = name
            });
        }

        public ActionResult ManageDiagnos(int? id)
        {
            string name = "";
            if (id.HasValue)
            {
                ViewBag.Title = "Редактирование диагноза";
                name = new NeuralLogic().getDiagnoses(id).First().name;
            }
            else
            {
                ViewBag.Title = "Создание диагноза";
            }



            return View(new UniversalViewModel
            {
                id = id,
                name = name
            });
        }

        public ActionResult Study(int id)
        {
            string name = "";
            ViewBag.Title = "Обучение диагноза";
            
            name = new NeuralLogic().getDiagnoses(id).First().name;

            return View(new UniversalViewModel
            {
                id = id,
                name = name
            });
        }

        public ActionResult UserDiagnos()
        {
            ViewBag.Title = "Постановка диагноза";
            return View();
        }
    }
}
