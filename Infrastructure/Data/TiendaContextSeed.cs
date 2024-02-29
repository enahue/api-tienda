using Microsoft.Extensions.Logging;

namespace Infrastructure.Data;

    public class TiendaContextSeed
    {
        public static async Task SeedAsync(TiendaContext context, ILoggerFactory loggerFactory){
            try{
                var ruta = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                if(!context.Marca.Any()){
                    using(var readerMarcas = new StreamReader(ruta + @"/DATA/Csvs/marcas.csv")){
                            using(var csvMarcas = new CsvReader(readerMarcas, cultureInfo.InvariantCulture)){
                                var marcas = csvMarcas.GetRecords<Marca>();
                                context.Marca.AddRange(marcas);
                                await context.SaveChangesAsync();
                            }
                    }
                }
                if(!context.Categorias.Any()){
                    using(var readerCategorias = new StreamReader(ruta + @"/DATA/Csvs/categorias.csv")){
                            using(var csvCategorias = new CsvReader(readerCategorias, cultureInfo.InvariantCulture)){
                                var categorias = csvCategorias.GetRecords<Categoria>();
                                context.Categoria.AddRange(categorias);
                                await context.SaveChangesAsync();
                            }
                    }
                }
                if(!context.Productos.Any()){
                    using(var readerProductos = new StreamReader(ruta + @"/DATA/Csvs/productos.csv")){
                            using(var csvCategorias = new CsvReader(readerCategorias, cultureInfo.InvariantCulture)){
                                var listadoProductosCsv = csvProductos.GetRecords<Producto>();
                                List<Producto> productos = new List<Producto>();
                                foreach (var item in listadoProductosCsv)
                                {
                                    productos.Add(new Producto(
                                        Id = item.Id,
                                        Nombre = item.Nombre,
                                        Precio = item.Precio,
                                        FechaCreacion = item.FechaCreacion,
                                        CategoriaId = item.CategoriaId,
                                        MarcaId = item.MarcaId
                                    ));
                                }
                                context.Productos.AddRange(productos);
                                await context.SaveChangesAsync();

                            }
                    }
                }

            }
        }
            }
            catch(Exception ex){
                var logger = loggerFactory.CreateLogger<TiendaContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
