using RapiChallenge.BusinessLogic;
using RapiChallenge.Entities;
using RapiChallenge.Filter;
using RapiChallenge.Services;
using RapiChallenge.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace RapiChallenge.Controllers
{
    [AuthorizeUser(Roles:"Administrador")]
    public class ProductoController : Controller
    {
        private readonly IBusinessLogicProducto businessLogicProducto;
        private readonly IProductoService productoService;
        private readonly ICategoriaService categoriaService;
        public ProductoController(
            IBusinessLogicProducto businessLogicProducto,
            IProductoService productoService,
            ICategoriaService categoriaService
            )
        {
            this.businessLogicProducto = businessLogicProducto;
            this.productoService = productoService;
            this.categoriaService = categoriaService;
        }
        public ActionResult Index()
        {    
            return View();
        }
        [HttpGet]
        public JsonResult GetAll()
        {
            return Json(new { data = businessLogicProducto.ObtenerProductos().ToList() }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EditarEstadoPorID(ProductoVM prod)
        {
            return Json(new { producto = businessLogicProducto.EditarEstadoPorID(prod.id) }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult ObtenerCategorias()
        {
            return Json(new { categorias = businessLogicProducto.ObtenerCategorias() }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CrearProducto(Producto prod)
        {
            
            return Json(new { producto = businessLogicProducto.CrearProducto(prod) }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ObtenerProductoPorId(int id)
        {
            return Json(new { data = businessLogicProducto.ObtenerProductoPorId(id) }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EditarProducto(Producto prod)
        {
            return Json(new { producto = businessLogicProducto.EditarProducto(prod) }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarProducto(ProductoVM prod)
        {
            businessLogicProducto.EliminarProductoPorId(prod.id);
            return Json(new { Resultado = "OK" }, JsonRequestBehavior.AllowGet);
        }

        //id: id de la categoria a filtrar
        public ActionResult IndexFiltrado(int? id)
        {
            ViewBag.ID = id;
            return View();

        }

        [HttpGet]
        public JsonResult ObtenerProductosFiltradoPorCategoria(int id)
        {
            return Json(new { productos = businessLogicProducto.ObtenerProductosFiltradoPorCategoria(id) }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ObtenerCategoriaPorId(int id)
        {
            return Json(new { categoria = businessLogicProducto.ObtenerCategoriaPorId(id) }, JsonRequestBehavior.AllowGet);
        }
    }
}
