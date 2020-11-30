using RotaMi.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RotaMi.Models
{
    public class TasksViewModel
    {
        public User CurrentUser { get => GlobalVariables.CurrentUser; }
        public List<User> Users { get; set; }
    }
}