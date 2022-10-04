using System;
using Infrastructure;

namespace Domain.Tests
{
    public class VehicleServiceTests
    {
        private readonly IVehicleRepository repository;
        private readonly VehicleBuilder builder;
        private readonly VehicleService service;
        private const string testId = "00000000-0000-0000-0000-0000000000000001";
        private const string testBrand = "Ferrari";
        private const string testName = "F40";

        public VehicleServiceTests()
        {
            this.repository = new InMemroyVehicleRepository();
            this.service = new VehicleService(repository);
            builder = new VehicleBuilder();

            FillRepository();

        }

        private void FillRepository()
        {

            string NewGuid() => Guid.NewGuid().ToString();

            repository.Insert(new Vehicle(testId, "F355 BERLINETTA", "Ferrari"));
            repository.Insert(new Vehicle(NewGuid(), "F360 Modena", "Ferrari"));
            repository.Insert(new Vehicle(NewGuid(), "F430", "Ferrari"));
            repository.Insert(new Vehicle(NewGuid(), testName, "Ferrari"));
            repository.Insert(new Vehicle(NewGuid(), "F458", "Ferrari"));
            repository.Insert(new Vehicle(NewGuid(), "F296 GTB", "Ferrari"));
            repository.Insert(new Vehicle(NewGuid(), "F296 GTS", "Ferrari"));
            repository.Insert(new Vehicle(NewGuid(), "SF90 STRADALE", "Ferrari"));
            repository.Insert(new Vehicle(NewGuid(), "F8 TRIBUTO", "Ferrari"));
            repository.Insert(new Vehicle(NewGuid(), "F8 SPIDER", "Ferrari"));
            repository.Insert(new Vehicle(NewGuid(), "ROMA", "Ferrari"));

            var testVehicle = repository.GetById(testId).Result;
            testVehicle.Details = new Vehicle.VehicleDetails("Is a huge car");
           
        }



        [Fact]
        public void Insert_Vehicle_Success()
        {
            var vehicle = builder
                .Id()
                .Name()
                .Brand()
                .Build();



            var result = service.Insert(vehicle);

            Assert.False(result.HasErrors());
            Assert.Equal(result.Result, vehicle.Id);

        }


        [Fact]
        public void Update_Vehicle_Success()
        {
            const string name = "NEW FERRARI CAR";
            var vehicle = builder
                .Id(testId)
                .Name(name)
                .Brand()
                .Build();


            var result = service.Update(vehicle);


            var updated = service.GetById(testId);

            Assert.False(result.HasErrors());
            Assert.NotNull(updated.Result);
            Assert.Equal<Vehicle>(vehicle, updated.Result);


            
        }

        [Fact]
        public void Update_Vehicle_DoesnotExists_Error()
        {
            
            var vehicle = builder
                .Id(Guid.NewGuid().ToString())
                .Name()
                .Brand()
                .Build();


            var result = service.Update(vehicle);


            Assert.False(result.Result);
            Assert.True(result.HasErrors());
            



        }

        [Fact]
        public void Remove_Vehicle_DoesnotExists_Error()
        {
            var id = Guid.NewGuid().ToString();

            var result = service.Remove(id);

            Assert.False(result.Result);
            Assert.True(result.HasErrors());




        }


        [Fact]
        public void Remove_Vehicle_Success()
        {
            var id = testId;

            var result = service.Remove(id);

            Assert.True(result.Result);
            Assert.False(result.HasErrors());




        }

        [Fact]
        public void Get_Vehicle_By_Id_Success()
        {

            var id = testId;

            var result = service.GetById(id);

            Assert.Equal(id, result.Result?.Id);



        }


        [Fact]
        public void Get_Vehicle_By_Id_NotFound()
        {

            var id = Guid.NewGuid().ToString();

            var result = service.GetById(id);

            Assert.Null(result.Result);



        }

        [Fact]
        public void Find_Vehicle_By_Brand_Success()
        {

            var brand = testBrand;
            const int pageSize = 5;

            var result = service.Find(f => f.Brand == brand, 1, pageSize);

            Assert.Equal(result.Result?.Count(), pageSize);
 


        }


        [Fact]
        public void Find_Vehicle_By_Name_Success()
        {

            var name = testName;
            const int pageSize = 5;

            var result = service.Find(f => f.Name ==name, 1, pageSize);

            Assert.Equal(1,result.Result?.Count());
            Assert.Equal(result.Result?.First().Name, testName);



        }

        [Fact]
        public void Find_Vehicle_By_Name_Return_Empty()
        {

            var name = "doesnotexists";
            const int pageSize = 5;

            var result = service.Find(f => f.Name == name, 1, pageSize);

            Assert.Equal(0, result.Result?.Count());
            


        }

        [Fact]
        public void Get_Details_By_Id_Exists()
        {
            var details = repository.GetDetailsById(testId).Result;

            var vehicle = repository.GetById(testId).Result;

            Assert.Equal(vehicle.Details, details);

            

        }

        [Fact]
        public void Get_Details_By_Id_Not_Exists()
        {
            var id = Guid.NewGuid().ToString();
            var details = repository.GetDetailsById(id).Result;

            Assert.Null(details);


        }

    }


}

