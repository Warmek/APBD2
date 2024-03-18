namespace ConsoleApp1;

public class FluidContainer : Container, IHazardNotifier
{
    private bool isHazardous;
    protected override char getType()
    {
        return 'L';
    }

    public FluidContainer(float maxCargoWeight, bool isHazardous) : base(maxCargoWeight)
    {
        this.isHazardous = isHazardous;
    }


    public override void load_cargo(int cargo_mass)
    {
        if (cargo_mass > (max_cargo_weight * (isHazardous ? 0.5f : 0.9f)))
        {
            sendNotification();
            throw new OverfillException();
        }
        base.load_cargo(cargo_mass);
    }

    public void sendNotification()
    {
        System.Console.WriteLine("[WARNING] - There is an issue with container: " + getSerial());
    }
}