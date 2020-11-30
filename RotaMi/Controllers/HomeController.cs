using RotaMi.Interfaces;
using RotaMi.Models;
using RotaMi.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RotaMi.Controllers
{
    public class HomeController : Controller
    {
        List<User> userList = new List<User>();
        IRepository<User> Repository { get; set; }

        public HomeController()
        {
            Repository = new UserTaskRepository();
            GetData();
        }

        public ActionResult Index()
        {
            return View(userList);
        }

        [HttpPost]
        public ActionResult Index(User user)
        {
            GlobalVariables.CurrentUser = userList.Find(x => x.Name == user.Name); 
            return RedirectToAction("Tasks");
        }

        
        public ActionResult Tasks()
        {
            var viewmodel = new TasksViewModel { Users = userList};
            return View(viewmodel);
        }

        public void GetData()
        {
            Repository.ReadData(out userList);
        }

        [HttpPost]
        public ActionResult MarkComplete()
        {
            GlobalVariables.CurrentUser.Task.IsComplete = true;
            userList.Find(x => x.Name == GlobalVariables.CurrentUser.Name).Task.IsComplete = true;
            Repository.WriteData(userList);
            return RedirectToAction("Tasks");
        }
   
    }
}