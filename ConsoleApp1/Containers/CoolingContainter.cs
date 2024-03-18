namespace ConsoleApp1;

public class CoolingContainter : Container, IHazardNotifier
{
    private static Dictionary<string, float> productConditions = new Dictionary<string, float>{
        { "Bananas", 13.3f},
        { "Chocolate", 18f },
        { "Fish", 2f },
        { "Meat", -15f },
        { "Ice cream", -18f },
        { "Frozen pizza", -30f },
        { "Cheese", 7.2f },
        { "Sausages", 5f },
        { "Butter", 20.5f },
        { "Eggs", 19f }
    };

    private string productName;
    private float currentTemp;

    public CoolingContainter(float maxCargoWeight, string productName, float currentTemp) : base(maxCargoWeight)
    {
        this.productName = productName;
        if (currentTemp < getMinTemp())
            throw new Exception("Temperature is too low for this product");
        this.currentTemp = currentTemp;
    }

    private float getMinTemp()
    {
        return productConditions[productName];
    }

    protected override char getType()
    {
        return 'C';
    }

    public void sendNotification()
    {
        System.Console.WriteLine("[WARNING] - There is an issue with container: " + getSerial());
    }
}