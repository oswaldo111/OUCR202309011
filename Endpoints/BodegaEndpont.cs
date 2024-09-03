using Microsoft.AspNetCore.Mvc;
using OUCR202309011.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OUCR202309011.Endpoints
{
    public static class BodegaEndpoints
    {
        static List<Bodega> Bodegas = new List<Bodega>();

        public static void addBodegaEndpoint(this WebApplication app)
        {
            app.MapPost("/Bodega", (Bodega bodega) =>
            {
                Bodegas.Add(bodega);
                return Results.Ok();
            }).RequireAuthorization();

            app.MapGet("/Bodega/{id}", (int id) =>
            {
                var bodega = Bodegas.FirstOrDefault(c => c.Id == id);
                return bodega;
            }).RequireAuthorization();

            app.MapPut("/Bodega/{id}", (int id, Bodega bodega) =>
            {
                var existingProducs = Bodegas.FirstOrDefault(c => c.Id == id);

                if (existingProducs != null)
                {
                    existingProducs.Name = bodega.Name;
                    existingProducs.Description = bodega.Description;
                    return Results.Ok();
                }
                else return Results.NotFound();
            }).RequireAuthorization();
        }
    }
}
