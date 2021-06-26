using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using as2.Models;
using Models;
using System.Text.Json;

namespace as2.Controllers
{
    public class Rookies : Controller
    {
        static List<Person> members = new List<Person>
        {
                new Person()
                {
                    Id = 1,
                    FirstName = "Trang ",
                    LastName = "Nguyen Huyen",
                    Gender = "famela",
                    DateOfBirth = new DateTime(2002,7,14),
                    BirthPlace = "Hai Duong",
                    Age = 19,
                    IsGraduated = false
                },
                new Person()
                {
                    Id = 2,
                    FirstName = "Hoang",
                    LastName = "Nguyen",
                    Gender = "Male",
                    DateOfBirth = new DateTime(2000,1,1),
                    BirthPlace = "Ha Noi",
                    Age = 21,
                    IsGraduated = false
                },
                new Person()
                {
                    Id =3,
                    FirstName = "Hoa",
                    LastName = "Nguyen",
                    Gender = "famela",
                    DateOfBirth = new DateTime(1999,1,1),
                    BirthPlace = "Ha Noi",
                    Age = 22,
                    IsGraduated = false
                },
                new Person(){
                    Id = 4,
                    FirstName = "Vy",
                    LastName = "Tran Thi",
                    Gender = "famela",
                    DateOfBirth = new DateTime(1999,2,12),
                    BirthPlace = "Ha Noi",
                    Age = 22,
                    IsGraduated = false
                },
                new Person(){
                    Id = 5,
                    FirstName = "Son",
                    LastName = "Nguyen Van",
                    Gender = "Male",
                    DateOfBirth = new DateTime(2001,2,12),
                    BirthPlace = "Ha Noi",
                    Age = 20,
                    IsGraduated = false
                },
        };
        private readonly ILogger<HomeController> _logger;

        public Rookies(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // return Json(members);
            return View(members);
        }
         public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
         public IActionResult Create(Person model)
        {
            if (!ModelState.IsValid)
            {
            ViewBag.Data = "Invalid model !!!";
                return View();
            }
            members.Add(model);
           return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            var model = members.FirstOrDefault(m => m.Id == id);
            return View(model);
        }
        [HttpPost]
         public IActionResult Edit(Person model)
        {
            if (!ModelState.IsValid)
            {
            ViewBag.Data = JsonSerializer.Serialize(model);
                return View();
            }
            var list = members.Where(m => m.Id != model.Id).ToList();
            list.Insert(0, model);
            members=list;
        return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            var model = members.FirstOrDefault(m => m.Id == id);
            return View(model);
        }
        [HttpPost, ActionName("Delete")]
         public IActionResult Delete(Person model)
        {
            if (!ModelState.IsValid)
            {
            ViewBag.Data = JsonSerializer.Serialize(model);
                return View();
            }
            var list = members.Where(m => m.Id != model.Id).ToList();
            list.Insert(0, model);
            members=list;
        return RedirectToAction("Index");
        }


       

       
    }
}
