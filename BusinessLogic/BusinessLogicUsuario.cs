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
    public class BusinessLogicUsuario : IBusinessLogicUsuario
    {
        private readonly IUsuarioService usuarioService;
        private readonly IRolService rolService;

        public BusinessLogicUsuario(
            IUsuarioService usuarioService,
            IRolService rolService, 
            IProductoService productoService,
            ICategoriaService categoriaService
            )
        {
            this.usuarioService = usuarioService;
            this.rolService = rolService;
        }

        public bool ValidarLogin(string email, string password)
        {
            //TODO-TASK: COMPLETAR LA LOGICA PARA LA VALIDACION DEL LOGUEO
            var usuario = usuarioService.FirstOrDefault(x => x.Email == email && x.Password == password);
            if (usuario != null)
            {
                Rol rolActual = ObtenerRol(email);
                string userData = rolActual.Nombre;

                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                    email,
                    DateTime.Now,
                    DateTime.Now.AddMinutes(30),
                    false,
                    userData,
                    FormsAuthentication.FormsCookiePath);

                //// Encrypt the ticket.
                string encTicket = FormsAuthentication.Encrypt(ticket);


                //// Create the cookie.
                HttpContext.Current.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

                HttpContext.Current.Session["User"] = email;
                HttpContext.Current.Session["Rol"] = rolActual.Nombre;

                return true;
            }
            return false;
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

        public void Desloguear()
        {
            HttpContext.Current.Session["Rol"] = "";
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

    }
}