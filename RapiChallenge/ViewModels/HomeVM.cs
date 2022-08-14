using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RapiChallenge.ViewModels.Home
{
    public class HomeLoginVM
    {
        //TODO-TASK: AGREGAR DECORADOS PARA VALIDACIONES DE LOGIN

        public string Email { get; set; }
        public string Password { get; set; }
    }
}