namespace ConsoleApp1;

public class GasContainer : Container, IHazardNotifier
{
    protected float pressure;
    public GasContainer(float maxCargoWeight) : base(maxCargoWeight)
    {
    }

    public override void empty_cargo()
    {
        cargo_mass = max_cargo_weight * 0.05f;
    }

    protected override char getType()
    {
        return 'G';
    }

    public override void load_cargo(int cargo_mass)
    {
        try
        {
            base.load_cargo(cargo_mass);
        }
        catch (Exception e)
        {
            sendNotification();
            throw;
        }
    }

    public void sendNotification()
    {
        System.Console.WriteLine("[WARNING] - There is an issue with container: " + getSerial());
    }
}