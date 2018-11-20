using Exercito.Models;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exercito.Controllers
{
    public class ArquivoController : Controller
    {
        Dao dao = new Dao();
        public ActionResult SalvarArquivo(HttpPostedFileBase arquivo, int id)
        {
            byte[] data;
            using (Stream inputStream = arquivo.InputStream)
            {
                MemoryStream memoryStream = arquivo.InputStream as MemoryStream;
                if (memoryStream == null)
                {
                    memoryStream = new MemoryStream();
                    inputStream.CopyTo(memoryStream);
                }
                data = memoryStream.ToArray();
                dao.InserirArquivo(id, data, "P");
            }
            return RedirectToAction("Download/" + id + "", "Alistamento");
        }
        //public void InserirArquivo(string nome, byte[]arquivo)
        public FileResult MostrarPdf(int Id)
        {
            var lista = dao.retornarArquivo(Id).First();
            MemoryStream ms = new MemoryStream(lista.Pdf);
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=labtest.pdf");
            Response.Buffer = true;
            ms.WriteTo(Response.OutputStream);
            Response.End();
            return new FileStreamResult(ms, "application/pdf");
        }
        public ActionResult Atualizar(int id)
        {
            var lista = dao.retornarArquivo(id);
            return View(lista[0]);
        }
        public ActionResult Edita(int id, string status)
        {
            dao.UpdateCadastro(id,status);
            return RedirectToAction("Download/"+4+"","Alistamento");
        }
    }

}