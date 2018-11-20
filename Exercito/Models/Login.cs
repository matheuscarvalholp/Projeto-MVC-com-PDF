using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exercito.Models
{
    public class Login
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Loginn { get; set; }
        public string Senha { get; set; }
        public string Funcao { get; set; }
        public string Status { get; set; }
    }
}