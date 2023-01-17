using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sofftek.GestionComercial.Core.DTO.Auth.v1.Request
{
    public class LoginRequest
    {

        /// <summary>
        /// User Property
        /// </summary>
        [Required]
        [DisplayName("user")]
        public string User { get; set; }

        /// <summary>
        /// Password Property
        /// </summary>
        [Required]
        [DisplayName("password")]
        public string Password { get; set; }

    }
}
