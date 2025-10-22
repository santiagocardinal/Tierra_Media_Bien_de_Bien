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
        if (character is GoodGuy good)
        {
            this.GoodGuys.Add(good);
        }
        else if (character is BadGuy bad)
        {
            this.BadGuys.Add(bad);
        }
    }
}