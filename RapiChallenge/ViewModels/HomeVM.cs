using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RapiChallenge.ViewModels.Home
{
    public class HomeLoginVM
    {
        //TODO-TASK: AGREGAR DECORADOS PARA VALIDACIONES DE LOGIN
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Contraseña")]
        [StringLength(100, ErrorMessage = "{0} debe tener mínimo {2} carácteres.", MinimumLength = 5)]
        [RegularExpression(@"[a-zA-Z0-9]{5,100}", ErrorMessage = "{0} debe ser alfanumerico")]
        public string Password { get; set; }
    }
}