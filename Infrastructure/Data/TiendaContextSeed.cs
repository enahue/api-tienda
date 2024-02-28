using Microsoft.Extensions.Logging;

namespace Infrastructure.Data;

    public class TiendaContextSeed
    {
        public static async Task SeedAsync(TiendaContext context, ILoggerFactory loggerFactory){
            try{
                

            }
            catch(Exception ex){
                var logger = loggerFactory.CreateLogger<TiendaContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
