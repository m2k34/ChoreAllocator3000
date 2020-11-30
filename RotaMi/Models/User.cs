using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RotaMi.Models
{
    public class User
    {
        public string Name { get; set; }

        public UserTask Task { get; set; }

        public DateTime TimeStamp { get; set; }

    }
}