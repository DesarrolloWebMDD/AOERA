namespace Infrastructure.CrossCutting.Constants
{
    public static class MessageConst
    {
        public const string RegistroNoEncontrado = "No se encontró el registro.";
        public const string RegistroGuardado = "Se registró correctamente.";
        public const string RegistroActualizado = "Se modificó correctamente.";
        public const string RegistroEliminado = "Se eliminó correctamente.";
        public const string UsuarioIngresadoNoExiste = "El usuario ingresado no existe.";
        public const string UsuarioNoExiste = "El usuario no existe.";
        public const string CredencialesIncorrectas = "Las credenciales son incorrectas.";

        public const string ClienteNoTienePlantilla = "El cliente no tiene tipo planilla asignado";
        public const string MessageErrorTransaction = "Error en la operacion";
    }
}