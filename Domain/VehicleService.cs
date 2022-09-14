using System;
namespace Domain
{
	public class VehicleService
	{
        private readonly IVehicleRepository repository;

        public VehicleService(IVehicleRepository repository) => this.repository = repository;

        public ExecutionResult<string> Insert(Vehicle vehicle) => repository.Insert(vehicle);

        public ExecutionResult<bool> Update(Vehicle vehicle) => repository.Update(vehicle);

        public ExecutionResult<bool> Remove(string id) => repository.Remove(id);

        public ExecutionResult<Vehicle?> GetById(string id) => repository.GetById(id);

        public ExecutionResult<IEnumerable<Vehicle>> Find(Predicate<Vehicle> predicate, int page, int pageSize) => repository.Find(predicate, page, pageSize);
    }
}

