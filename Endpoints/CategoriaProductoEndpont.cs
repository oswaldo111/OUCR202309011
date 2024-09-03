using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OUCR202309011.Endpoints
{
    
    public static class CategoriaProductoEndpont 
    {
         static List<string> CategoriaProducto = new List<string>();
      public static void addCategoriaProductoEndpont(this WebApplication app)
        {

            app.MapGet("/CategoriaProducto", () =>
            {
                return CategoriaProducto;
            }).AllowAnonymous();

            app.MapPost("/CategoriaProducto", (string nombre) =>
            {
                CategoriaProducto.Add(nombre);
                return Results.Ok();
            }).RequireAuthorization();

        }
    }
}
