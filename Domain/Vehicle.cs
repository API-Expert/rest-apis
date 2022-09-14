namespace Domain;

public class Vehicle
{
    public Vehicle(string id,  string name, string brand)
    {

        if (String.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));
        if (String.IsNullOrEmpty(brand)) throw new ArgumentNullException(nameof(brand));
        if (string.IsNullOrEmpty(id)) throw new ArgumentNullException(nameof(id));

        Id = id;
        Name = name;
        Brand = brand;
    }

    public Vehicle(string name, string brand) : this(Guid.NewGuid().ToString(), name, brand)
    {

    }

    public string Id { get; }
    public string Name { get; }
    public string Brand { get; }


    public  bool Equals(Vehicle obj)
    {
        return
            obj.Brand.Equals(this.Brand) &&
            obj.Name.Equals(this.Name) &&
            obj.Id.Equals(this.Id);
    }
}