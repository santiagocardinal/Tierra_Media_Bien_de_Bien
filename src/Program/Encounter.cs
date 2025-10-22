namespace Program;

public class Encounter
{
    private CharacterRegistry registry;
    
    public Encounter(CharacterRegistry registry)
    {
        this.registry = registry;
    }
    
    
    public void DoEncounter()
    {
        List<GoodGuy> good = registry.GoodGuys;
        List<BadGuy> bad = registry.BadGuys;

        int largoGood = good.Count;
        int largoBad = bad.Count;

        if (largoGood==1 && largoBad>1)
        {
            OneHeroe(good, bad);
        }
        else if (largoBad > 1 && largoGood>1)
        {
            Battle(good, bad);
        }
        else
        {
            Console.WriteLine("No hay suficientes enemigos para la batalla");
        }
    }

    public void OneHeroe(List<good> good, List<bad> bad)
    {
        GoodGuy heroe = good[0];
        foreach (var villan in bad)
        {
            villan.Attack(heroe);
        }
    }

    public void Battle(List<GoodGuy> heroes, List<BadGuy> villanos)
    {
        int cantidad = Math.Max(heroes.Count, villanos.Count);

        for (int i = 0; i < cantidad; i++)
        {
            // Usamos módulo para que los índices roten
            GoodGuy hero = heroes[i % heroes.Count];
            BadGuy villain = villanos[i % villanos.Count];

            villain.Attack(hero);
            hero.Attack(villain);
        }
    }

}