using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofftek.GestionComercial.Core.DTO.Auth.v1.Response
{
    public class AuthenticationDto
    {

        /// <summary>
        /// Access Token property
        /// </summary>        
        public string AccessToken { get; set; }

        /// <summary>
        /// Expired Date in format ISO yyyy-MM-ddThh:mm:ss
        /// </summary>
        /// <example>
        /// <code>
        /// string date = DateTime.Now.ToString("s");
        /// </code>
        /// </example>
        public string ExpiredDate { get; set; }

        public string RefreshToken { get; set; }

    }
}
