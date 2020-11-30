using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RotaMi.Models
{
    public class UserTask
    {
        public string Name { get; set; }

        public int TaskId { get; set; }

        public bool IsComplete { get; set; }
    }
}