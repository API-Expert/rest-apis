

namespace Domain.Tests;

using Domain;

public class VehicleTests
{
    [Fact]
    public void Vehicle_Created_Success()
    {
        //arrange
        var name = "F355";
        var brand = "Ferrari";

        //act
        var vehicle = new Vehicle(name, brand);


        //assert
        Assert.Equal(name, vehicle.Name);
        Assert.Equal(brand, vehicle.Brand);


    }


    [Fact]
    public void Vehicle_Creation_Name_Invalid_Exception()
    {

        Assert.Throws<ArgumentNullException>(() =>
        {
            var name = "F355";
            var brand = string.Empty;

            _ = new Vehicle(name, brand);

        });

    }

    [Fact]
    public void Vehicle_Creation_Brand_Invalid_Exception()
    {

        Assert.Throws<ArgumentNullException>(() =>
        {
            var name = string.Empty;
            var brand = "Ferrari";
            _ = new Vehicle(name, brand);

        });

    }

    [Fact]
    public void Vehicle_Creation_Id_Invalid_Exception()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            var name = string.Empty;
            var brand = "Ferrari";
            var id = string.Empty;

            _ = new Vehicle(id, name, brand);

        });

    }

    [Fact]
    public void Vehicle_Invalid_Details_Exception()
    {

        Assert.Throws<ArgumentNullException>(() =>
        {

            var description = "";
           _ = new Vehicle.VehicleDetails(description);

        });


    }

    [Fact]
    public void Vehicle_Details_Success()
    {

        var description = "F40 is a huge car";

        var details = new Vehicle.VehicleDetails(description);

        Assert.Equal(details.Description, description);


    }



}