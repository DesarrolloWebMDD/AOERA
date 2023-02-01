namespace Infrastructure.CrossCutting.Constants
{
    public static class HelperConst
    {
        #region Reports

        public const string PathReports = "\\Reports\\";
        public const string NameReportRespuesta = "ComiteActivos";

        public const bool EstadoActivo = true;
        public const bool EstadoInactivo = false;

        public const bool EstadoPagado = true;
        public const bool EstadoNoPagado = false;

        #endregion

        #region Estados de partidos

        public const int Pendiente = 0;
        public const int EventosCreados = 1;
        public const int Iniciado = 2;
        public const int Fenalizado = 3;
        public const int Suspendido = 4;

        #endregion

        #region Manejo de punto

        public const decimal PuntosMembresia = 50;

        #endregion
        #region Tipo de apuestas 

        public const int Local = 1;
        public const int Empate = 3;
        public const int Visita = 2;
        public const int Gol1 = 4;
        public const int Gol2 = 6;
        public const int Gol3 = 7;
        public const int Gol4 = 8;
        public const int Gol_1 = 9;
        public const int Gol_2 = 10;
        public const int Gol_3 = 11;
        public const int Gol_4 = 12;
        public const int LocalEmpate = 13;
        public const int EmpateVisita = 14;
        public const int GolGol = 15;
        public const int NoGol = 16;

        #endregion





    }
}