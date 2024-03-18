namespace ConsoleApp1;

public abstract class Container
{
    protected float cargo_mass;
    protected int height;
    protected float curb_weight;
    protected int depth;
    protected float max_cargo_weight;

    private int id;

    private static int last_id;

    protected Container(float maxCargoWeight)
    {
        max_cargo_weight = maxCargoWeight;
        this.id = last_id++;
    }

    public virtual void empty_cargo()
    {
        cargo_mass = 0;
    }

    public virtual void load_cargo(int cargo_mass)
    {
        if (cargo_mass > max_cargo_weight)
            throw new OverfillException();
        this.cargo_mass = cargo_mass;
    }

    protected abstract char getType();

    public string getSerial()
    {
        return "KON-" + getType() + "-" + id;
    }

    public float getMass()
    {
        return this.cargo_mass;
    }

    public override string ToString()
    {
        return "[ " + getSerial() + " ] - Mass: " + cargo_mass + ", Height: " + height + ", Depth: " + depth;
    }
}