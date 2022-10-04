namespace Domain
{
    public interface IVehicleRepository
    {
        ExecutionResult<IEnumerable<Vehicle>> Find(Predicate<Vehicle> predicate, int page, int pageSize);
        ExecutionResult<Vehicle?> GetById(string id);
        ExecutionResult<Vehicle.VehicleDetails?> GetDetailsById(string id);
        ExecutionResult<string> Insert(Vehicle vehicle);
        ExecutionResult<bool> Remove(string id);
        ExecutionResult<bool> Update(Vehicle vehicle);
    }
}