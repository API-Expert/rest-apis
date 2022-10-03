using Domain;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);


builder.Services
    .AddSingleton<IVehicleRepository, InMemroyVehicleRepository>()
    .AddScoped<VehicleService>();

var app = builder.Build();

app.UseHttpsRedirection();


app.MapGet("/", () => Results.Ok(new { api = "Vehicles API" }));


app.MapPost("/v1/vehicles", (VehiclePostRequest request, VehicleService service) =>
{

    try
    {
        var vehicle = new Vehicle(request.Name, request.Brand);
        var result = service.Insert(vehicle);
        var id = result.Result;
        return Results.Created($"/v1/vehicles/{id}", vehicle);
    }
    catch (ArgumentNullException anex)
    {
        return Results.BadRequest(anex.Message);
    }


});

app.MapGet("/v1/vehicles/{id}", (string id, VehicleService service) =>
{
    var result = service.GetById(id);

    if (result.HasErrors())
        return Results.BadRequest(result.Errors);
    else


        return result.Result == null
        ? Results.NotFound()
        : Results.Ok(result.Result);


});




app.MapGet("/v1/vehicles/", (VehicleSearchRequest request, VehicleService service) =>
{
    var errorMessages = new List<string>();

    if (!request.Page.HasValue) errorMessages.Add("page cannot be null");

    if (!request.PageSize.HasValue) errorMessages.Add("pageSize cannot be null");

    if (errorMessages.Count > 0)
        return Results.BadRequest(new { errors = errorMessages.ToArray() });


   var result = service.Find(f =>
     (f.Name == request.Name || string.IsNullOrEmpty(request.Name))
     &&
     (f.Brand == request.Brand || string.IsNullOrEmpty(request.Brand))
     ,
     request.Page.Value,
     request.PageSize.Value);


    return Results.Ok(result.Result);

});

app.MapPut("/v1/vehicles/{id}", (string id, VehiclePutRequest request, VehicleService service) =>
{

    try
    {
        var vehicle = new Vehicle(id, request.Name, request.Brand);
        var result = service.Update(vehicle);
        return result.Result
        ? Results.NoContent()
        : Results.NotFound();

    }
    catch (ArgumentNullException anex)
    {
        return Results.BadRequest(anex.Message);
    }


});

app.MapDelete("/v1/vehicles/{id}", (string id, VehicleService service) =>
{

    try
    {
        var result = service.Remove(id);
        return result.Result
        ? Results.NoContent()
        : Results.NotFound();

    }
    catch (ArgumentNullException anex)
    {
        return Results.BadRequest(anex.Message);
    }


});
app.Run();


