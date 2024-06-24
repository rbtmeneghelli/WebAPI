﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebAPI.Domain.Models
{
    public sealed class LoginUser
    {   
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Login { get; set; }

        [Required(ErrorMessage = "O campo Password é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo Password precisa ter entre {2} e {1} caracteres", MinimumLength = 4)]
        public string Password { get; set; }
    }

    public sealed class ConfirmLoginUser
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string CodeTwoFactory { get; set; }
    }
}
