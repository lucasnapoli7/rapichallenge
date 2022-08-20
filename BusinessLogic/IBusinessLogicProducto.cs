using RapiChallenge.Entities;
using System.Linq;

namespace RapiChallenge.BusinessLogic
{
    public interface IBusinessLogicProducto
    {
        string ObtenerRedirect(string email);
        Rol ObtenerRol(string email);
        IQueryable<Producto> ObtenerProductos();
        Producto EditarEstadoPorID(int id);
        IQueryable<Categoria> ObtenerCategorias();
        Producto CrearProducto(Producto prod);
        Producto ObtenerProductoPorId(int id);
        Producto EditarProducto(Producto prod);
        void EliminarProductoPorId(int id);
        IQueryable<Producto> ObtenerProductosFiltradoPorCategoria(int idCategoria);
        Categoria ObtenerCategoriaPorId(int id);
    }
}