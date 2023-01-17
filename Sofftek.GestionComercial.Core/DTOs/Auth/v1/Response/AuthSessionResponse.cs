using System;
using System.Collections.Generic;
using System.Text;

namespace Sofftek.GestionComercial.Core.DTOs.Auth.v1.Response
{
    public class AuthSessionResponse
    {
        public int IdUsuario { get; set; }
        public int IdRol { get; set; }
        public int IdArea { get; set; }
        public string token { get; set; }
        public string Usuario { get; set; }
    }
}
