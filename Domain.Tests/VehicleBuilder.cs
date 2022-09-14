using System;
namespace Domain.Tests
{
	public class VehicleBuilder
	{

		private string name;
		private string brand;
		private string id;

		public VehicleBuilder Name()
		{
			Name("F355");
			return this;
		}

        public VehicleBuilder Name(string name)
        {
            this.name = name;
            return this;
        }

        public VehicleBuilder Brand()
		{
			this.brand = "Ferrari";
			return this;
		}

		public VehicleBuilder Id(string id)
		{
			this.id = id;
			return this;
		}

		public VehicleBuilder Id()
		{
			Id( Guid.NewGuid().ToString());
			return this;
		}

		public Vehicle Build()
		{
			return new Vehicle(id, name, brand);
		}

		
	}
}

