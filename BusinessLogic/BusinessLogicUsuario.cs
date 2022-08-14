using RapiChallenge.Services;
using RapiChallenge.Entities;

namespace RapiChallenge.BusinessLogic
{
    public class BusinessLogicUsuario : IBusinessLogicUsuario
    {
        private readonly IUsuarioService usuarioService;

        public BusinessLogicUsuario(
            IUsuarioService usuarioService
            )
        {
            this.usuarioService = usuarioService;
        }

        public bool ValidarLogin(string email, string password)
        {
            //TODO-TASK: COMPLETAR LA LOGICA PARA LA VALIDACION DEL LOGUEO
            var usuario = usuarioService.FirstOrDefault(x => x.Email == email && x.Password == password);
            if (usuario != null)
            {
                //User.Identity;
                //var result = await SignInManager.PasswordSignInAsync(email, password, false, false);
                return true;
            }
            return false;
        }
        public string ObtenerRedirect(string email)
        {
            var usuario = usuarioService.FirstOrDefault(x => x.Email == email);
            return email;
        }
    }
}