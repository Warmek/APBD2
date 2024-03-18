// See https://aka.ms/new-console-template for more information

using ConsoleApp1;

public class Program
{
    public static void Main(string[] args)
    {
        Boat Borealis = new Boat(50f, 50, 75f);

        List<Container> shipsManifest = new List<Container>();
        
        shipsManifest.Add(new FluidContainer(100f, true));
        shipsManifest.Add(new GasContainer(200f));
        shipsManifest.Add(new CoolingContainter(150f, "Bananas", 16.6f));
        
        shipsManifest[0].load_cargo(40);
        
        Borealis.loadCargo(shipsManifest);

        Console.WriteLine(Borealis.ToString());
    }
}