using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidUtilities.Exceptions
{
    public class ConnectionApiException: Exception
    {
        public string ConnectionError { get; }
        public ConnectionApiException() { }
        public ConnectionApiException(String message) : base(message) {
            this.ConnectionError = message;
        }
        public ConnectionApiException(String message, Exception inner) : base(message, inner) {
            this.ConnectionError = message;
        }
        public ConnectionApiException(String message, int HttpStatusCode) : base(message)
        {
            if (HttpStatusCode == 404)
                this.ConnectionError = "Servicio no encontrado.";
            if (HttpStatusCode == 401)
                this.ConnectionError = "Encabezado no valido";
            else
                this.ConnectionError =  message;
        }
    }
}
