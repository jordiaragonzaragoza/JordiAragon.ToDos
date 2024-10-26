namespace JordiAragonZaragoza.MessageHub.AssemblyConfiguration
{
    using Microsoft.AspNetCore.Builder;

    public static class ConfigureWebApplication
    {
        public static WebApplication AddWebApplicationConfigurations(WebApplication app)
        {
            app.MapHealthChecks("/health");

            return app;
        }
    }
}