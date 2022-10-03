namespace Infrastructure;

using System;
using System.Collections.Generic;
using Domain;

public class InMemroyVehicleRepository : IVehicleRepository
{
    private const string VehicleNotFoundErrorMessage = "Vehicle not found";
    private readonly List<Vehicle> vehicles;

    public InMemroyVehicleRepository()
    {
        vehicles = new List<Vehicle>();
        
    }


    public ExecutionResult<IEnumerable<Vehicle>> Find(Predicate<Vehicle> predicate, int page, int pageSize)
    {

        var findResult = vehicles.FindAll(predicate)
            .Skip((page - 1) * pageSize)
            .Take(pageSize);

        return new ExecutionResult<IEnumerable<Vehicle>>(findResult);

    }

    public ExecutionResult<Vehicle?> GetById(string id)
    {
        return new ExecutionResult<Vehicle?>( vehicles.FirstOrDefault(v => v.Id == id));
    }

    public ExecutionResult<string> Insert(Vehicle vehicle)
    {

        vehicles.Add(vehicle);
        return new ExecutionResult<string>(vehicle.Id);
    }

    public ExecutionResult<bool> Remove(string id)
    {
        var vehicle = vehicles.FirstOrDefault(v => v.Id == id);

        if (vehicle == null)
            return new ExecutionResult<bool>(new string[] { VehicleNotFoundErrorMessage });
        else
        {
            vehicles.Remove(vehicle);
        return new ExecutionResult<bool>(true);

        }

    }

    public ExecutionResult<bool> Update(Vehicle vehicle)
    {

        
        var index = vehicles.FindIndex(f => f.Id == vehicle.Id);
        if (index == -1)
            return new ExecutionResult<bool>(new string[] { VehicleNotFoundErrorMessage });
        else
        {
            vehicles[index] = vehicle;
            return new ExecutionResult<bool>(true);
        }


    }
}

