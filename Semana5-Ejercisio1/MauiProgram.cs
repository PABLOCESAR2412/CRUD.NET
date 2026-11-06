using Microsoft.Extensions.Logging;

namespace Semana5_Ejercisio1
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Registrar el repositorio de personas como un servicio singleton
            string dbPath = Utiles.FileAccessHelper.GetFilePath("personas.db3");

            // Asegúrate de que la ruta de la base de datos sea correcta y accesible
            builder.Services.AddSingleton<Repositories.PersonRespository>
                (s => ActivatorUtilities.CreateInstance<Repositories.PersonRespository>(s, dbPath));

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
