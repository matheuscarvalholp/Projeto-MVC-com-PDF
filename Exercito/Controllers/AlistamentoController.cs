using Exercito.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Exercito.Controllers
{
    public class AlistamentoController : Controller
    {
        Dao dao = new Dao();
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoginAlistamento()
        {
            return View();
        }
        public ActionResult InserirLogin()
        {
            return View();
        }
        public void CadastrarLogin(string Usuario, string Login, string Senha, string Funcao)
        {
            string criptografada = gerandoSHA1(Senha);
            dao.InserirLogin(Usuario, Login, criptografada, Funcao);
 
        }
        public static string gerandoSHA1(string texto)
        {
            
            try
            {
                byte[] buffer = Encoding.Default.GetBytes(texto);
                System.Security.Cryptography.SHA1CryptoServiceProvider cryptoTransformSHA1 = new System.Security.Cryptography.SHA1CryptoServiceProvider();
                string hash = BitConverter.ToString(cryptoTransformSHA1.ComputeHash(buffer)).Replace("-", "");
                return hash;
            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }
        }
        public ActionResult Loading(int id)
        {
            ViewBag.Id = id;
            return View();
        }
        public JsonResult VerificaUsuario(string Login, string SenhaLogin)
        {
            string criptografada = gerandoSHA1(SenhaLogin);
            var lista = dao.RetornarLogin(Login, criptografada,0);
            return Json(lista, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Download(int id)
        {
            var lista = dao.RetornarLogin("","",id);
            return View(lista);
            
            
        }
      
    }
}