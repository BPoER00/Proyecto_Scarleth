
namespace app.helpers
{
    public struct ErrorHelperMessage
    {
        public const string DEFAULT_VALUE = "0";
        public const int NOT_FOUND = 1;
        public const int OBLIGATORIO = 2;
        public const int MAXIMO = 3;
        public const int MINIMO = 4;
        public const int INVALIDO = 5;
        public const int GUARDADO = 6;
        public const int NO_GUARDADO = 7;
        public const int OBTENIDO = 8;
        public const int REPETIDO = 9;

        public const String campoRequired = "El Campo es obligatorio";
        public const String campoLenght = "El campo tiene un maximo de";

        public String ErrorMessages(string campo, string caracteres, int tipo)
        {
            string mensaje;

            switch (tipo)
            {
                case NOT_FOUND:
                    mensaje = $"El Campo {campo}, no existe en la base de datos";
                    break;

                case OBLIGATORIO:
                    mensaje = $"El Campo {campo}, es requerido";
                    break;

                case MAXIMO:
                    mensaje = $"El Campo {campo}, tiene un máximo de {caracteres} caracteres";
                    break;

                case MINIMO:
                    mensaje = $"El Campo {campo}, tiene un mínimo de {caracteres} caracteres";
                    break;

                case INVALIDO:
                    mensaje = "Campo Invalido";
                    break;

                case GUARDADO:
                    mensaje = "Datos Guardados Correctamente";
                    break;

                case NO_GUARDADO:
                    mensaje = "Error Al Guardar Los Datos";
                    break;

                case OBTENIDO:
                    mensaje = "Datos Obtenidos Correctamente";
                    break;
                
                case REPETIDO:
                    mensaje = $"El Campo {campo}, Ya Existe En La Base De Datos";
                    break;

                default:
                    mensaje = "Tipo de error no válido";
                    break;
            }

            return mensaje;
        }

    }
}