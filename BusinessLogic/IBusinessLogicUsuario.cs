using RapiChallenge.Entities;
using System.Linq;

namespace RapiChallenge.BusinessLogic
{
    public interface IBusinessLogicUsuario
    {
        bool ValidarLogin(string email, string password);
        string ObtenerRedirect(string email);
        Rol ObtenerRol(string email);
        void Desloguear();
    }
}