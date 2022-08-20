using RapiChallenge.Services;
using System.Web.Security;
using System;
using System.Web;
using System.IO;
using System.Net;
using System.Net.Http;
using RapiChallenge.Entities;
using System.Linq;

namespace RapiChallenge.BusinessLogic
{
    public class BusinessLogicProducto : IBusinessLogicProducto
    {
        private readonly IUsuarioService usuarioService;
        private readonly IRolService rolService;
        private readonly IProductoService productoService;
        private readonly ICategoriaService categoriaService;

        public BusinessLogicProducto(
            IUsuarioService usuarioService,
            IRolService rolService, 
            IProductoService productoService,
            ICategoriaService categoriaService
            )
        {
            this.usuarioService = usuarioService;
            this.rolService = rolService;
            this.productoService = productoService;
            this.categoriaService = categoriaService;
        }

        
        public string ObtenerRedirect(string email)
        {
            var usuario = usuarioService.FirstOrDefault(x => x.Email == email);
            var url = rolService.FirstOrDefault(x => x.Id == usuario.IdRol);
            return url.Redirect;
        }
        public Rol ObtenerRol(string email)
        {
            Usuario usuario = usuarioService.FirstOrDefault(x => x.Email == email);
            Rol rol = rolService.FirstOrDefault(x => x.Id == usuario.IdRol);
            return rol;
        }

        public IQueryable<Producto> ObtenerProductos()
        {
            IQueryable<Producto> productos = productoService.GetAll();
            IQueryable<Categoria> categorias = categoriaService.GetAll();
            foreach (var item in productos)
            {
                Categoria categoria = categorias.FirstOrDefault(x => x.Id == item.IdCategoria);
                item.Categoria = categoria;
            }
            return productos;
        }
        public Producto ObtenerProductoPorId(int id)
        {
            return productoService.GetById(id);
        }
        public Producto CrearProducto(Producto prod)
        {
            Producto producto = productoService.Insert(prod);
            producto.Categoria = categoriaService.FirstOrDefault(x => x.Id == producto.IdCategoria);
            return producto;
        }

        public Producto EditarEstadoPorID(int id)
        {
            Producto producto = productoService.GetById(id);
            producto.Activo = !producto.Activo;
            return productoService.Update(producto);
        }

        public Producto EditarProducto(Producto prod)
        {
            return productoService.Update(prod);
        }

        public IQueryable<Categoria> ObtenerCategorias()
        {
            return categoriaService.GetAll();
        }

        public Categoria ObtenerCategoriaPorId(int id)
        {
            return categoriaService.GetById(id);
        }

        public void EliminarProductoPorId(int id)
        {
            Producto producto = productoService.GetById(id);
            productoService.Delete(producto);
        }

        public IQueryable<Producto> ObtenerProductosFiltradoPorCategoria(int idCategoria)
        {
            IQueryable<Producto> productos = productoService.GetAll();
            productos = from producto in productos
                        where producto.IdCategoria == idCategoria
                        select producto;

            return productos;
        }
    }
}