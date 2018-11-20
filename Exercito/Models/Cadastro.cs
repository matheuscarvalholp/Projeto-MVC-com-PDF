using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exercito.Models
{
    public class Cadastro
    {
        public int Id { get; set; }
        public int Id_Usuario { get; set; }
        public byte[] Pdf { get; set; }  //Array[]//
        public string Status { get; set; }
    }
}