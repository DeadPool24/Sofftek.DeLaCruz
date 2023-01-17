using System;
using System.Collections.Generic;
using System.Text;

namespace Sofftek.GestionComercial.Core.Responses
{
    public class Response
    {
        public Response()
        {

        }
        public Response(object result, string message )
        {
            this.Success = false;
            this.Message = message;
            this.Data = result;
        }

        public Response(object result, bool success)
        {
            this.Success = success;
            this.Message = string.Empty;
            this.Data = result;
        }

        public bool Success { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }
        public int IdRetorno { get; set; }

    }
}
