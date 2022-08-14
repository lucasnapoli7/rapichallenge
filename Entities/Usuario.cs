using System.ComponentModel.DataAnnotations.Schema;

namespace RapiChallenge.Entities
{
    public class Usuario
    {       
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        //TODO-TASK: AGREGAR PROPIEDADES Y FK NECESARIAS (RECORDAR HACER UPDATE-DATABASE)

        public int IdRol { get; set; }
        [ForeignKey("IdRol")]
        public Rol Rol { get; set; }
    }
}