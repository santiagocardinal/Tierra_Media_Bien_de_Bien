namespace Program;

public class CharacterRegistry
{
    private List<GoodGuy> goodGuys;
    private List<BadGuy> badGuys;

    public List<GoodGuy> GoodGuys
    {
        get { return goodGuys; }
        set { goodGuys = value; }
    }

    public List<BadGuy> BadGuys
    {
        get { return badGuys; }
        set { badGuys = value; }
    }

    public CharacterRegistry()
    {
        this.GoodGuys = new List<GoodGuy>();
        this.BadGuys = new List<BadGuy>();
    }

    public void ArrangeCharacters(Character character)
    {
        if (Character is GoodGuy)
        {
            this.GoodGuys.Add(character);
        }
        else
        {
            this.BadGuys.Add(character);
        }
    }
}