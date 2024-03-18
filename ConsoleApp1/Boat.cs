namespace ConsoleApp1;

public class Boat
{
    private List<Container> cargo;
    private float maxSpeed;
    private int maxContainerCount;
    private float maxContainerWeight;


    public Boat(float maxSpeed, int maxContainerCount, float maxContainerWeight)
    {
        this.cargo = new List<Container>();
        this.maxSpeed = maxSpeed;
        this.maxContainerCount = maxContainerCount;
        this.maxContainerWeight = maxContainerWeight;
    }

    public void loadCargo(IEnumerable<Container> containers)
    {
        foreach (var container in containers)
        {
            loadCargo(container);
        }
    }
    

    public void loadCargo(Container container)
    {
        if (cargo.Count >= maxContainerCount)
            throw new Exception("Cargo count excited!");

        float currentMass = 0;

        foreach (var cont in cargo)
        {
            currentMass += cont.getMass()/1000f;
        }

        if (currentMass + container.getMass() > this.maxContainerWeight)
        {
            throw new Exception("Cargo mass excited!");
        }
        
        cargo.Add(container);
    }

    public Container unloadCargo(string serial)
    {
        Container output = null;
        foreach (var container in cargo)
        {
            if (container.getSerial() == serial)
            {
                output = container;
                break;
            }
        }

        if (output != null)
        {
            cargo.Remove(output);
        }
        
        return output;
    }

    public void replace(string toRemove, Container toAdd)
    {
        unloadCargo(toRemove);
        loadCargo(toAdd);
    }

    public override string ToString()
    {
        return string.Join("\n", cargo);
    }
}