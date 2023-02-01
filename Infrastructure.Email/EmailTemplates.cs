using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;
using System;
using System.IO;

namespace Infrastructure.Email
{
    public static class EmailTemplates
    {
        static IWebHostEnvironment _hostingEnvironment;
        static string pathReunionTemplates = @"PlantillasCorreo\Reunion";
        static string reunionPresencialAgendadaTemplate;
        static string reunionVirtualAgendadaTemplate;
        static string reunionCredencialesTemplate;

        public static void Initialize(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public static string getReunionPresencialAgendadaTemplate(string fotoSecretario,string usuarioCreacion, string tituloReunion, string tituloComite, string urlInvitacion)
        {
            if (reunionPresencialAgendadaTemplate == null)
                reunionPresencialAgendadaTemplate = ReadPhysicalFile(@$"{pathReunionTemplates}\PlantillaReunionPresencial.html");

            string emailMessage = reunionPresencialAgendadaTemplate
                .Replace("{fotoSecretario}", fotoSecretario)
                .Replace("{usuarioCreacion}", usuarioCreacion)
                .Replace("{tituloReunion}", tituloReunion)
                .Replace("{tituloComite}", tituloComite)
                .Replace("{urlInvitacion}", urlInvitacion);

            return emailMessage;
        }

        public static string getReunionVirtualTemplate(string fotoSecretario,string usuarioCreacion, string tituloReunion, string urlMisReuniones)
        {
            if (reunionVirtualAgendadaTemplate == null)
                reunionVirtualAgendadaTemplate = ReadPhysicalFile(@$"{pathReunionTemplates}\PlantillaReunionVirtual.html");

            string emailMessage = reunionVirtualAgendadaTemplate
                .Replace("{fotoSecretario}", fotoSecretario)
                .Replace("{usuarioCreacion}", usuarioCreacion)
                .Replace("{tituloReunion}", tituloReunion)
                .Replace("{urlMisReuniones}", urlMisReuniones);

            return emailMessage;
        }

        public static string getReunionCredencialesTemplate(string fotoSecretario,string usuarioCreacion, string tituloReunion, string nuevoUsuarioCorreo, string nuevoUsuarioPassword, string urlMisReuniones)
        {
            if (reunionCredencialesTemplate == null)
                reunionCredencialesTemplate = ReadPhysicalFile(@$"{pathReunionTemplates}\PlantillaReunionCredencial.html");

            string emailMessage = reunionCredencialesTemplate
                .Replace("{fotoSecretario}", fotoSecretario)
                .Replace("{usuarioCreacion}", usuarioCreacion)
                .Replace("{tituloReunion}", tituloReunion)
                .Replace("{nuevoUsuarioCorreo}", nuevoUsuarioCorreo)
                .Replace("{nuevoUsuarioPassword}", nuevoUsuarioPassword)
                .Replace("{urlMisReuniones}", urlMisReuniones);

            return emailMessage;
        }

        private static string ReadPhysicalFile(string path)
        {
            if (_hostingEnvironment == null)
                throw new InvalidOperationException($"{nameof(EmailTemplates)} is not initialized");

            IFileInfo fileInfo = _hostingEnvironment.ContentRootFileProvider.GetFileInfo(path);

            if (!fileInfo.Exists)
                throw new FileNotFoundException($"Template file located at \"{path}\" was not found");

            using (var fs = fileInfo.CreateReadStream())
            {
                using (var sr = new StreamReader(fs))
                {
                    return sr.ReadToEnd();
                }
            }
        }
    }
}