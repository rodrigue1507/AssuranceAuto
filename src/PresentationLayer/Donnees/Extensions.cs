using InfrastructureLayer.Data;

namespace PresentationLayer.Donnees
{
    public static  class Extensions
    {
        public static void AddDataToDbIfNotExists(this IHost host)
        {
        
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<ContratAutoDbContext>();
                context.Database.EnsureCreated();
                DBInitializer.Initialize(context);
            }
            
        }
    }
}
