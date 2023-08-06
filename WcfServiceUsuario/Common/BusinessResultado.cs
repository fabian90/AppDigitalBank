using WcfServiceUsuario.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfServiceUsuario.Data.Implementation;
using WcfServiceUsuario.Dtos;

namespace WcfServiceUsuario.Common
{
    public class BusinessResultado<T>
    {
        public T Result { get; set; }
        public ResultadoOperacion ResultadoOperacion { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
        public bool IsSuccess { get; set; }
        public static BusinessResultado<T> Success(T resultado, string Mensaje)
        {
          
          
            return new BusinessResultado<T>
            {
                Message = Mensaje,
                Result = resultado,
                ResultadoOperacion = ResultadoOperacion.Success,
                IsSuccess = true
            };
        }
        public static BusinessResultado<IEnumerable<T>> Success(IEnumerable<T> resultado, string Mensaje)
        {
            return new BusinessResultado<IEnumerable<T>>
            {
                Message = Mensaje,
                Result = resultado,
                ResultadoOperacion = ResultadoOperacion.Success,
                IsSuccess = true
            };
        }
        public static BusinessResultado<T> OperecionCorrecta(T resultado)
        {
            return new BusinessResultado<T>
            {
                Message = Constants.SUCCESS,
                Result = resultado,
                ResultadoOperacion = ResultadoOperacion.Success,
                IsSuccess = true
            };
        }

        public static BusinessResultado<T> Error(T resultado, string Mensaje, Exception exception)
        {
            var error = string.Empty;

            if (exception != null)
            {
                error = exception.ToString();
            }
            return new BusinessResultado<T>

            {
                Message = Mensaje,
                Result = resultado,
                ResultadoOperacion = ResultadoOperacion.Success,
                Exception = error,
                IsSuccess = false
            };
        }
        public static BusinessResultado<IEnumerable<T>> Error(IEnumerable<T> resultado, string Mensaje, Exception exception)
        {
            var error = string.Empty;

            if (exception != null)
            {
                error = exception.ToString();
            }
            return new BusinessResultado<IEnumerable<T>>

            {
                Message = Mensaje,
                Result = resultado,
                ResultadoOperacion = ResultadoOperacion.Success,
                Exception = error,
                IsSuccess = false
            };
        }
        public static BusinessResultado<T> OperacionError(T resultado, Exception excepciones)
        {
            return new BusinessResultado<T>

            {
                Message = Constants.ERROR,
                Result = resultado,
                Exception = excepciones.ToString(),
                ResultadoOperacion = ResultadoOperacion.Success,
                IsSuccess = false
            };

        }

    }
}
