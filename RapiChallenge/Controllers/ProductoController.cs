using System.Web.Mvc;

namespace RapiChallenge.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class ProductoController : Controller
    {
        //TODO-TASK: ARMAR LOGICA PARA ABM COMPLETO DE PRODUCTO

        public ActionResult Index()
        {    
            return View();
        }

        //idCategoria: id de la categoria a filtrar
        public ActionResult IndexFiltrado(int idCategoria)
        {
            //TODO-TASK: ARMAR LOGICA PARA MOSTRAR PRODUCTOS DE LA CATEGORIA PASADA POR PARAMETRO

            return View();
        }
    }
}
