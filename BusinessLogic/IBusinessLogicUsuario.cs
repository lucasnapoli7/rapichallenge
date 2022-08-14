namespace RapiChallenge.BusinessLogic
{
    public interface IBusinessLogicUsuario
    {
        bool ValidarLogin(string email, string password);
    }
}