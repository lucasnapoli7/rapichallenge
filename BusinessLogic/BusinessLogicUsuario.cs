using RapiChallenge.Services;

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

            return false;
        }
    }
}