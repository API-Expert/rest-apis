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

        public ExecutionResult<Vehicle.VehicleDetails> GetDetailsById(string id) => repository.GetDetailsById(id);

        public ExecutionResult<bool> UpdateDetails(string id, Vehicle.VehicleDetails details)
        {
            var vehicle = repository.GetById(id).Result;

            if (vehicle == null)
                return new ExecutionResult<bool>(false);

            vehicle.Details = details;
            repository.Update(vehicle);
            return new ExecutionResult<bool>(true);

        }
    }
}

