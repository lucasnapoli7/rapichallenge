using RapiChallenge.BusinessLogic;
using RapiChallenge.Services;
using RapiChallenge.ViewModels.Home;
using System.Linq;
using System.Web.Mvc;

namespace RapiChallenge.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBusinessLogicUsuario businessLogicUsuario;
        private readonly IUsuarioService usuarioService;

        public HomeController(IBusinessLogicUsuario businessLogicUsuario,
            IUsuarioService usuarioService)
        {
            this.businessLogicUsuario = businessLogicUsuario;
            this.usuarioService = usuarioService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost] //POR AJAX
        public JsonResult ValidarLogin(HomeLoginVM model)
        {
            //TODO-TASK: COMPLETAR LA LOGICA LLAMANDO A LA CAPA BUSINESS DE USUARIO PARA LA VALIDACION DEL LOGUEO Y REALIZAR EL REDIRECT DE SER EXITOSO

            //DEVUELVE VERDADERO SI EL USUARIO ESTÁ EN LA BASE DE DATOS
            if (businessLogicUsuario.ValidarLogin(model.Email, model.Password))
            {
                Redirect(model);
                return Json(new { Resultado = true });
            }
            
            return Json(new { Resultado = false });
        }

        public ActionResult Redirect(HomeLoginVM model)
        {
            var url = businessLogicUsuario.ObtenerRedirect(model.Email);
            //return View(businessLogicUsuario.ObtenerRedirect(model.Email));
            //return View("/Producto");
            return RedirectToAction("Index", "Producto");
        }

        public ActionResult TestUsuarios()
        {
            return Content(string.Join("<br>", usuarioService.GetAll().Select(c => c.Email)), "text/html");
        }
    }
}