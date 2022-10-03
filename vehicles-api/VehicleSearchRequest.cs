internal class VehicleSearchRequest
{
    public string Name { get; set; }
    public string Brand { get; set; }
    public int? Page { get; set; }
    public int? PageSize { get; set; }

    public static ValueTask<VehicleSearchRequest?> BindAsync(HttpContext context)
        => ValueTask.FromResult<VehicleSearchRequest?>(new VehicleSearchRequest()
        {


            Brand = context.Request.Query["brand"],
            Name = context.Request.Query["name"],

            Page = int.TryParse(context.Request.Query["page"], out var page) ? page : null,
            PageSize = int.TryParse(context.Request.Query["pageSize"], out var pageSize) ? pageSize : null

        });


}