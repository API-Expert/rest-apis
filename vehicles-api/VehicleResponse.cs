using System;
using Domain;


internal class VehicleResponse
{

    public string Brand { get; }
    public string Name { get; }
    public string Id { get; }

    public Link[] Links { get; }

    public VehicleResponse(Vehicle vehicle)
    {

        this.Brand = vehicle.Brand;
        this.Name = vehicle.Name;
        this.Id = vehicle.Id;

        var uri = $"/v1/vehicles/{Id}";

        Links = new[]
        {
                new Link(uri, "self",  "GET"),
                new Link(uri, "update_vehicle", "PUT"),
                new Link(uri, "delete_vehicle", "DELETE"),
                new Link($"{uri}/details", "update_details", "PUT"),
                new Link($"{uri}/details", "get_details", "GET"),
            };

    }
}

