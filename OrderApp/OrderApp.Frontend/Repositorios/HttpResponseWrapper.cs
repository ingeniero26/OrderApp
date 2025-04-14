using System.Net;
using System.Net.Http;

namespace OrderApp.Frontend.Repositorios
{
    public class HttpResponseWrapper<T>
    {
        public HttpResponseWrapper(T? response, bool error, HttpResponseMessage httpResponseMessage)
        {
            Response = response;
            Error = error;
            HttpResponseMessage = httpResponseMessage;
        }

        public T? Response { get; }
        public bool Error { get; }
        public HttpResponseMessage HttpResponseMessage { get; }

        public async Task<string?> GetErrorMessageAsyn()
        {
            if (!Error)
            {
                return null;
            }
            var statusCode = HttpResponseMessage.StatusCode;
            if (statusCode == HttpStatusCode.NotFound)
            {
                return "No se encontró el recurso.";
            }
            if (statusCode == HttpStatusCode.Unauthorized)
            {
                return "No autorizado.";
            }
            if (statusCode == HttpStatusCode.BadRequest)
            {
                return await HttpResponseMessage.Content.ReadAsStringAsync();
            }
            if (statusCode == HttpStatusCode.BadGateway)
            {
                return "Error de puerta de enlace.";
            }
            if (statusCode == HttpStatusCode.RequestTimeout)
            {
                return "Tiempo de espera de la solicitud agotado.";
            }
            if (statusCode == HttpStatusCode.Forbidden)
            {
                return "Acceso denegado.";
            }
            if (statusCode == HttpStatusCode.InternalServerError)
            {
                return "Error interno del servidor.";
            }
            if (statusCode == HttpStatusCode.BadRequest)
            {
                return "Solicitud incorrecta.";
            }
            if (statusCode == HttpStatusCode.ServiceUnavailable)
            {
                return "Servicio no disponible.";
            }
            if (statusCode == HttpStatusCode.GatewayTimeout)
            {
                return "Tiempo de espera agotado.";
            }
            if (statusCode == HttpStatusCode.TooManyRequests)
            {
                return "Demasiadas solicitudes.";
            }
            if (statusCode == HttpStatusCode.Conflict)
            {
                return "Conflicto en la solicitud.";
            }
            if (statusCode == HttpStatusCode.NotAcceptable)
            {
                return "No aceptable.";
            }
            if (statusCode == HttpStatusCode.UnprocessableEntity)
            {
                return "Entidad no procesable.";
            }
            if (statusCode == HttpStatusCode.ExpectationFailed)
            {
                return "Fallo de expectativa.";
            }
            if (statusCode == HttpStatusCode.LengthRequired)
            {
                return "Longitud requerida.";
            }
            if (statusCode == HttpStatusCode.PreconditionFailed)
            {
                return "Fallo de precondición.";
            }
            if (statusCode == HttpStatusCode.NotImplemented)
            {
                return "No implementado.";
            }
            if (statusCode == HttpStatusCode.UnavailableForLegalReasons)
            {
                return "No disponible por razones legales.";
            }
            if (statusCode == HttpStatusCode.HttpVersionNotSupported)
            {
                return "Versión HTTP no soportada.";
            }
            if (statusCode == HttpStatusCode.MovedPermanently)
            {
                return "Movido permanentemente.";
            }
            if (statusCode == HttpStatusCode.Moved)
            {
                return "Movido.";
            }
            if (statusCode == HttpStatusCode.Redirect)
            {
                return "Redirigido.";
            }
            return "Error desconocido.";
        }
    }
}