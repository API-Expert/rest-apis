using System;
using Domain;


internal class VehicleDetailsResponse
{

    public string Description { get; }

    public Link[] Links { get; }

    public VehicleDetailsResponse(string id, Vehicle.VehicleDetails details)
    {

        this.Description = details.Description;

        var uri = $"/v1/vehicles/{id}/details";

        Links = new[]
        {
                new Link(uri, "update_details", "PUT"),
                new Link(uri, "get_details", "GET"),
            };

    }
}

